
using ST.Web.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Web;

namespace ST.Web.Service
{
    public class CSRequiredAttribute : RequiredAttribute
    {

        public CSRequiredAttribute(string ErrorMessageKey = "FieldIsRequired")
        {
            this.ErrorResourceKey = ErrorMessageKey;
        }
        string displayName;
        string ErrorResourceKey;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var memberName = validationContext.ObjectType.GetProperties()
            //                .Where(p => p.GetCustomAttributes(false)
            //                .OfType<DisplayNameAttribute>().Any(a => a.DisplayName == validationContext.DisplayName)).Select(p => p.Name).FirstOrDefault();

            //if (memberName == null)
            //    memberName = validationContext.ObjectType.GetProperties()
            //                .Where(p => p.GetCustomAttributes(false)
            //                .OfType<DisplayAttribute>().Any(a => a.Name == validationContext.DisplayName)).Select(p => p.Name).FirstOrDefault();


            //var prop = validationContext.ObjectType.GetProperty(memberName == null ? validationContext.DisplayName : memberName);
            //var attributes = prop.GetCustomAttributes(typeof(DisplayNameAttribute), true);

            //if (attributes != null)
            //{
            //    var attribute = attributes.FirstOrDefault(e => e is DisplayNameAttribute);
            //    if (attribute != null)
            //        this.displayName = (attribute as DisplayNameAttribute).DisplayName;
            //    else
            //        this.displayName = validationContext.DisplayName;
            //}
            //else
            //    this.displayName = validationContext.DisplayName;
            //GetLocalizedDisplayName();
            this.displayName = validationContext.DisplayName;

            return base.IsValid(value, validationContext);
        }

        public string ErrorMessageKey { get; set; }
        public override string FormatErrorMessage(string name)
        {
            var message = Config.ValidationResourceManager.GetString(ErrorResourceKey);
            if (string.IsNullOrEmpty(message))
                message = ErrorResourceKey;
            ErrorMessage = string.Format(message, displayName);
            return base.FormatErrorMessage(name);
        }

        private void GetLocalizedDisplayName()
        {
            ResourceManager resourceManager = Config.NamesResourceManager;
            CultureInfo culture = CultureInfo.CurrentUICulture;

            var name = resourceManager.GetString(displayName, culture);
            if (!string.IsNullOrEmpty(name))
                displayName = name;
        }
    }
}