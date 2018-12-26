using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ST.Web.Service
{
    [AttributeUsageAttribute(AttributeTargets.Property, Inherited = true,
    AllowMultiple = true)]
    public class JqGridColumnAttribute:Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="GridName"></param>
        /// <param name="Order"></param>
        /// <param name="Width"></param>
        /// <param name="Visible"></param>
        /// <param name="Sortable"></param>
        /// <param name="Searchable"></param>
        /// <param name="Index"></param>
        /// <param name="bdname"></param>
        /// <param name="HideInColumnChoser"></param>
        /// <param name="IsDateField"></param>
        /// <param name="GID">Use this property only to join the count in JqGrid Select And Count</param>
        public JqGridColumnAttribute(string GridName, int Order, int Width = 60, bool Visible = true, bool Sortable = true, bool Searchable = true, bool Index = false, string bdname = null, bool HideInColumnChoser = false, bool IsDateField = false, bool GID = false)
        {
            this.GridName = GridName;
            this.Visible = Visible;
            this.Sortable = Sortable;
            this.Searchable = Searchable;
            this.Index = Index;
            this.BdName = bdname;
            this.Width = Width;
            this.Order = Order;
            this.HideInColomChoser = HideInColumnChoser;
            this.IsDateField = IsDateField;
            this.GID = GID;
        }
        public bool GID { get; set; }
        public bool IsDateField { get; set; }
        public bool HideInColomChoser { get; set; }
        public int Order { get; set; }
        public string GridName { get; set; }
        public bool Visible { get; set; }
        public bool Index { get; set; }
        
        public bool Sortable { get; set; }
        public bool Searchable { get; set; }

        public string BdName { get; set; }

        public int Width { get; set; }
        /// <summary>
        /// If this is true, the original index key will not be set in the AutoType Id param
        /// </summary>
        public bool AddToSelectId { get; set; }
    }
}