using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading;

using System.Threading.Tasks;


using System.Text;

using System.Web;



namespace ST.Web.Service
{
    public class Utility
    {
        /// -------------------------------------------------------------------------------------
        /// Méthode: NullToDBNull
        /// -------------------------------------------------------------------------------------
        /// <summary>
        ///   Transforme la valeur spécifiée en une valeur DBNull si elle est égale à null.
        /// </summary>
        /// <param name="value">
        ///   Valeur à évaluer.
        /// </param>
        /// <returns>
        ///   Retourne DBNull si le paramètre "value" est null. Sinon, retourne la valeur 
        ///   originale du paramètre "value".
        /// </returns>
        /// -------------------------------------------------------------------------------------
        public static object NullToDBNull(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }
        
       

        private static string CSConnectionString = Config.ConnectionString;


        public static DbConnection GetConnection()
        {
            return Config.GetConnection(Config.ConnectionString);
//#if (DEBUG)
//            return new ProfiledDbConnection(new SqlConnection(CSConnectionString), MiniProfiler.Current);

//#else
//            return (DbConnection)new SqlConnection(CSConnectionString);
//#endif

        }
        public static bool ExecSPAvecMsg(List<SqlParameter> ParamList, string SPName, Object EntityItem, Guid? userId, string cdLang, int timeout = 200, bool throwException = true)
        {
            bool returnvalue = true;
            using (DbConnection conn = GetConnection())
            {
                conn.Open();
                using (DbCommand command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = timeout;

                    SqlParameter paramMsg = new SqlParameter("@prMsg", DbType.String);
                    paramMsg.DbType = DbType.String;
                    paramMsg.Size = -1;
                    paramMsg.Direction = ParameterDirection.Output;
                    command.Parameters.Add(paramMsg);

                    command.Parameters.Add(new SqlParameter("@pUserId", DbType.Guid)
                    {
                        Value = userId
                    });
                    command.Parameters.Add(new SqlParameter("@pLang", DbType.String)
                    {
                        Value = cdLang
                    });

                    if (ParamList != null)
                    {
                        foreach (SqlParameter item in ParamList)
                        {
                            command.Parameters.Add(item);
                        }
                    }

                    command.CommandText = SPName;
                    command.ExecuteNonQuery();
                    if (throwException)
                    {
                        if (paramMsg.Value != DBNull.Value && !string.IsNullOrEmpty((string)paramMsg.Value))
                        {
                            returnvalue = false;
                            throw new ValidationException(new ValidationResult(paramMsg.Value.ToString()), null, EntityItem);

                            //throw new Exception("Super, ça marche tempête");

                        }
                    }
                    command.Parameters.Clear();
                }
            }
            return returnvalue;
        }
        public static QueryReturn ExecSP(List<SqlParameter> ParamList, string SPName, Object EntityItem, string cdLang, int timeout = 200, bool throwException = true)
        {
            QueryReturn queryReturn = new QueryReturn() { Success = true };
            using (DbConnection conn = GetConnection())
            {
                conn.Open();
                using (DbCommand command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = timeout;

                    SqlParameter paramMsg = new SqlParameter("@prMsg", DbType.String);
                    paramMsg.DbType = DbType.String;
                    paramMsg.Size = -1;
                    paramMsg.Direction = ParameterDirection.Output;
                    command.Parameters.Add(paramMsg);

                    command.Parameters.Add(new SqlParameter("@pLang", DbType.String)
                    {
                        Value = cdLang
                    });

                    if (ParamList != null)
                    {
                        foreach (SqlParameter item in ParamList)
                        {
                            command.Parameters.Add(item);
                        }
                    }

                    command.CommandText = SPName;
                    command.ExecuteNonQuery();
                    if (throwException)
                    {
                        if (paramMsg.Value != DBNull.Value && !string.IsNullOrEmpty((string)paramMsg.Value))
                        {
                            queryReturn.Success = false;
                            queryReturn.Message = paramMsg.Value.ToString();
                        }
                    }
                    command.Parameters.Clear();
                }
            }
            return queryReturn;
        }
        public static async Task<QueryResult> ExecSPAsync(CancellationToken cancelToken, Guid userId, string language, List<SqlParameter> ParamList, string SPName = "", int timeout = 200, bool addBaseParam = true)
        {
            QueryResult queryResult = new QueryResult() { Success = true };
            using (DbConnection conn = GetConnection())
            {
                await conn.OpenAsync(cancelToken);
                using (DbCommand command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = timeout;
                    SqlParameter paramMsg = new SqlParameter("@prMsg", DbType.String);
                    paramMsg.Value = DBNull.Value;

                    if (addBaseParam)
                    {

                        paramMsg.DbType = DbType.String;
                        paramMsg.Size = -1;
                        paramMsg.Direction = ParameterDirection.Output;
                        command.Parameters.Add(paramMsg);

                        command.Parameters.Add(new SqlParameter("@pUserId", DbType.Guid)
                        {
                            Value = userId
                        });

                        command.Parameters.Add(new SqlParameter("@pLang", DbType.String)
                        {
                            Value = language
                        });

                    }
                    if (ParamList != null)
                    {
                        foreach (SqlParameter item in ParamList)
                        {
                            command.Parameters.Add(item);
                        }
                    }

                    command.CommandText = SPName;
                    await command.ExecuteNonQueryAsync(cancelToken);

                    if (paramMsg.Value != DBNull.Value)
                    {
                        if (!string.IsNullOrEmpty((string)paramMsg.Value))
                        {
                          
                            queryResult.LoadErrorsMessages((string)paramMsg.Value);
                            if (queryResult.QueryResultMsgs.Count(a => a.MsgType == "ERR") > 0)
                            {
                                queryResult.Success = false;
                            }
                        }
                    }

                    command.Parameters.Clear();
                }
            }
            return queryResult;
        }


