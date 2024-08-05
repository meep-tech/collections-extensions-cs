using System.Collections;

namespace Meep.Tech.Collections {

  /// <summary>
  /// Common Extensions for IEnumerable types.
  /// </summary>
  public static class FirstExtensions {

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