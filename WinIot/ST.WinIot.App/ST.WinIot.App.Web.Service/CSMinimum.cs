using ST.Web.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Web.Service
{
    public class CSMinimum: ValidationAttribute
    {
        private readonly int? _minValue;
        private readonly double? _minValueD;
       private bool isDouble = false;

        public CSMinimum(int minValue)
        {
            _minValue = minValue;
            //this.ErrorMessageResourceName = "MinimumValidation";
            //this.ErrorMessageResourceType = typeof(ST.Web.Service.Ressources.Validation);
        }
        public CSMinimum(double minValue)
        {
            _minValueD = minValue;
            isDouble = true;
            this.ErrorMessageResourceName = "MinimumValidation";
            this.ErrorMessageResourceType = Config.ValidationResourceType;
        }
       
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            if (isDouble)
                return ((double)value) >= _minValueD.Value;

            return ((int)value) >= _minValue.Value;
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(Config.ValidationResourceManager.GetString("MinimumValidation"), name, isDouble ? _minValueD.Value.ToString() : _minValue.Value.ToString());
            //return base.FormatErrorMessage(name);
        }

    }
    public class CSMaximum : ValidationAttribute
    {
        private readonly int? _maxValue;
        private readonly double? _maxValueD;
        private bool isDouble = false;

        public CSMaximum(int maxValue)
        {
            _maxValue = maxValue;
            //    this.ErrorMessageResourceName = "MaximumValidation";
            //this.ErrorMessageResourceType = typeof(ST.Web.Service.Ressources.Validation);
        }
        public CSMaximum(double maxValue)
        {
            _maxValueD = maxValue;
            isDouble = true;
            //    this.ErrorMessageResourceName = "MaximumValidation";
            //this.ErrorMessageResourceType = typeof(ST.Web.Service.Ressources.Validation);
        }

        public override bool IsValid(object value)
        {

            if (value == null)
                return false;

            if (isDouble)
                return ((double)value) >= _maxValueD.Value;

            return ((int)value) <= _maxValue;
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(Config.ValidationResourceManager.GetString("MaximumValidation"), name, isDouble ? _maxValueD.Value.ToString() : _maxValue.Value.ToString());
            //return base.FormatErrorMessage(name);
        }
    }
}