        public static void ExecSqlAndReturnObjList<T>(List<SqlParameter> ParamList, string SqlCommand, ref List<T> ObjectList, bool isStorProc = false)
        {
            using (DbConnection conn = GetConnection())
            {
                conn.Open();
                using (DbCommand command = conn.CreateCommand())
                {
                    if (isStorProc)
                        command.CommandType = CommandType.StoredProcedure;
                    else
                        command.CommandType = CommandType.Text;


                    command.CommandTimeout = 200;
                    if (ParamList != null)
                    {
                        foreach (SqlParameter item in ParamList)
                        {
                            command.Parameters.Add(item);
                        }
                    }
                    command.CommandText = SqlCommand;
                    using (DbDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ObjectList.Add(GetAs<T>(dr));
                        }
                    }
                    command.Parameters.Clear();
                }
            }
        }



        public static T DoSelectTop1<T>(List<SqlParameter> ParamList, string SqlCommand, bool isStorProc = false, int timeOut = 200)
        {
            var list = DoSelect<T>(ParamList, SqlCommand, isStorProc, timeOut);
            if (list != null && list.Any())
                return list.FirstOrDefault();
            else
                return default(T);
        }

        public static List<T> DoSelect<T>(List<SqlParameter> ParamList, string SqlCommand, bool isStorProc = false, int timeOut = 200, bool isValueType = false)
        {
            var ObjectList = new List<T>();

            //var connBuilder = new SqlConnectionStringBuilder(CSConnectionString);
            //connBuilder.AsynchronousProcessing = true;

            using (DbConnection conn = GetConnection())
            {
                conn.Open();
                using (DbCommand command = conn.CreateCommand())
                {
                    if (isStorProc)
                        command.CommandType = CommandType.StoredProcedure;
                    else
                        command.CommandType = CommandType.Text;


                    command.CommandTimeout = timeOut;
                    if (ParamList != null)
                    {
                        foreach (SqlParameter item in ParamList)
                        {
                            command.Parameters.Add(item);
                        }
                    }
                    command.CommandText = SqlCommand;

                    var exReader = command.ExecuteReader();

                    using (DbDataReader dr = exReader)
                    {
                        if (isValueType)
                        {
                            while (dr.Read())
                            {
                                if ((dr[0] == DBNull.Value))
                                {
                                    ObjectList.Add(default(T));
                                }
                                else
                                    
                                ObjectList.Add((T)dr[0]);
                            }
                        }
                        else
                        {
                            while (dr.Read())
                            {
                                ObjectList.Add(GetAs<T>(dr));
                            }
                        }
                    }

                    command.Parameters.Clear();
                }
            }

            return ObjectList;
        }

