using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;

namespace System
{
    public static class HelperExtension
    {
        public static string GetString(this IHtmlContent content, HtmlEncoder encoder = null)
        {
            var writer = new System.IO.StringWriter();
            content.WriteTo(writer, encoder ?? HtmlEncoder.Default);
            return writer.ToString();
        }
        public static void AddOrAppend(this TagHelperAttributeList Attributes, string Name, string Value, string Separator = " ")
        {
            if (Attributes != null)
            {
                if (Attributes.ContainsName(Name))
                {
                    var attr = Attributes[Name].Value;
                    var value = attr is IHtmlContent ? ((IHtmlContent)attr).GetString() : attr.ToString();
                    
                    Value = value + Separator + Value;
                    Attributes.Remove(Attributes[Name]);

                }
                Attributes.Add(Name, Value);
            }
        }
        public static void CopyToTagBuilder(this TagHelperAttributeList tagAttribute, TagBuilder tagBuilder) {
            foreach (var item in tagAttribute)
            {
                tagBuilder.Attributes.Add(item.Name, item.Value.ToString());
            }
        }
        public static bool HasClass(this TagHelperOutput output, string className){
            if (output.Attributes.ContainsName("class") == false)
                return false;
            var cls = output.Attributes["class"].ToString().DirectSplit(" ");
            return Array.IndexOf(cls, className) > -1;
        }
        public static void AddCssClass(this TagHelperOutput output, string className)
        {
            if (output.HasClass(className))
                return;
            output.Attributes.AddOrAppend("class", className);
        }
        public static void AddCssClass(this TagHelperOutput output, string[] classes)
        {
            if (classes != null && classes.Length > 0)
                foreach (var item in classes)
                {
                    output.AddCssClass(item);
                }
        }
        public static void AddCssClass(this TagBuilder tagBuilder, string[] classes)
            {
            
            if (classes != null && classes.Length > 0)
                foreach (var item in classes)
                {
                    tagBuilder.AddCssClass(item);
                }
        }
    }
}
