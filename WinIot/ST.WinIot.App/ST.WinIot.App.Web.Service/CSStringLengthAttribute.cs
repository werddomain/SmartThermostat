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
    public class CSStringLengthAttribute : StringLengthAttribute
    {
        public CSStringLengthAttribute(int maximumLength, int minimumLengh = 0) :
            base(maximumLength)
        {

            //this.ErrorMessageResourceType = typeof(Resources.Validation);
            //this.ErrorMessageResourceName = "StringLength";
            this.MinimumLength = minimumLengh;

        }
        string displayName;
        bool isToShort = false;
        bool isToLong = false;

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
            if (value == null) {
                isToShort = MinimumLength > 0;
            }
            else
            {
                var s = value.ToString();
                if (s.Length < MinimumLength)
                    isToShort = true;
                if (s.Length > MaximumLength)
                    isToLong = true;
            }
            return base.IsValid(value, validationContext);
        }

        public override string FormatErrorMessage(string name)
        {
            var message = "";
            if (isToLong)
            {
                message = Config.ValidationResourceManager.GetString("StringLengthMax");
                ErrorMessage = string.Format(message, displayName, MaximumLength);
            }
            if (isToShort)
            {
                message = Config.ValidationResourceManager.GetString("StringLengthMin");
                ErrorMessage = string.Format(message, displayName, MinimumLength);
            }

            return base.FormatErrorMessage(name);
        }

        private void GetLocalizedDisplayName()
        {
            ResourceManager resourceManager = Config.NamesResourceManager;
            CultureInfo culture = CultureInfo.CurrentCulture;

            var name = resourceManager.GetString(displayName, culture);
            if (!string.IsNullOrEmpty(name))
                displayName = name;
        }
    }
}