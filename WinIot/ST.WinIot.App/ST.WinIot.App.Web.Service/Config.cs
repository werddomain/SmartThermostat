using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace ST.Web.Service
{
    public static class Config
    {

        public static System.Resources.ResourceManager NamesResourceManager { get; private set; }
        public static Type NamesResourceType { get; private set; }
        public static System.Resources.ResourceManager ValidationResourceManager { get; private set; }
        public static Type ValidationResourceType { get; private set; }
        public static string ConnectionString { get; private set; }
        internal static Func<string, DbConnection> getConnection = (ConnectionString) => { return (DbConnection)new SqlConnection(ConnectionString); };

        public static System.Resources.ResourceManager SqlMessageResourceManager { get; private set; }
        public static Type SqlMessageResourceType { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString">The SQL connection string </param>
        /// <param name="nameResource">Where all field names will be resolved</param>
        /// <param name="validationResource">Where formated validation message will be resolved</param>
        /// <param name="sqlMessagesResource">(Optional) Where all sql error message will be resolved. This is use as a return from stored procedures. If you set the @prMsg = "0~ERR~ResourceKey~[EntityId]", the ResourceKey will be replaced by the resource string. EntityId is optional, this is the Id of the row who has error.</param>
        /// <param name="getConnection">(Optional) Let you specify wish DbConnection to use from a connection string. Default is (ConnectionString) => { return (DbConnection)new SqlConnection(ConnectionString); }</param>
        public static void Use(string connectionString, ResourceHolder nameResource, ResourceHolder validationResource,
            ResourceHolder sqlMessagesResource, Func<string, DbConnection> getDbConnection = null)
        {

            ConnectionString = connectionString;
            NamesResourceManager = nameResource.ResourceManager;
            NamesResourceType = nameResource.ResourceType;
            ValidationResourceManager = validationResource.ResourceManager;
            ValidationResourceType = validationResource.ResourceType;
            SqlMessageResourceManager = sqlMessagesResource.ResourceManager;
            SqlMessageResourceType = sqlMessagesResource.ResourceType;
            if (getDbConnection != null)
            {
                getConnection = getDbConnection;
            }
        }
        public static Func<string, DbConnection> GetConnection
        {
            get
            {
                return getConnection;
            }
        }

      
    }
    public class ResourceHolder
    {


        public System.Resources.ResourceManager ResourceManager { get; private set; }
        public Type ResourceType { get; private set; }

        public void Set<T>(T resource, System.Resources.ResourceManager resourceManager)
        {
            ResourceType = typeof(T);
            ResourceManager = resourceManager;
        }
        public static ResourceHolder Get<T>(System.Resources.ResourceManager resourceManager)
        {
            return new ResourceHolder
            {
                ResourceManager = resourceManager,
                ResourceType = typeof(T)
            };
        }
    }
}
