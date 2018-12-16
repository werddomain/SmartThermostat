//using System.Collections.Generic;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace System
//{
//    public static class ReflectionExtensions
//    {
//        public static T ToObject<T>(this IDictionary<string, object> source)
//        where T : class, new()
//        {
//            var someObject = new T();
//            var someObjectType = someObject.GetType();

//            foreach (var item in source)
//            {
//                someObjectType
//                         .GetProperty(item.Key)
//                         .SetValue(someObject, item.Value, null);
//            }

//            return someObject;
//        }
//        public static T ToObject<T>(this IDictionary<string, string> source)
//        where T : class, new()
//        {
//            var someObject = new T();
//            var someObjectType = someObject.GetType();

//            foreach (var item in source)
//            {
//                someObjectType
//                         .GetProperty(item.Key)
//                         .SetValue(someObject, item.Value, null);
//            }

//            return someObject;
//        }

//        public static IDictionary<string, object> AsDictionary(this object source, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
//        {
//            return source.GetType().GetProperties(bindingAttr).ToDictionary
//            (
//                propInfo => propInfo.Name,
//                propInfo => propInfo.GetValue(source, null)
//            );

//        }
//        public static IDictionary<string, string> AsStringDictionary(this object source, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
//        {
//            return source.GetType().GetProperties(bindingAttr).ToDictionary
//            (
//                propInfo => propInfo.Name,
//                propInfo => propInfo.GetValue(source, null).ToString()
//            );

//        }
//        public static void Update<T>(this T destination, T source, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
//        {
//            var props = destination.GetType().GetProperties(bindingAttr);
//            foreach (var p in props)
//            {
//                var value = p.GetValue(source);

//                p.SetValue(destination, value);
//            }
//        }
//    }
//}
