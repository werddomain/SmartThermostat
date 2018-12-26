using ST.Web.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web
{
    public class QueryReturn
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    public class QueryResult
    {
        public QueryResult()
        {
            this.QueryResultMsgs = new List<QueryResultMsg>();
        }

        public bool Success { get; set; }
        public string CustomReturn { get; set; }

        public void LoadErrorsMessages(string errorFromSqlServer)
        {
            QueryResultMsgs = new List<QueryResultMsg>();

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

                QueryResultMsgs.Add(new QueryResultMsg() { MsgKey = propArray[0], MsgType = propArray[1], Message = propArray[2], EntityId = propArray[3] });
            }
        }

        //public void UpdateEntityFromResult(CSEntity entity)
        //{
        //    if (this.QueryResultMsgs.Any())
        //        entity.Errors = ST.Web.Service.Utility.LoadErrorsMessages(this.QueryResultMsgs, "|");
        //    if (!this.Success) { entity.CSEntityState = CSEntityState.IsInError; }

        //}

        public List<QueryResultMsg> QueryResultMsgs { get; set; }
    }
    public class QueryResultMsg : IEqualityComparer<QueryResultMsg>
    {
        public string MsgKey { get; set; }
        public string MsgType { get; set; }
        public string Message { get; set; }
        public string EntityId { get; set; }

        public bool Equals(QueryResultMsg x, QueryResultMsg y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            if (x.MsgType == y.MsgType && x.Message == y.Message && x.MsgKey == y.MsgKey)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(QueryResultMsg obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 0;

            int hashKey = obj.MsgKey.GetHashCode();
            int hashType = obj.MsgType.GetHashCode();
            int hastMessage = obj.Message.GetHashCode();

            return hashKey ^ hashType ^ hastMessage;
        }
    }

}