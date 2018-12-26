using ST.Web.Service;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;



namespace System.Web
{
    public static class Extender
    {
               public static string AddQueryStringParam(this string url, string ParamName, string ParamValue)
        {
            //Si le parametres est déjà contenu dans la querystring, je l'ajoute pas
            if (url.Contains("?" + ParamName + "=") || url.Contains("&" + ParamName + "="))
            {
                return url;
            }

            //Si il n'y avait encore aucun parametres de queery string
            if (url.Contains("?"))
                return url + "&" + ParamName + "=" + ParamValue;
            //Si d'autre parametres existaient deja
            else
                return url + "?" + ParamName + "=" + ParamValue;
        }

        public static T NextItem<T>(this IEnumerable<T> list, T item)
        {
            int index = list.ToList().IndexOf(item);
            var nextElement = list.ElementAtOrDefault(index + 1);
            return nextElement;
        }
        public static bool NotNullAndHaveItems<T>(this IEnumerable<T> list)
        {
            if (list != null && list.Any())
                return true;
            else
                return false;
        }
        public static TEntity ExtractSimilarity<TEntity>(this IEnumerable<TEntity> entities, TEntity defaultEntity = default(TEntity))
        {
            var props = typeof(TEntity).GetProperties().Where(o => o.CanWrite);

            if (defaultEntity == null)
                defaultEntity = System.Activator.CreateInstance<TEntity>();

            object lastValue = null;
            bool firstItem = true;
            bool similar = true;
            foreach (var prop in props)
            {
                firstItem = true;
                similar = true;
                foreach (var entity in entities)
                {
                    var actualVal = prop.GetValue(entity);

                    if (firstItem)
                    {
                        lastValue = actualVal;
                        firstItem = false;
                    }
                    else
                    {
                        if ((lastValue == null && actualVal != null) || (lastValue != null && !lastValue.Equals(actualVal)))
                        {
                            similar = false;
                            break;
                        }
                    }
                }

                if (similar)
                    prop.SetValue(defaultEntity, lastValue);

            }

            return defaultEntity;

        }
 public static double? ToDouble(this object valueStr)
        {
            double val;
            if (Double.TryParse(valueStr.ToString(), out val))
            {
                return val;
            }
            else
                if (Double.TryParse(valueStr.ToString().Replace('.', ','), out val))
                {
                    return val;
                }
                else
                    if (Double.TryParse(valueStr.ToString().Replace(',', '.'), out val))
                    {
                        return val;
                    }
            return null;
        }
        public static double? ToDouble(this string valueStr)
        {
            double val;
            if (valueStr == null)
                return null;
            if (Double.TryParse(valueStr, out val))
            {
                return val;
            }
            else
                if (Double.TryParse(valueStr.Replace('.',','), out val))
                {
                    return val;
                }
                else
                    if (Double.TryParse(valueStr.Replace(',', '.'), out val))
                    {
                        return val;
                    }
            return null;
        }


       


     

       

       
     
        public static QueryResult ExtractDistinctResult(this List<QueryResult> queryResults)
        {
            QueryResult finalResult = new QueryResult();

            if (queryResults.Where(o => o.Success == false).HasValue())
            {
                finalResult.Success = false;
                var messages = queryResults.SelectMany(o => o.QueryResultMsgs).Distinct(new QueryResultMsg());

                foreach (var item in messages)
                {
                    finalResult.QueryResultMsgs.Add(item);
                }
            }
            else
                finalResult.Success = true;


            return finalResult;
        }

       


        public static string ToDisplayName(this PropertyInfo prop)
        {
            string ressToFind = prop.Name;

            var displayNameAttr = prop.CustomAttributes.FirstOrDefault(o => o.AttributeType.Name == "DisplayAttribute");
            if (displayNameAttr != null)
            {
                
                if (displayNameAttr.NamedArguments.HasValue())
                {
                    var tt = displayNameAttr.NamedArguments.FirstOrDefault(o => o.MemberName == "Name");
                    var val = tt.TypedValue.Value;
                    if (val != null)
                    {
                        ressToFind = val.ToString();
                    }
                }
            }

            ResourceManager resourceManager = Config.NamesResourceManager;
            CultureInfo culture = CultureInfo.CurrentUICulture;
            return resourceManager.GetString(ressToFind, culture);
        }

       



        public static bool CSTryIntParse(this string value, out int result)
        {
            if (int.TryParse(value, out result))
                return true;

            return false;
        }
        public static bool CSTryDoubleParse(this string value, out double result)
        {
            if (double.TryParse(value, out result))
                return true;

            if (value.IndexOf(",") > -1)
            {
                if (double.TryParse(value.Replace(",", "."), out result))
                    return true;
            }
            else
            {
                if (double.TryParse(value.Replace(".", ","), out result))
                    return true;
            }

            return false;
        }
        public static bool CSTryFloatParse(this string value, out float result)
        {
            if (float.TryParse(value, out result))
                return true;

            if (value.IndexOf(",") > -1)
            {
                if (float.TryParse(value.Replace(",", "."), out result))
                    return true;
            }
            else
            {
                if (float.TryParse(value.Replace(".", ","), out result))
                    return true;
            }

            return false;
        }

    }
}