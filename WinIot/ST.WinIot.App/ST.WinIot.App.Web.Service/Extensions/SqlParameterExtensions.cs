using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ST.Web.Service
{
    public static class SqlParameterExtensions
    {
        public static SqlParameter Clone(this SqlParameter p)
        {
            return new SqlParameter
            {
                CompareInfo = p.CompareInfo,
                DbType = p.DbType,
                Direction = p.Direction,
                IsNullable = p.IsNullable,
                LocaleId = p.LocaleId,
                Offset = p.Offset,
                ParameterName = p.ParameterName,
                Precision = p.Precision,
                Scale = p.Scale,
                Size = p.Size,
                SourceColumn = p.SourceColumn,
                SourceColumnNullMapping = p.SourceColumnNullMapping,
                SqlDbType = p.SqlDbType,
                SqlValue = p.SqlValue,
                TypeName = p.TypeName,
                Value = p.Value,
                XmlSchemaCollectionDatabase = p.XmlSchemaCollectionDatabase,
                XmlSchemaCollectionName = p.XmlSchemaCollectionOwningSchema
            };
        }
    }
}
