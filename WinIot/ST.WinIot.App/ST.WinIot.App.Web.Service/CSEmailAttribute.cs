
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace System
{
    public class CSEmailAttribute : DataTypeAttribute, IClientModelValidator
    {
        EmailAddressAttribute attr;
        public CSEmailAttribute()
            : base(DataType.EmailAddress)
        {
            ErrorMessageResourceType = ST.WinIot.App.Web.Service.Config.ValidationResourceType;
            ErrorMessageResourceName = "BadEmailAddress";
            attr = new EmailAddressAttribute();
        }
        public override bool IsValid(object value)
        {
             
            
            return attr.IsValid(value);
            //return base.IsValid(value);
        }

        //public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        //{
        //    yield return new ModelClientValidationRule
        //    {
        //        ValidationType = "email",
        //        ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
        //    };
        //}

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            var errorMessage = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
            MergeAttribute(context.Attributes, "data-val-email", errorMessage);
        }
        private bool MergeAttribute(
        IDictionary<string, string> attributes,
        string key,
        string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }
            attributes.Add(key, value);
            return true;
        }
    }
}