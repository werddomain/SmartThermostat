
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ST.WinIot.App.Web.Service
{
    
    public abstract class CSEntity : BaseModel
    {
        private string ids;
        public string Ids
        {
            get
            {
                if (string.IsNullOrEmpty(ids) || this.CSEntityState == CSEntityState.IsNew)
                    return this.EntityId;
                else
                    return ids;
            }
            set
            {
                ids = value;
            }
        }

        //public bool IsMultiEdit
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(this.Ids))
        //            return false;
        //        else
        //            return this.Ids.Contains(",");
        //    }
        //}
        public abstract string EntityId { get; set; }
        
        public CSEntityState CSEntityState { get; set; }
        public int? ConvertStrIdToInt(string id)
        {
            int newId;
            if (int.TryParse(id, out newId))
                return newId;
            else
                return null;
        }
        public Guid? ConvertStrIdToGuid(string id)
        {
            Guid newId;
            if (Guid.TryParse(id, out newId))
                return newId;
            else
                return null;
        }

        public string RowInfos
        {
            get
            {
                return this.BgColor;
            }
        }
        public virtual string FgColor { get; set; }
        public virtual string BgColor { get; set; }

        public string Errors { get; set; }


    }
    public enum CSEntityState
    {
        Original = 1,
        IsNew = 2, 
        IsEdited = 3, 
        IsDeleted = 4, 
        IsInError = 5
    }
}