        public static List<string> GetColumnList(DbDataReader reader)
        {

            List<string> columnList = new List<string>();

            var readerSchema = reader.GetColumnSchema();

            for (int i = 0; i < readerSchema.Count; i++)

                columnList.Add(readerSchema[i].ColumnName);

            return columnList;

        }

        public static T GetAs<T>(DbDataReader reader)
        {
            T newObjectToReturn = Activator.CreateInstance<T>();
            PropertyInfo[] props = GetCachedProperties<T>();
            List<string> columnList = GetColumnList(reader);
            for (int i = 0; i < props.Length; i++)
            {
                if (columnList.Contains(props[i].Name) && reader[props[i].Name] != DBNull.Value)
                {
                    var value = reader[props[i].Name];
                    var type = props[i].PropertyType;
                    if (type == typeof(DateTime) || type == typeof(DateTime?))
                                        value = DateTime.SpecifyKind((DateTime)value, DateTimeKind.Utc);
                    //Si une erreur se produit ici, c'est soit qu'il ne trouve pas la method ou que le type de la bd ne correspond pas au type de la methode
                    //typeof(T).InvokeMember(props[i].Name, BindingFlags.SetProperty, null, newObjectToReturn, new Object[] { value });
                    MethodInfo method = typeof(T).GetTypeInfo().GetDeclaredMethod(props[i].Name);
                    method.Invoke(newObjectToReturn, new Object[] { value });
                }
            }
            return newObjectToReturn;
        }

        private static IDictionary<string, PropertyInfo[]> propertiesCache = new Dictionary<string, PropertyInfo[]>();

        private static ReaderWriterLockSlim propertiesCacheLock = new ReaderWriterLockSlim();

        public static PropertyInfo[] GetCachedProperties<T>()
        {
            PropertyInfo[] props = new PropertyInfo[0];
            if (propertiesCacheLock.TryEnterUpgradeableReadLock(100))
            {
                try
                {
                    if (!propertiesCache.TryGetValue(typeof(T).FullName, out props))
                    {
                        props = typeof(T).GetProperties();
                        if (propertiesCacheLock.TryEnterWriteLock(100))
                        {
                            try
                            {
                                propertiesCache.Add(typeof(T).FullName, props);
                            }
                            finally
                            {
                                propertiesCacheLock.ExitWriteLock();
                            }
                        }
                    }
                }

                finally
                {
                    propertiesCacheLock.ExitUpgradeableReadLock();
                }
                return props;
            }
            else
            {
                return typeof(T).GetProperties();
            }
        }





        public static async Task<T> DoSelectTop1Async<T>(List<SqlParameter> ParamList, string SqlCommand, CancellationToken cancelToken, bool isStorProc = false, int timeOut = 200, bool isValueType = false)
        {
            var list = await DoSelectAsync<T>(ParamList, SqlCommand, cancelToken, isStorProc, timeOut, isValueType);
            if (list != null && list.Any())
                return list.FirstOrDefault();
            else
                return default(T);
        }



