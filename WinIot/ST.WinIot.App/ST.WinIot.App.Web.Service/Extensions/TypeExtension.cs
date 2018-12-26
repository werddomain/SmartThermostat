using ST.Web.Service;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace System
{
    public static class TypeExtension
    {
        public static bool IsCompatibleType(this object value, Type correspondingType)
        {
            if (correspondingType == null ||value == null)
                return false;

            return value.GetType().IsCompatibleType(correspondingType);
        }
        public static bool IsCompatibleType(this object value, object otherObject)
        {
            return value.GetType().IsCompatibleType(otherObject.GetType());
        }
        public static bool IsCompatibleType(this Type value, Type correspondingType)
        {
            if (value != null)
            {
                if (value == correspondingType)
                {
                    return true;
                }
                if (value.GetTypeInfo().IsAssignableFrom(correspondingType.GetTypeInfo()))
                {
                    return true;
                }
                if (value.GetInterfaces().Contains(correspondingType))
                {
                    return true;
                }
            }
            return false;
        }

        public static string MemberName<T, V>(this Expression<Func<T, V>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new InvalidOperationException("Expression must be a member expression");

            return memberExpression.Member.Name;
        }

        //public static T GetAttribute<T>(this ICustomAttributeProvider provider)
        //    where T : Attribute
        //{
        //    var attributes = provider.GetCustomAttributes(typeof(T), true);
        //    return attributes.Length > 0 ? attributes[0] as T : null;
        //}

        public static bool IsRequired<T, V>(this Expression<Func<T, V>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                return false;

            return memberExpression.Member.GetCustomAttribute<CSRequiredAttribute>() != null;
        }
        public static bool IsStringLengh<T, V>(this Expression<Func<T, V>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                return false;

            return memberExpression.Member.GetCustomAttribute<CSStringLengthAttribute>() != null || memberExpression.Member.GetCustomAttribute<StringLengthAttribute>() != null;
        }
        public static StringLengthAttribute StringLenghAttributeValue<T, V>(this Expression<Func<T, V>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new InvalidOperationException("Expression must be a member expression");

            var attr = memberExpression.Member.GetCustomAttribute<CSStringLengthAttribute>() as StringLengthAttribute;
                if (attr == null)
                attr = memberExpression.Member.GetCustomAttribute<StringLengthAttribute>();
                if (attr != null)
                    return attr;
                else return null;
                    
        }
        public static DisplayNameAttribute DisplayNameAttributeValue<T, V>(this Expression<Func<T, V>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new InvalidOperationException("Expression must be a member expression");

            var attr = memberExpression.Member.GetCustomAttribute<DisplayNameAttribute>();
            if (attr != null)
                return attr;
            else return null;

        }
        
    }
}
