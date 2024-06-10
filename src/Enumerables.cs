using System.Collections;

namespace Meep.Tech.Collections {

    /// <summary>
    /// Common Extensions for IEnumerable types.
    /// </summary>
    public static class EnumerableExtensions {

        #region ForEach

        /// <summary>
        /// Used to iterate over an IEnumerable and perform an action on each element without returning a value.
        /// </summary>
        /// <returns>The original IEnumerable for chaining.</returns>
        public static IEnumerable<TType> ForEach<TType>(this IEnumerable<TType> source, Action<TType> action) {
            foreach(TType? item in source) {
                action(item);
            }

            return source;
        }

        /// <inheritdoc cref="ForEach{TType}(IEnumerable{TType}, Action{TType})"/>
        public static IEnumerable<TType> ForEach<TType>(this IEnumerable<TType> source, Action<TType, int> action) {
            int index = 0;
            foreach(TType? item in source) {
                action(item, index++);
            }

            return source;
        }

        /// <inheritdoc cref="ForEach{TType}(IEnumerable{TType}, Action{TType})"/>
        public static IEnumerable<TType> ForEach<TType, TDiscard>(this IEnumerable<TType> source, Func<TType, TDiscard> action) {
            foreach(TType? item in source) {
                _ = action(item);
            }

            return source;
        }

        /// <inheritdoc cref="ForEach{TType}(IEnumerable{TType}, Action{TType})"/>
        public static IEnumerable<TType> ForEach<TType, TDiscard>(this IEnumerable<TType> source, Func<TType, int, TDiscard> action) {
            int index = 0;
            foreach(TType? item in source) {
                _ = action(item, index++);
            }

            return source;
        }

        #endregion

        #region First [or Default]

        /// <inheritdoc cref="Enumerable.First{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static object? First(this IEnumerable source, Func<object, bool> predicate) {
            foreach(object? item in source) {
                if(predicate(item)) {
                    return item;
                }
            }

            throw new InvalidOperationException("No matching element found.");
        }

        /// <inheritdoc cref="Enumerable.FirstOrDefault{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static object? FirstOrDefault(this IEnumerable source, Func<object, bool> predicate, object? defaultValue = null) {
            foreach(object? item in source) {
                if(predicate(item)) {
                    return item;
                }
            }

            return defaultValue;
        }

        #endregion
    }
}
