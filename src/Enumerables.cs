using System.Collections;

namespace Meep.Tech.Collections {
    public static class EnumerableExtensions {

        #region ForEach

        public static IEnumerable<TType> ForEach<TType>(this IEnumerable<TType> source, Action<TType> action) {
            foreach(TType? item in source) {
                action(item);
            }

            return source;
        }

        public static IEnumerable<TType> ForEach<TType>(this IEnumerable<TType> source, Action<TType, int> action) {
            int index = 0;
            foreach(TType? item in source) {
                action(item, index++);
            }

            return source;
        }

        public static IEnumerable<TType> ForEach<TType, TDiscard>(this IEnumerable<TType> source, Func<TType, TDiscard> action) {
            foreach(TType? item in source) {
                _ = action(item);
            }

            return source;
        }

        public static IEnumerable<TType> ForEach<TType, TDiscard>(this IEnumerable<TType> source, Func<TType, int, TDiscard> action) {
            int index = 0;
            foreach(TType? item in source) {
                _ = action(item, index++);
            }

            return source;
        }

        #endregion

        #region First [or Default]

        public static object? First(this IEnumerable source, Func<object, bool> predicate) {
            foreach(object? item in source) {
                if(predicate(item)) {
                    return item;
                }
            }

            throw new InvalidOperationException("No matching element found.");
        }

        public static object? FirstOrDefault(this IEnumerable source, Func<object, bool> predicate) {
            foreach(object? item in source) {
                if(predicate(item)) {
                    return item;
                }
            }

            return null;
        }

        #endregion
    }
}
