using System.Collections;

namespace Meep.Tech.Collections {

    /// <summary>
    /// Common Extensions for IEnumerable types.
    /// </summary>
    public static class EnumerableExtensions {

        #region Where (Is, Not)

        /// <inheritdoc cref="Enumerable.Where{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        /// <param name="source"><inheritdoc cref="Enumerable.Where{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/></param>
        /// <param name="is">The positive predicate to filter the source by.</param>
        /// <param name="not">The negative predicate to filter the source by.</param>
        public static IEnumerable<TType> Where<TType>(
            this IEnumerable<TType> source,
            Func<TType, bool>? @is = null,
            Func<TType, bool>? not = null
        ) {
            if(@is is null) {
                if(not is null) {
                    foreach(TType? item in source) {
                        yield return item;
                    }
                }
                else {
                    foreach(TType? item in source) {
                        if(!not(item)) {
                            yield return item;
                        }
                    }
                }
            }
            else if(not is null) {
                foreach(TType? item in source) {
                    if(@is(item)) {
                        yield return item;
                    }
                }
            }
            else {
                foreach(TType? item in source) {
                    if(@is(item) && !not(item)) {
                        yield return item;
                    }
                }
            }
        }

        #endregion

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

        #region Update

        /// <inheritdoc cref="Replace{TType}(IEnumerable{TType}, TType, TType, IEqualityComparer{TType})"/>
        public static IEnumerable<TType> Update<TType>(
            this IEnumerable<TType> source,
            Func<TType, bool> where,
            Func<TType, TType> update
        ) {
            foreach(TType? item in source) {
                yield return where(item)
                    ? update(item)
                    : item;
            }
        }

        /// <inheritdoc cref="Replace{TType}(IEnumerable{TType}, TType, TType, IEqualityComparer{TType})"/>
        public static IEnumerable Update(
            this IEnumerable source,
            Func<object, bool> where,
            Func<object, object> update
        ) {
            foreach(object? item in source) {
                yield return where(item)
                    ? update(item)
                    : item;
            }
        }

        #endregion

        #region Replace

        /// <inheritdoc cref="Replace{TType}(IEnumerable{TType}, TType, TType, IEqualityComparer{TType})"/>
        public static IEnumerable<TType> Replace<TType>(
            this IEnumerable<TType> source,
            Func<TType, bool> predicate,
            TType newValue
        ) {
            foreach(TType? item in source) {
                yield return predicate(item)
                    ? newValue
                    : item;
            }
        }

        /// <summary>
        /// Replaces all matching elements in the source with a new value during enumeration.
        /// </summary>
        /// <returns>The modifed enumerable.</returns>
        public static IEnumerable<TType> Replace<TType>(
            this IEnumerable<TType> source,
            TType oldValue,
            TType newValue,
            IEqualityComparer<TType>? comparer = null
        ) {
            comparer ??= EqualityComparer<TType>.Default;
            foreach(TType? item in source) {
                yield return comparer.Equals(item, oldValue)
                    ? newValue
                    : item;
            }
        }

        /// <inheritdoc cref="Replace{TType}(IEnumerable{TType}, TType, TType, IEqualityComparer{TType})"/>
        public static IEnumerable Replace(
            this IEnumerable source,
            Func<object, bool> predicate,
            object newValue
        ) {
            foreach(object? item in source) {
                yield return predicate(item)
                    ? newValue
                    : item;
            }
        }

        /// <inheritdoc cref="Replace{TType}(IEnumerable{TType}, TType, TType, IEqualityComparer{TType})"/>
        public static IEnumerable Replace(
            this IEnumerable source,
            object oldValue,
            object newValue,
            IEqualityComparer? comparer = null
        ) {
            comparer ??= EqualityComparer<object>.Default;
            foreach(object? item in source) {
                yield return comparer.Equals(item, oldValue)
                    ? newValue
                    : item;
            }
        }

        #endregion

        #region Skip [Where]

        /// <inheritdoc cref="Skip{TType}(IEnumerable{TType}, Func{TType, bool})"/>
        public static IEnumerable<TType> Skip<TType>(
            this IEnumerable<TType> source,
            Func<TType, bool> predicate
        ) {
            foreach(TType? item in source) {
                if(!predicate(item)) {
                    yield return item;
                }
            }
        }

        /// <inheritdoc cref="Skip{TType}(IEnumerable{TType}, Func{TType, bool})"/>
        public static IEnumerable Skip(
            this IEnumerable source,
            Func<object, bool> predicate
        ) {
            foreach(object? item in source) {
                if(!predicate(item)) {
                    yield return item;
                }
            }
        }
    }

    #endregion
}