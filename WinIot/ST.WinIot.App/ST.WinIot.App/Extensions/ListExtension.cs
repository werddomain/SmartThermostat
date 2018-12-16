
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;


namespace System
{
    public static class ListExtension
    {
        /// <summary>
        /// Splits an array into several smaller arrays.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to split.</param>
        /// <param name="size">The size of the smaller arrays.</param>
        /// <returns>An array containing smaller arrays.</returns>
        public static IEnumerable<IEnumerable<T>> Split<T>(this T[] array, int size)
        {
            for (var i = 0; i < (float)array.Length / size; i++)
            {
                yield return array.Skip(i * size).Take(size);
            }
        }
        public static void AddRange<T>(this ObservableCollection<T> source, IEnumerable<T> items)
        {
            foreach (var item in items)
                source.Add(item);
        }

        public static IEnumerable<T> AddRange<T>(this IEnumerable<T> source, IEnumerable<T> Items)
        {

            if (source.HasValue())
                foreach (var item in source)
                {
                    yield return item;
                }
            foreach (var item in Items)
            {
                yield return item;
            }
        }
        public static IEnumerable<T> AddBefore<T>(this IEnumerable<T> source, T Item)
        {
            yield return Item;
            if (source.HasValue())
                foreach (var item in source)
                {
                    yield return item;
                }
        }
        public static IEnumerable<T> AddAfter<T>(this IEnumerable<T> source, T Item)
        {
            if (source.HasValue())
                foreach (var item in source)
                {
                    yield return item;
                }
            yield return Item;
        }
        public static IEnumerable<T> Sort<T>(IEnumerable<T> source, string sortBy)
        {
            var param = Expression.Parameter(typeof(T), "item");

            var sortExpression = Expression.Lambda<Func<T, object>>
                (Expression.Convert(Expression.Property(param, sortBy), typeof(object)), param);

            return source.AsQueryable<T>().OrderBy<T, object>(sortExpression);
        }


        public static IEnumerable<string> SelectByName<T>(this IEnumerable<T> source, string Name)
        {

            var param = Expression.Parameter(typeof(T), "item");

            var sortExpression = Expression.Lambda<Func<T, string>>
                (Expression.Convert(Expression.Property(param, Name), typeof(string)), param);

            return source.AsQueryable<T>().Select<T, string>(sortExpression);

        }
        public static IEnumerable<string> SelectFieldByName<T>(this IEnumerable<T> source, string Name)
        {

            var param = Expression.Parameter(typeof(T), "item");

            var sortExpression = Expression.Lambda<Func<T, string>>
                (Expression.Convert(Expression.Field(param, Name), typeof(string)), param);

            return source.AsQueryable<T>().Select<T, string>(sortExpression);

        }
        public static void Shuffle_List(this IList List)
        {
            List<object> List_Temp = new List<object>();

            int Fin = List.Count - 1;

            for (int x = 0; x <= Fin; x++)
            {
                //Random Random = new Random((int)DateTime.Now.Ticks);
                int Index = GlobalRandom.Next(0, List.Count);
                List_Temp.Add(List[Index]);
                List.RemoveAt(Index);
            }
            List.Clear();

            foreach (object i in List_Temp)
            {
                List.Add(i);
            }

        }
        public static IEnumerable<TSource> IndexRange<TSource>(this IList<TSource> source, int fromIndex, int toIndex)
        {
            int currIndex = fromIndex;
            while (currIndex <= toIndex)
            {
                yield return source[currIndex];
                currIndex++;
            }
        }

        public static T CSClone<T>(this T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        public static void AddIfNotExist<T>(this IList list, T value)
        {
            if (!list.Contains(value))
            {
                list.Add(value);
            }
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> data)
        {
            return data == null || !data.Any();
        }
        public static bool HasValue<T>(this IEnumerable<T> data)
        {
            return data != null && data.Any();
        }
        public static T[] ToArrayOrNull<T>(this IEnumerable<T> data)
        {
            if (data.HasValue())
                return data.ToArray();
            return (T[])null;
        }
        public static bool IsNullOrEmpty<T>(this List<T> data)
        {
            return data == null || data.Any();
        }
        public static bool HasValue<T>(this List<T> data)
        {
            return data != null && data.Any();
        }
        private static string ToCsvFields(string separator, IEnumerable<PropertyInfo> props, object o)
        {
            StringBuilder line = new StringBuilder();

            foreach (var f in props)
            {
                var x = f.GetValue(o);

                if (x != null)
                    line.Append(x.ToString().ToStandardized());
                else
                    line.Append("");

                line.Append(separator);
            }

            return line.ToString();
        }

        private static string GetLocalizedDisplayName(string propertyName, ResourceManager resourceManager)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentUICulture;
            return resourceManager.GetString(propertyName, culture);
        }

        /// <summary>
        /// Cette fonction group en fonction du champ passé et ensuite, elle tri en fonction de la qte de chaque group. Donc,
        /// Si j'ai un group de 10 items, un de 5 et 1 de 3 items, les 10 items passeront dans le haut de la liste, ensuite, les items
        /// dans le group de 5 et pour finir, les items du group de 3.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="source"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static void OrderByQteOf<TSource, TProperty>(this IList<TSource> source, Func<TSource, TProperty> expression)
        {
            List<TSource> listTemp = new List<TSource>();

            var groupedVal = source.GroupBy(expression).OrderByDescending(o => o.Count());

            foreach (var item in groupedVal)
            {
                listTemp.AddRange(item);
            }

            source.Clear();

            foreach (var item in listTemp)
            {
                source.Add(item);
            }
        }


        public static T NextItem<T>(this IEnumerable<T> list, T item)
        {
            int index = list.ToList().IndexOf(item);
            var nextElement = list.ElementAtOrDefault(index + 1);
            return nextElement;
        }

        public static bool NotNullAndHaveItems<T>(this IEnumerable<T> list)
        {
            if (list != null && list.Any())
                return true;
            else
                return false;
        }
    }
    public class GlobalRandom
    {

        static Random _Random;

        static GlobalRandom()
        {

            _Random = new Random();

        }

        public static int Next(int min, int max)
        {

            return _Random.Next(min, max);

        }
    }
}
