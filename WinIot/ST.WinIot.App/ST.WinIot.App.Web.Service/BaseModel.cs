



using System;

namespace ST.Web.Service
{
    [Serializable]
    public abstract class BaseModel
    {
        [System.Xml.Serialization.XmlIgnore]
        [Newtonsoft.Json.JsonIgnore]
        //[System.Web.Script.Serialization.ScriptIgnore]
        public Params Param { get; set; }
       
    }

    public partial class Params {
        public Params() {
           
        }


        public bool? Success { get; set; }
        public bool? Error { get; set; }

        public string Title { get; set; }

        
        public bool FullWidthContainer { get; set; }


        //LoadedInBaseController
        public bool IsLogged { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsMasterAdmin { get; set; }

        public bool IsExt { get; set; }

        
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        public string Area { get; set; }

       


        public string LangCode { get; set; }

        

        public string AdditionalActionMsg { get; set; }

        

        public string LangId
        {
            get
            {
                if (LangCode == null)
                    return null;
                if (LangCode.Length > 2)
                    return LangCode.Substring(0, 2).ToLower();
                else
                    return LangCode.ToLower();
            }
        }
       
        
    }
    
    public class BlankModel : BaseModel { }
    
   
}