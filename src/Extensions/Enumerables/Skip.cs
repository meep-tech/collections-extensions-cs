using System.Collections;

namespace Meep.Tech.Collections {

  /// <summary>
  /// Methods for skipping elements in enumerables.
  /// </summary>
  public static class SkipEnumerableExtensions {

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

    #endregion
  }
}