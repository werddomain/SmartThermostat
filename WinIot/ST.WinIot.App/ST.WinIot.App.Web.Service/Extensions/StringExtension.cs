
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Html;
using System.Text.Encodings.Web;

namespace System
{
    public static class StringExtension
    {
       

        public static object NullToDbNull(this object value)
        {
            return ST.WinIot.App.Web.Service.Utility.NullToDBNull(value);

        }
        public static string ToClass(this string str)
        {
            return str.Replace("_", "-");
        }

        //public static async Task<string> ToPriceConverted(this double value, BaseModel model, string ConvertToCurrency = null)
        //{
        //    if (String.IsNullOrEmpty(ConvertToCurrency))
        //        ConvertToCurrency = BaseController.CurrencyInfo.CurrentCurency(ses;

        //    var Converted = await ST.WinIot.App.Web.Service.Helper.CurrencyHelper.GetConvertedCurrencyValue(model.Param.Shop.MoneyUnit, ConvertToCurrency, value, new ST.WinIot.App.Web.Service.Services.Service(Guid.Empty, "en"));
        //    return string.Format("{0:N2}", Math.Round(value, 2)) + " " + CurencyToUnit(ConvertToCurrency);
        //}

        public static HtmlString ToNewLinteToBr(this string value, bool encodingFix = false)
        {
            if (encodingFix)
                value = value.Replace("&amp;", "&");
            
            value = HtmlEncoder.Default.Encode(value).Replace(Environment.NewLine, "<br/>");
            return value.ToMvcHtmlString();
        }

        public static HtmlString ToMvcHtmlString(this string value, bool encodingFix = false)
        {
            if (encodingFix)
                value = value.Replace("&amp;", "&");

            return new HtmlString(value);
        }
        public static HtmlString ToMvcHtmlString(this StringBuilder value)
        {
            return new HtmlString(value.ToString());
        }
        public static String MaskInput(this string input, int charactersToShow)
        {
            var charactersToShowAtEnd = charactersToShow / 2;
            if (input.Length <= charactersToShowAtEnd)
            {
                return input;

            }
            String endCharacters = input.Substring(input.Length - charactersToShowAtEnd);
            string startCaracters = input.Substring(0, charactersToShowAtEnd);
            return String.Format(
              "{0}{1}{2}",
              startCaracters,
              "".PadLeft(input.Length - charactersToShowAtEnd * 2, '*'),
              endCharacters
              );
        }

