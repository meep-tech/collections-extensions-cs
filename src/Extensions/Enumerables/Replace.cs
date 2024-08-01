using System.Collections;

namespace Meep.Tech.Collections {

    /// <summary>
    /// Common Extensions for replacing and updating enumerable elements.
    /// </summary>
    public static class ReplaceEnumerableExtensions {

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

    }
}