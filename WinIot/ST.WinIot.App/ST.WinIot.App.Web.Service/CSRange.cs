
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Web;

namespace ST.WinIot.App.Web.Service
{
    public class CSRange:RangeAttribute
    {
            // Summary:
        //     Initializes a new instance of the System.ComponentModel.DataAnnotations.RangeAttribute
        //     class by using the specified minimum and maximum values.
        //
        // Parameters:
        //   minimum:
        //     Specifies the minimum value allowed for the data field value.
        //
        //   maximum:
        //     Specifies the maximum value allowed for the data field value.
        public CSRange(double minimum, double maximum):
            base(minimum, maximum) { load(); }
        //
        // Summary:
        //     Initializes a new instance of the System.ComponentModel.DataAnnotations.RangeAttribute
        //     class by using the specified minimum and maximum values.
        //
        // Parameters:
        //   minimum:
        //     Specifies the minimum value allowed for the data field value.
        //
        //   maximum:
        //     Specifies the maximum value allowed for the data field value.
        public CSRange(int minimum, int maximum) :
            base(minimum, maximum) { load(); }
        //
        // Summary:
        //     Initializes a new instance of the System.ComponentModel.DataAnnotations.RangeAttribute
        //     class by using the specified minimum and maximum values and the specific
        //     type.
        //
        // Parameters:
        //   type:
        //     Specifies the type of the object to test.
        //
        //   minimum:
        //     Specifies the minimum value allowed for the data field value.
        //
        //   maximum:
        //     Specifies the maximum value allowed for the data field value.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     type is null.


        // Summary:
        //     Gets the maximum allowed field value.
        //
        // Returns:
        //     The maximum value that is allowed for the data field.
        public new object Maximum
        { get { return base.Maximum; } }
        //
        // Summary:
        //     Gets the minimum allowed field value.
        //
        // Returns:
        //     The minimu value that is allowed for the data field.
        public new object Minimum
        { get { return base.Minimum; } }
        void load() {
            base.ErrorMessageResourceType = Config.ValidationResourceType;
            base.ErrorMessageResourceName = "GenericRange";
        }
    }
}