        public static string ToFormated(this int number)
        {
            return number.ToString("N0");
        }
        public static string ExtractAllNumbers(this string str)
        {
            return Regex.Match(str, @"\d+").Value;
        }
        public static string FixEncoding(this string str)
        {
            return str
                .Replace("Ã", "à")
                .Replace("Ã¢", "â")
                .Replace("Ã©", "é")
                .Replace("Ã¨", "è")
                .Replace("Ãª", "ê")
                .Replace("Ã«", "ë")
                .Replace("Ã®", "î")
                .Replace("Ã¯", "ï")
                .Replace("Ã´", "ô")
                .Replace("Ã¶", "ö")
                .Replace("Ã¹", "ù")
                .Replace("Ã»", "û")
                .Replace("Ã¼", "ü")
                .Replace("Ã§", "ç")
                .Replace("Å", "œ")
                .Replace("â¬", "€")
                .Replace("Â°", "°")
                .Replace("Ã", "À")
                .Replace("Ã", "Â")
                .Replace("Ã", "É")
                .Replace("Ã", "È")
                .Replace("Ã", "Ê")
                .Replace("Ã", "Ë")
                .Replace("Ã", "Î")
                .Replace("Ã", "Ï")
                .Replace("Ã", "Ô")
                .Replace("Ã", "Ö")
                .Replace("Ã", "Ù")
                .Replace("Ã", "Û")
                .Replace("Ã", "Ü")
                .Replace("Ã", "Ç")
                .Replace("Å", "Œ");


        }
        public static string GenerateSlug(this string phrase)
        {
            string str = phrase.ToUnaccented().ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        public static string MaxChar(this string Str, int max, bool reverse = false, bool add3Dots = true)
        {
            if (Str.Length > max)
            {
                if (reverse)
                    return (add3Dots ? "..." : "") + Str.Substring(Str.Length - max, max);
                else
                    return Str.Substring(0, max) + (add3Dots ? "..." : "");
            }
            return Str;
        }

        public static IEnumerable<int> AllIndexesOf(this string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    break;
                yield return index;
            }
        }
        public static string[] DirectSplit(this string text, string character, StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        {
            if (text != null)
            {
                string[] splitters = new string[] { character };
                return text.Split(splitters, options);
            }
            else
            {
                return null;
            }
        }

        public static bool PassFilter(this string text, string Filter)
        {
            text = (text == null) ? text = "" : text;
            // if (Filter == "" || text.ToStandardized().IndexOf(Filter.ToStandardized())>-1)
            if (Filter == "" || text.ToStandardized().Contains(Filter.ToStandardized()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static String ToStandardized(this string text)
        {
            text = (text == null) ? text = "" : text;
            return text.ToUpper().ToUnaccented();
        }

        public static String ToUppercaseFirst(this string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToLower().ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);

        }

        public static String NullToEmpty(this string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return s;

        }


        public static String ToUnaccented(this string text)
        {
            string accent = "ÀÁÂÃÄÅàáâãäåÒÓÔÕÖØòóôõöøÈÉÊËèéêëÌÍÎÏìíîïÙÚÛÜùúûüÿÑñÇç";
            string noAccent = "AAAAAAaaaaaaOOOOOOooooooEEEEeeeeIIIIiiiiUUUUuuuuyNnCc";

            char[] tableauAccent = accent.ToCharArray();
            char[] tableauSansAccent = noAccent.ToCharArray();

            for (int i = 0; i < accent.Length; i++)
            {
                // Remplacement de l'accent par son équivalent sans accent dans la chaîne de caractères
                text = text.Replace(tableauAccent[i].ToString(), tableauSansAccent[i].ToString());
            }

            // Retour du résultat
            return text;

        }

        //public static double ToDouble(this string text)
        //{
        //    double SepVal = 1.0 / 2.0;
        //    string SepValString = SepVal.ToString();
        //    if (SepValString.Contains(","))
        //    {
        //        return double.Parse(text.Replace(".", ","));
        //    }
        //    else
        //    {
        //        return double.Parse(text.Replace(",", "."));
        //    }
        //}

        public static bool IsNullOrEmpty(this string valeur)
        {
            return String.IsNullOrEmpty(valeur) || String.IsNullOrWhiteSpace(valeur);
        }
        public static bool HasValue(this string value)
        {
            return ContainSomething(value);
        }
        public static bool HasValueNoWhiteSpace(this string value)
        {
            return value != null && value.Trim().HasValue();
        }

        public static bool ContainSomething(this string valeur)
        {
            return !valeur.IsNullOrEmpty();
        }
        public static bool ContainsNotCaseSensitive(this string o, string value)
        {
            return o.ToUpper().Contains(value.ToUpper());
        }
        /// <summary>
        /// Cette extension extrait une valeur inclu dans une contaténation de string
        /// Exemple : "propVal1=123;propVal2=444;propVal3=test"
        /// </summary>
        /// <param name="val"></param>
        /// <param name="fieldName"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public static string ExtractSplitValue(this string val, string fieldName, string splitChar = ";")
        {
            string[] lstParam = val.Split(new string[] { splitChar }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in lstParam)
            {
                string[] propVal = item.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                if (propVal.Length == 2)
                {
                    string prop = propVal[0].Trim().ToUpper();
                    string returnVal = propVal[1].Trim();
                    if (prop == fieldName.ToUpper())
                    {
                        return returnVal;
                    }
                }
            }
            return "";
        }

        public static double? ToDouble(this object valueStr, double? defaultValueWhenNotValid = null)
        {
            return ToDouble(valueStr.ToString(), defaultValueWhenNotValid);
        }
        public static double? ToDouble(this string valueStr, double? defaultValueWhenNotValid = null)
        {
            string valueStrCorrected = "";

            double SepVal = 1.0 / 2.0;
            string SepValString = SepVal.ToString();
            if (SepValString.IndexOf(",") > -1)
            {
                valueStrCorrected = valueStr.Replace(".", ",");
            }
            else
            {
                valueStrCorrected = valueStr.Replace(",", ".");
            }

            double val;
            if (Double.TryParse(valueStrCorrected, out val))
            {
                return val;
            }
            return defaultValueWhenNotValid;
        }
        public static int? ToInt(this string valueStr, int? defaultValueWhenNotValid = null)
        {
            int val;
            if (valueStr == null)
                return null;
            if (int.TryParse(valueStr, out val))
            {
                return val;
            }
            return defaultValueWhenNotValid;
        }
        public static long? ToLong(this string valueStr, long? defaultValueWhenNotValid = null)
        {
            long val;
            if (valueStr == null)
                return null;
            if (long.TryParse(valueStr, out val))
            {
                return val;
            }
            return defaultValueWhenNotValid;
        }
        public static bool? ToBool(this string valueStr, bool? defaultValueWhenNotValid = null)
        {
            bool val;
            if (bool.TryParse(valueStr, out val))
            {
                return val;
            }
            return defaultValueWhenNotValid;
        }
        public static bool? ToBool(this object value, bool? defaultValueWhenNotValid = null)
        {
            bool val;
            if (value == null)
                return null;
            if (bool.TryParse(value.ToString(), out val))
            {
                return val;
            }
            return defaultValueWhenNotValid;
        }
        public static Guid? ToGuid(this string valueStr, Guid? defaultValueWhenNotValid = null)
        {
            Guid val;
            if (Guid.TryParse(valueStr, out val))
            {
                return val;
            }
            return defaultValueWhenNotValid;

        }




        //public static async Task<string> ToPriceConverted(this double value, BaseModel model, string ConvertToCurrency = null)
        //{
        //    if (String.IsNullOrEmpty(ConvertToCurrency))
        //        ConvertToCurrency = BaseController.CurrencyInfo.CurrentCurency(ses;

        //    var Converted = await ST.WinIot.App.Web.Service.Helper.CurrencyHelper.GetConvertedCurrencyValue(model.Param.Shop.MoneyUnit, ConvertToCurrency, value, new ST.WinIot.App.Web.Service.Services.Service(Guid.Empty, "en"));
        //    return string.Format("{0:N2}", Math.Round(value, 2)) + " " + CurencyToUnit(ConvertToCurrency);
        //}


    }
}