        public static async Task<List<T>> DoSelectAsync<T>(List<SqlParameter> ParamList, string SqlCommand, CancellationToken cancelToken, bool isStorProc = false, int timeOut = 200, bool isValueType = false)
        {
            var ObjectList = new List<T>();

            //var connBuilder = new SqlConnectionStringBuilder(CSConnectionString);
            //connBuilder.AsynchronousProcessing = true;

            using (DbConnection conn = GetConnection())
            {
                await conn.OpenAsync(cancelToken);
                using (DbCommand command = conn.CreateCommand())
                {
                    if (isStorProc)
                        command.CommandType = CommandType.StoredProcedure;
                    else
                        command.CommandType = CommandType.Text;


                    command.CommandTimeout = timeOut;
                    if (ParamList != null)
                    {
                        foreach (SqlParameter item in ParamList)
                        {
                            command.Parameters.Add(item);
                        }
                    }
                    command.CommandText = SqlCommand;
                    try
                    {
                        var exReader = command.ExecuteReaderAsync(cancelToken);


                        using (DbDataReader dr = await exReader)
                        {
                            if (isValueType)
                            {
                                while (dr.Read())
                                {
                                    if ((dr[0] == DBNull.Value))
                                    {
                                        ObjectList.Add(default(T));
                                    }
                                    else
                                    ObjectList.Add((T)dr[0]);
                                }
                            }
                            else
                            {
                                while (dr.Read())
                                {
                                    ObjectList.Add(GetAs<T>(dr));
                                }
                            }
                        }

                        command.Parameters.Clear();
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                   
                }
            }

            return ObjectList;
        }
      
        public static async Task<QueryResult> ExecDEAsync<TEntity, TId>(CancellationToken cancelToken, Guid userId, string language, string SPName = "", List<SqlParameter> ParamList = null, int timeout = 200) where TEntity : CSEntity
        {
            
            return await ExecMJAsync<TEntity, TId>(null, cancelToken, userId, language, SPName, ParamList, timeout);
        }
        public static async Task<QueryResult> ExecMJAsync<TEntity, TId>(TEntity entity, CancellationToken cancelToken, Guid userId, string language, string SPName = "", List<SqlParameter> ParamList = null, int timeout = 200) where TEntity : CSEntity
        {
            if (language.IsNullOrEmpty())
                language = "en";

            string prefix = "MJ_";

            CSEntityState state = CSEntityState.IsDeleted;

            if (entity != null)
                state = entity.CSEntityState;

            if (state == CSEntityState.IsDeleted)
                prefix = "DE_";

            if (SPName == "")
            {
                SPName = prefix + typeof(TEntity).Name + "s";
            }

            if (ParamList == null)
                ParamList = Utility.SqlParams<TEntity>(entity);


            QueryResult queryResult = new QueryResult() { Success = true };

            using (DbConnection conn = GetConnection())
            {
                await conn.OpenAsync(cancelToken);
                using (DbCommand command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = timeout;
                    command.CommandText = SPName;

                    SqlParameter prMsg = new SqlParameter("@prMsg", DbType.String)
                    {
                        DbType = DbType.String,
                        Size = -1,
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(prMsg);

                    SqlParameter prId = new SqlParameter("@prId", DbType.String)
                    {
                        DbType = DbType.String,
                        Size = -1,
                        Direction = ParameterDirection.Output
                    };

                    if (ParamList.Count(o=>o.ParameterName == "@pUserId") == 0)
                    command.Parameters.Add(new SqlParameter("@pUserId", DbType.Guid)
                    {
                        Value = userId
                    });
                    command.Parameters.Add(new SqlParameter("@pLang", DbType.String)
                    {
                        Value = language
                    });


                    switch (state)
                    {
                        case CSEntityState.IsNew:
                            command.Parameters.Add(new SqlParameter("@pOper", DbType.String) { Value = "AJ" });
                            command.Parameters.Add(prId);
                            break;
                        case CSEntityState.IsEdited:
                            command.Parameters.Add(new SqlParameter("@pOper", DbType.String) { Value = "MO" });
                            command.Parameters.Add(prId);
                            break;
                        case CSEntityState.IsDeleted:
                            break;
                    }

                    if (ParamList != null)
                    {
                        foreach (SqlParameter item in ParamList)
                        {
                            command.Parameters.Add(item);
                        }
                    }
                   
                        await command.ExecuteNonQueryAsync(cancelToken);
                   
                    
                    
                    if (prMsg.Value != DBNull.Value && !string.IsNullOrEmpty((string)prMsg.Value))
                    {
                       
                        queryResult.LoadErrorsMessages((string)prMsg.Value);
                        if (queryResult.QueryResultMsgs.Count(a => a.MsgType == "ERR") > 0)
                        {
                            queryResult.Success = false;
                        }
                        if (Config.SqlMessageResourceManager != null)
                        foreach (var msg in queryResult.QueryResultMsgs)
                        {
                            var m = Config.SqlMessageResourceManager.GetString(msg.Message);
                            if (!string.IsNullOrEmpty(m))
                                msg.Message = m;
                        }
                    }

                    if (state == CSEntityState.IsNew)
                    {
                        if (prId.Value != DBNull.Value && !string.IsNullOrEmpty((string)prId.Value))
                        {
                            entity.EntityId = prId.Value.ToString();
                        }
                    }

                    command.Parameters.Clear();
                }
            }
            return queryResult;
        }

        public static QueryResult ExecDE<TEntity, TId>(Guid userId, string language, string SPName = "", List<SqlParameter> ParamList = null, int timeout = 200) where TEntity : CSEntity
        {
            return ExecMJ<TEntity, TId>(null, userId, language, SPName, ParamList, timeout);
        }
        public static QueryResult ExecMJ<TEntity, TId>(TEntity entity, Guid userId, string language, string SPName = "", List<SqlParameter> ParamList = null, int timeout = 200) where TEntity : CSEntity
        {
            string prefix = "MJ_";

            CSEntityState state = CSEntityState.IsDeleted;

            if (entity != null)
                state = entity.CSEntityState;

            if (state == CSEntityState.IsDeleted)
                prefix = "DE_";

            if (SPName == "")
            {
                SPName = prefix + typeof(TEntity).Name + "s";
            }

            if (ParamList == null)
                ParamList = Utility.SqlParams<TEntity>(entity);


            QueryResult queryResult = new QueryResult() { Success = true };

            using (DbConnection conn = GetConnection())
            {
                conn.Open();
                using (DbCommand command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = timeout;
                    command.CommandText = SPName;

                    SqlParameter prMsg = new SqlParameter("@prMsg", DbType.String)
                    {
                        DbType = DbType.String,
                        Size = -1,
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(prMsg);

                    SqlParameter prId = new SqlParameter("@prId", DbType.String)
                    {
                        DbType = DbType.String,
                        Size = -1,
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(new SqlParameter("@pUserId", DbType.Guid)
                    {
                        Value = userId
                    });
                    command.Parameters.Add(new SqlParameter("@pLang", DbType.String)
                    {
                        Value = language
                    });


                    switch (state)
                    {
                        case CSEntityState.IsNew:
                            command.Parameters.Add(new SqlParameter("@pOper", DbType.String) { Value = "AJ" });
                            command.Parameters.Add(prId);
                            break;
                        case CSEntityState.IsEdited:
                            command.Parameters.Add(new SqlParameter("@pOper", DbType.String) { Value = "MO" });
                            command.Parameters.Add(prId);
                            break;
                        case CSEntityState.IsDeleted:
                            break;
                    }

                    if (ParamList != null)
                    {
                        foreach (SqlParameter item in ParamList)
                        {
                            command.Parameters.Add(item);
                        }
                    }

                    command.ExecuteNonQuery();

                    if (prMsg.Value != DBNull.Value && !string.IsNullOrEmpty((string)prMsg.Value))
                    {
                        
                        queryResult.LoadErrorsMessages((string)prMsg.Value);
                        if (queryResult.QueryResultMsgs.Count(a => a.MsgType == "ERR") > 0)
                        {
                            queryResult.Success = false;
                        }
                    }

                    if (state == CSEntityState.IsNew)
                    {
                        if (prId.Value != DBNull.Value && !string.IsNullOrEmpty((string)prId.Value))
                        {
                            entity.EntityId = prId.Value.ToString();
                        }
                    }

                    command.Parameters.Clear();
                }
            }
            return queryResult;
        }

        //public void InsertData<T>(List<T> list, string TabelName)
        //     where T : CSEntity
        //{
        //    DataTable dt = new DataTable(TabelName);
            
        //    dt = ConvertToDataTable(list);
        //    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
        //    using (SqlBulkCopy bulkcopy = new SqlBulkCopy(CSConnectionString))
        //    {
        //        bulkcopy.BulkCopyTimeout = 660;
        //        bulkcopy.DestinationTableName = TabelName;
        //        bulkcopy.WriteToServer(dt);
        //    }
        //}

        //public static DataTable ConvertToDataTable<T>(IEnumerable<T> data)
        //    where T : CSEntity
        //{
        //    var properties = ListProperty(typeof(T)).Where(o => o.GetCustomAttributes(typeof(CSBDAttribute)).Any());

        //    DataTable table = new DataTable();
        //    foreach (var prop in properties)
        //        table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        //    foreach (T item in data)
        //    {
        //        DataRow row = table.NewRow();
        //        foreach (var prop in properties)
        //            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
        //        table.Rows.Add(row);
        //    }
        //    return table;
        //}


        public enum OperationEnum
        {
            Insert, Update, Delete
        }

        public static PropertyInfo[] ListProperty<t>(t Obj)
        {
            return Obj.GetType().GetProperties();
        }

        public static PropertyInfo[] ListProperty(Type Obj)
        {
            return Obj.GetProperties();
        }

        public static List<SqlParameter> SqlParams<T>(T EntityItem)
        {
            var Properties = ListProperty(typeof(T)).Where(o => o.GetCustomAttributes(typeof(CSBDAttribute)).Any());
            var parameters = new List<SqlParameter>();
            foreach (var item in Properties)
            {
                var val = item.GetValue(EntityItem);
                parameters.Add(new SqlParameter("@p" + item.Name, GetDbType(item.PropertyType)) { Value = NullToDBNull(val) });
            }

            return parameters;

        }
        
        public static IEnumerable<string> PropertyNames<T>()
        {
            var Properties = ListProperty(typeof(T));
            return (from e in Properties
                    select e.Name);
        }
        public static DbType GetDbType(Type type)
        {
            //if (type == typeof(CSHtmlString))
            //    return DbType.String;
            if (type == typeof(string))
                return DbType.String;

            if (type == typeof(short) || type == typeof(Int16) || type == typeof(UInt16))
                return DbType.Int16;

            if (type == typeof(Int32) || type == typeof(int))
                return DbType.Int32;

            if (type == typeof(Int64) || type == typeof(long))
                return DbType.Int64;

            if (type == typeof(Boolean) || type == typeof(bool))
                return DbType.Boolean;

            if (type == typeof(double) || type == typeof(Double) || type == typeof(decimal) || type == typeof(Decimal))
                return DbType.Double;

            if (type == typeof(Guid))
                return DbType.Guid;

            if (type == typeof(DateTime))
                return DbType.DateTime;

            if (type == typeof(TimeSpan))
                return DbType.Time;

            //########################## Nullable ##############################

            if (type == typeof(short?) || type == typeof(Int16?) || type == typeof(UInt16?))
                return DbType.Int16;

            if (type == typeof(Int32?) || type == typeof(int?))
                return DbType.Int32;

            if (type == typeof(Int64?) || type == typeof(long?))
                return DbType.Int64;


            if (type == typeof(Boolean?) || type == typeof(bool?))
                return DbType.Boolean;

            if (type == typeof(double?) || type == typeof(Double?) || type == typeof(decimal?) || type == typeof(Decimal?))
                return DbType.Double;

            if (type == typeof(Guid?))
                return DbType.Guid;

            if (type == typeof(DateTime?))
                return DbType.DateTime;

            if (type == typeof(TimeSpan?))
                return DbType.Time;


            throw new Exception("The type " + type.ToString() + " is not listed in Utility.GetDbType()");

        }

        public static string LoadErrorsMessages(List<QueryResultMsg> errorFromSqlServer, string splitterForFinalString = "|")
        {
            StringBuilder sb = new StringBuilder();
            // pour chaque message
            foreach (QueryResultMsg msg in errorFromSqlServer)
            {
                sb.Append(msg.Message + splitterForFinalString);
            }
            return sb.ToString();
        }
        public static string LoadErrorsMessages(string errorFromSqlServer)
        {
            StringBuilder sb = new StringBuilder();

            char SeparateurMessages = '|';
            char SeparateurProprietes = '~';

            // séparer les messages en se servant du caractère spécifié
            string[] msgArray = errorFromSqlServer.Split(new char[] { SeparateurMessages },
                StringSplitOptions.RemoveEmptyEntries);
            // pour chaque message
            foreach (string msg in msgArray)
            {
                // séparer les propriétés du message en se servant du caractère spécifié
                string[] propArray = msg.Split(SeparateurProprietes);
                // vérifier qu'il y a bien 3 ou 4 propriétés
                if (propArray.Length < 3 || propArray.Length > 4)
                {
                    throw new ArgumentException("La chaîne de messages est incorrecte : " +
                                                msg, "messageString");
                }
                sb.Append(propArray[2]);

            }
            return sb.ToString();
        }

        //public static string GetCsharp(string SQLtype)
        //{
        //    switch (SQLtype.ToLower())
        //    {
        //        case "bigint":
        //            return "Int64";

        //        case "bit":
        //            return "bool";

        //        case "char":
        //            return "String";




        //        case "date":
        //        case "datetime":
        //        case "datetime2":
        //        case "smalldatetime":
        //            return "DateTime";

        //        case "datetimeoffset":
        //            return "DateTimeOffset";

        //        case "float":
        //            return "Double";

        //        case "timestamp":
        //        case "varbinary":
        //        case "rowversion":
        //        case "image":
        //        case "binary":
        //            return "Byte[]";

        //        case "int":
        //            return "Int32";

        //        case "decimal":
        //        case "smallmoney":
        //        case "money":
        //        case "numeric":
        //            return "Decimal";

        //        case "varchar":
        //        case "nchar":
        //        case "ntext":
        //        case "nvarchar":
        //        case "text":
        //            return "String";

        //        case "real":
        //            return "Single";

        //        case "smallint":
        //            return "In16";

        //        case "time":
        //            return "TimeSpan";

        //        case "tinyint":
        //            return "Byte";

        //        case "uniqueidentifier":
        //            return "Guid";

        //        default:
        //            return "";
        //    }
        //}
        // public static string GetSqlDataReaderAccessor(string SQLtype)
        //    {
        //        switch (SQLtype.ToLower())
        //        {



        //            case "bigint":
        //                return "GetInt64";
        //            case "timestamp":
        //            case "binary":
        //                return "GetBytes";

        //            case "bit":
        //                return "GetBoolean";

        //            case "char":
        //                return "GetString";

        //            case "date":
        //            case "datetime":
        //            case "datetime2":
        //            case "smalldatetime":
        //                return "GetDateTime";

        //            case "datetimeoffset":
        //                return "GetDateTimeOffset";

        //            case "float":
        //                return "GetDouble";

        //            case "varbinary":
        //            case "rowversion":
        //            case "image":
        //                return "GetBytes";

        //            case "int":
        //                return "GetInt32";

        //            case "decimal":
        //            case "smallmoney":
        //            case "money":
        //            case "numeric":
        //                return "GetDecimal";

        //            case "varchar":
        //            case "nchar":
        //            case "ntext":
        //            case "nvarchar":
        //            case "text":
        //                return "GetString";

        //            case "real":
        //                return "GetSingle";

        //            case "smallint":
        //                return "GetIn16";




        //            case "time":
        //                return "GetTimeSpan";

        //            case "tinyint":
        //                return "GetByte";

        //            case "uniqueidentifier":
        //                return "GetGuid";


        //            default:
        //                return "";
        //        }
        //    }
        //    public static string GetDBtype(string SQLtype)
        //    {
        //        switch (SQLtype.ToLower())
        //        {
        //            case "bigint":
        //                return "Int64";

        //            case "binary":
        //                return "Binary";

        //            case "bit":
        //                return "Boolean";

        //            case "char":
        //                return "String";

        //            case "date":
        //                return "Date";
        //            case "datetime":
        //                return "DateTime";
        //            case "datetime2":
        //                return "DateTime2";

        //            case "smalldatetime":
        //                return "DateTime";

        //            case "datetimeoffset":
        //                return "DateTimeOffset";

        //            case "float":
        //                return "Double";

        //            case "varbinary":
        //            case "rowversion":
        //            case "image":
        //                return "Binary";

        //            case "int":
        //                return "Int32";

        //            case "decimal":
        //            case "smallmoney":
        //            case "money":
        //            case "numeric":
        //                return "Decimal";

        //            case "nchar":
        //                return "StringFixedLength";

        //            case "varchar":
        //            case "ntext":
        //            case "nvarchar":
        //            case "text":
        //                return "String";

        //            case "real":
        //                return "Single";

        //            case "timestamp":
        //                return "Binary";

        //            case "smallint":
        //                return "In16";

        //            case "time":
        //                return "Time";

        //            case "tinyint":
        //                return "Byte";

        //            case "uniqueidentifier":
        //                return "Guid";

        //            default:
        //                return "";
        //        }
        //}



    }
}