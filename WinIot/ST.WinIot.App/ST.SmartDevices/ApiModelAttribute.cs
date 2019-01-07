using System;
using System.Collections.Generic;
using System.Text;

namespace ST.SmartDevices
{
    /// <summary>
    /// Define a model as an model used in api. Used in Web.UI by the extension TypeWriter to generate TypeScript definition
    /// </summary>
    public class ApiModelAttribute:Attribute
    {
    }

    public class ApiEnumAttribute : Attribute
    {
    }

	public class GenerateApiAttribute : Attribute
	{
	}
}
