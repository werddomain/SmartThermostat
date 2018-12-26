
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace ST.Web.Service.Services
{
    public class JsGridResult<T>
    {
        public IEnumerable<T> Objects { get; set; }
        public int TotalCount { get; set; }
        public JqJSON<T> JsonObject { get; set; }
        public JqJSON<object> NewJson(object[] rows)
        {
            var o = new JqJSON<object>()
                {
                    total = JsonObject.total,
                    page = JsonObject.page,
                    records = JsonObject.records,
                    rows = rows
                };
            return o;
        }
    }
    public class JqJSON<T>
    {
        public int total { get; set; }
        public int page { get; set; }
        public int records { get; set; }
        public T[] rows { get; set; }
    }
    public class JqCount
    {
        public int Count { get; set; }
    }
    public class jqGridRequest
    {
        public class RequestParams
        {
            public bool? _search { get; set; }
            public int? page { get; set; }
            public int? rows { get; set; }
            public string sidx { get; set; }
            public string sord { get; set; }
            public string searchField { get; set; }
            public string searchString { get; set; }
            public string searchOper { get; set; }

            public int OutTotal { get; set; }
            public string filters { get; set; }
            public Filter Where { get; set; }

        }

        public class Filter
        {

            public string groupOp { get; set; }

            public Rule[] rules { get; set; }
            public Filter[] groups { get; set; }
            public static Filter Create(string jsonData)
            {
                try
                {
                    return JsonConvert.DeserializeObject<Filter>(jsonData);
                    //var serializer = new DataContractJsonSerializer(typeof(Filter));
                    ////var ms = new System.IO.MemoryStream(Encoding.Default.GetBytes(jsonData));
                    //var ms = new System.IO.MemoryStream(
                    //    Encoding.Convert(
                    //        Encoding.Default,
                    //        Encoding.UTF8,
                    //        Encoding.Default.GetBytes(jsonData)));
                    //return serializer.ReadObject(ms) as Filter;
                }
                catch
                {
                    return null;
                }
            }

        }


        public class Rule
        {

            public string field { get; set; }

            public string op { get; set; }

            public string data { get; set; }
        }
        public class jsGridResponce
        {
            public List<SqlParameter> Params { get; set; }
            public string Select { get; set; }
        }

        public jqGridRequest(string tableName, string idName)
        {
            TableName = tableName;
            IdName = idName;
        }
        int filterIncrement = 0;
        string getFiltersConditions<T>(Filter where, List<SqlParameter> ParamList, Dictionary<string, DbType> dbTypes)
        {
            if (where.groupOp.ToLower() != "or" && where.groupOp.ToLower() != "and")
                return "";
            var conditions = new List<string>();
            if (where.rules.HasValue())
            {
                foreach (var item in where.rules)
                {
                    if (dbTypes.Any(o => o.Key.ToLower() == item.field.ToLower()))
                    {
                        string paramName = "@pFilter" + filterIncrement + item.field;
                        filterIncrement += 1;
                        string additionalParam = "@pFilter" + filterIncrement + item.field;

                        
                        var type = dbTypes.FirstOrDefault(o => o.Key.ToLower() == item.field.ToLower());
                        switch (type.Value)
                        {
                           
                            
                            case DbType.Boolean:
                                ParamList.Add(new SqlParameter(paramName, type.Value) { Value = (item.data == null ? (bool?)null : (bool?)(item.data.ToLower() == "true")).NullToDbNull()  });
                                conditions.Add("p." + item.field + " " + SearchOperToSqlOper(item.op) + " " + paramName);

                                break;
                           
                               
                            case DbType.Date:
                               
                            case DbType.DateTime:
                               
                            case DbType.DateTime2:
                              
                            case DbType.DateTimeOffset:
                                if (item.data.Contains(" -> "))
                                {
                                    var sp = item.data.DirectSplit(" -> ");
                                    if (sp.Length > 1)
                                    {
                                        DateTime dStart, dEnd;
                                        if (DateTime.TryParse(sp[0], out dStart) && DateTime.TryParse(sp[1], out dEnd))
                                        {
                                            ParamList.Add(new SqlParameter(paramName, type.Value) { Value = dStart.ToUniversalTime() });
                                            ParamList.Add(new SqlParameter(additionalParam, type.Value) { Value = dEnd.AddHours(23).AddMinutes(59).AddSeconds(59).ToUniversalTime() });
                                            conditions.Add("(p." + item.field + " >=" + paramName + " AND p." + item.field + " <=" + additionalParam + " )");
                                        }
                                        else
                                        {
                                            DateTime date;
                                            if (DateTime.TryParse(sp[0], out date))
                                            {
                                                ParamList.Add(new SqlParameter(paramName, type.Value) { Value = date });
                                                conditions.Add("p." + item.field + " " + SearchOperToSqlOper(item.op) + " " + paramName);

                                            }
                                            else
                                            {
                                                ParamList.Add(new SqlParameter(paramName, DbType.String) { Value = sp[0].NullToDbNull() });
                                                conditions.Add("p." + item.field + " " + SearchOperToSqlOper(item.op) + " " + paramName);

                                            }
                                        }
                                    }
                                    else
                                    {
                                        DateTime date;
                                        if (DateTime.TryParse(sp[0], out date))
                                        {
                                            ParamList.Add(new SqlParameter(paramName, type.Value) { Value = date });
                                            conditions.Add("p." + item.field + " " + SearchOperToSqlOper(item.op) + " " + paramName);

                                        }
                                        else
                                        {
                                            ParamList.Add(new SqlParameter(paramName, DbType.String) { Value = sp[0].NullToDbNull() });
                                            conditions.Add("p." + item.field + " " + SearchOperToSqlOper(item.op) + " " + paramName);

                                        }
                                    }
                                }
                                else
                                {
                                    DateTime date;
                                    if (DateTime.TryParse(item.data, out date))
                                    {
                                        ParamList.Add(new SqlParameter(paramName, type.Value) { Value = date });
                                        conditions.Add("p." + item.field + " " + SearchOperToSqlOper(item.op) + " " + paramName);

                                    }
                                    else
                                    {
                                        ParamList.Add(new SqlParameter(paramName, DbType.String) { Value = item.data.NullToDbNull() });
                                        conditions.Add("p." + item.field + " " + SearchOperToSqlOper(item.op) + " " + paramName);

                                    }
                                }
                                break;

                            case DbType.Decimal:
                            case DbType.Double:
                                ParamList.Add(new SqlParameter(paramName, type.Value) { Value = item.data.ToDouble().NullToDbNull() });
                                conditions.Add("p." + item.field + " " + SearchOperToSqlOper(item.op) + " " + paramName);
                                
                                break;
                            case DbType.Guid:
                                ParamList.Add(new SqlParameter(paramName, type.Value) { Value = item.data.ToGuid().NullToDbNull() });
                                conditions.Add("p." + item.field + " " + SearchOperToSqlOper(item.op) + " " + paramName);

                                break;
                            
                            
                                
                            
                          
                           
                                
                            case DbType.Time:

                            case DbType.Single:
                            case DbType.Int16:
                            case DbType.UInt16:
                            case DbType.Int32:
                            case DbType.UInt32:
                                ParamList.Add(new SqlParameter(paramName, type.Value) { Value = item.data.ToInt().NullToDbNull() });
                                conditions.Add("p." + item.field + " " + SearchOperToSqlOper(item.op) + " " + paramName);

                                break;
                            case DbType.Int64:
                            case DbType.UInt64:
                                ParamList.Add(new SqlParameter(paramName, type.Value) { Value = item.data.ToLong().NullToDbNull() });
                                conditions.Add("p." + item.field + " " + SearchOperToSqlOper(item.op) + " " + paramName);

                                break;
                            case DbType.VarNumeric:
                            case DbType.Object:
                            case DbType.SByte:
                            case DbType.Xml:
                            case DbType.Byte:
                            case DbType.AnsiString:
                            case DbType.AnsiStringFixedLength:
                            case DbType.Binary:
                            case DbType.Currency:
                            case DbType.String:
                            case DbType.StringFixedLength:
                            default:
                                ParamList.Add(new SqlParameter(paramName, DbType.String) { Value = SearchOptionValue(item.op, item.data).NullToDbNull() });
                                conditions.Add("p." + item.field + " " + SearchOperToSqlOper(item.op) + " " + paramName);

                                break;
                        }
                        

                    }
                }
            }
            else
                if (where.groups.HasValue())
                {
                    foreach (var item in where.groups)
                    {
                        conditions.Add(getFiltersConditions<T>(item, ParamList, dbTypes));
                    }
                }
            if (conditions.Count == 0)
                return "";
            return "(" + string.Join(" " + where.groupOp + " ", conditions.Where(o => o.HasValue())) + ")";
        }
        public static Dictionary<string, DbType> SqlDbTypes<T>(string GridName)
        {
            var p = ST.Web.Service.Services.JqGridUtils.JqGridParams<T>(GridName);
            var parameters = new Dictionary<string, DbType>();
            foreach (var item in p)
            {
                if (parameters.ContainsKey(item.Property.Name) == false)
                    parameters.Add(item.Property.Name, Utility.GetDbType(item.Property.PropertyType));
                if (item.Attribute.BdName.HasValue() && parameters.ContainsKey(item.Attribute.BdName) == false)
                    parameters.Add(item.Attribute.BdName, parameters[item.Property.Name]);
            }

            return parameters;

        }
        public jsGridResponce GetSelect<T>(RequestParams param, string gridName, string additionalCondition = null, string joinOutsideContidions = "", string joinInsideConditions = "", string select = "pp.*")
        {
            var responce = new jsGridResponce();
            if (param.filters.HasValue() && param.Where == null)
                param.Where = Filter.Create(param.filters);
            responce.Params = new List<SqlParameter>();
            var props = Utility.PropertyNames<T>();
            var sidx = (param.sidx == null || props.Count(o => o.ToLower() == param.sidx.ToLower()) > 0);
            var searchField = (param.searchField == null || props.Count(o => o.ToLower() == param.searchField.ToLower()) > 0);
            var sord = (param.sord == null || param.sord.ToLower() == "asc" || param.sord.ToLower() == "desc");
            if (sidx && searchField && sord)
            {
                var orderSelect = param.sidx + " " + (param.sord != null ? param.sord : "");
                var startRow = (param.page - 1) * param.rows;
                var stopRow = startRow + param.rows;

                responce.Select = @"
SELECT " + select + @" 
FROM " + TableName + @" pp
JOIN 
(SELECT p." + IdName + @", rownum= ROW_NUMBER() over(order by p." + orderSelect + @")
FROM " + TableName + " p " + joinInsideConditions + " where p." + IdName + " IS NOT NULL";
                if (param._search.HasValue && param._search.Value && param.searchField.HasValue())
                {
                    responce.Select += " AND p." + param.searchField + " " + SearchOperToSqlOper(param.searchOper) + " @search";
                    responce.Params.Add(new SqlParameter("@Search", DbType.String) { Value = SearchOptionValue(param.searchOper, param.searchString) });
                }
                if (param._search.HasValue && param._search.Value && param.searchField.IsNullOrEmpty() && param.filters.HasValue() && param.Where != null)
                {
                    var dbTypes = jqGridRequest.SqlDbTypes<T>(gridName);
                    var filter = getFiltersConditions<T>(param.Where, responce.Params, dbTypes);
                    if (filter.HasValue())
                    responce.Select += " and " + filter;
                }
                if (!string.IsNullOrEmpty(additionalCondition))
                    responce.Select += " AND " + additionalCondition;

                responce.Select += " ) eelist ON eelist." + IdName + " = pp." + IdName + " " + joinOutsideContidions +
                   " WHERE eelist.rownum BETWEEN " + startRow + " AND " + stopRow;

                responce.Select += " order by eelist.rownum";
                return responce;

            }
            return null; //Protection for sql injection, sidx, sort or searchField is not in column list
        }
        public jsGridResponce GetSelectCount<T>(RequestParams param, string gridName, string additionalCondition = null, string Join = "")
        {
            var responce = new jsGridResponce();
            var props = Utility.PropertyNames<T>();
            var sidx = (param.sidx == null || props.Count(o => o.ToLower() == param.sidx.ToLower()) > 0);
            var searchField = (param.searchField == null || props.Count(o => o.ToLower() == param.searchField.ToLower()) > 0);
            var sord = (param.sord == null || param.sord.ToLower() == "asc" || param.sord.ToLower() == "desc");
            if (param.filters.HasValue() && param.Where == null)
                param.Where = Filter.Create(param.filters);

            if (sidx && searchField && sord)
            {
                var orderSelect = param.sidx + " " + (param.sord != null ? param.sord : "");
                var startRow = (param.page - 1) * param.rows;
                var stopRow = startRow + param.rows;
                responce.Params = new List<SqlParameter>();
                responce.Select = @"
SELECT count(p." + IdName + @") Count
FROM " + TableName + " p " + Join +
" WHERE p." + IdName + " IS NOT NULL";
                //if ((param._search.HasValue && param._search.Value) || (!string.IsNullOrEmpty(additionalCondition)))
                //    responce.Select += " WHERE ";

                if (param._search.HasValue && param._search.Value && param.searchField.HasValue())
                {
                    responce.Select += " AND p." + param.searchField + " " + SearchOperToSqlOper(param.searchOper) + " @search";
                    responce.Params.Add(new SqlParameter("@Search", DbType.String) { Value = param.searchString });
                }
                if (param._search.HasValue && param._search.Value && param.searchField.IsNullOrEmpty() && param.filters.HasValue() && param.Where != null)
                {
                    var dbTypes = jqGridRequest.SqlDbTypes<T>(gridName);
                    var filter = getFiltersConditions<T>(param.Where, responce.Params, dbTypes);
                    if (filter.HasValue())
                        responce.Select += " and " + filter;
                }
                if (!string.IsNullOrEmpty(additionalCondition))
                    responce.Select += " AND " + additionalCondition;

                return responce;

            }
            return null; //Protection for sql injection, sidx, sort or searchField is not in column list
        }

        public string TableName { get; private set; }
        public string IdName { get; set; }

        public static string SearchOperToSqlOper(string searchOper)
        {
            switch (searchOper)
            {
                case "eq":
                    return "=";
                case "ne":
                    return "<>";
                case "lt":
                    return "<";
                case "le":
                    return "<=";
                case "gt":
                    return ">";
                case "ge":
                    return ">=";
                case "bw":
                    return "LIKE";
                case "bn":
                    return "NOT LIKE";
                case "in":
                    return "LIKE";
                case "ni":
                    return "NOT LIKE";
                case "ew":
                    return "LIKE";
                case "en":
                    return "NOT LIKE";
                case "cn":
                    return "LIKE";
                case "nc":
                    return "NOT LIKE";
                default:
                    return "=";
            }
            //    'eq'=>'=', //equal
            //'ne'=>'<>',//not equal
            //'lt'=>'<', //less than
            //'le'=>'<=',//less than or equal
            //'gt'=>'>', //greater than
            //'ge'=>'>=',//greater than or equal
            //'bw'=>'LIKE', //begins with
            //'bn'=>'NOT LIKE', //doesn't begin with
            //'in'=>'LIKE', //is in
            //'ni'=>'NOT LIKE', //is not in
            //'ew'=>'LIKE', //ends with
            //'en'=>'NOT LIKE', //doesn't end with
            //'cn'=>'LIKE', // contains
            //'nc'=>'NOT LIKE'  //doesn't contain
        }
        public static string SearchOptionValue(string searchOper, string value)
        {
            if (value.HasValue() == false)
                return "";
            if (searchOper == "bw" || searchOper == "bn") value = value + "%";
            if (searchOper == "ew" || searchOper == "en") value = "%" + value;
            if (searchOper == "cn" || searchOper == "nc" || searchOper == "in" || searchOper == "ni") value = "%" + value + "%";
            return value;
        }

    }

    public class JqGridUtils
    {
        public static PropertyInfo[] ListProperty(Type Obj)
        {
            return Obj.GetProperties();
        }
        public static List<JqGridColumnDefenition> JqGridParams<T>(string GridName)
        {
            var Properties = ListProperty(typeof(T)).Where(o => o.GetCustomAttributes(typeof(JqGridColumnAttribute)).Any());
            var parameters = new List<JqGridColumnDefenition>();
            foreach (var prop in Properties)
            {
                var attrs = from jqc in prop.GetCustomAttributes(true)
                            where jqc is JqGridColumnAttribute
                            select (JqGridColumnAttribute)jqc;
                var atribute = attrs.FirstOrDefault(o => o.GridName == GridName);
                if (atribute != null)
                {
                    var displayName = prop.GetCustomAttribute(typeof(System.ComponentModel.DisplayNameAttribute));
                    //var val = prop.GetValue(EntityItem);
                    var name = prop.Name;
                    var title = displayName != null ? ((System.ComponentModel.DisplayNameAttribute)displayName).DisplayName : name;
                    var resVal = ST.Web.Service.Config.NamesResourceManager.GetString(title);
                    if (resVal.HasValue())
                        title = resVal;
                    if (atribute.BdName.IsNullOrEmpty())
                        atribute.BdName = name;

                    parameters.Add(new JqGridColumnDefenition
                    {
                        Attribute = atribute,
                        DisplayTitle = title,
                        Property = prop
                    });
                }
            }

            return parameters;

        }

    }
    public class JqGridColumnDefenition
    {
        public JqGridColumnAttribute Attribute { get; set; }
        public PropertyInfo Property { get; set; }
        public string DisplayTitle { get; set; }
       
    }
}