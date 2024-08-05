
namespace Meep.Tech.Collections {

  /// <summary>
  /// Common Extensions for IEnumerable types.
  /// </summary>
  public static class WhereExtensions {

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

    /// <summary>
    /// Removes all null elements from the source enumerable.
    /// </summary>
    public static IEnumerable<TType> WhereNotNull<TType>(
        this IEnumerable<TType?> source
    ) {
      foreach(TType? item in source) {
        if(item is not null) {
          yield return item;
        }
      }
    }

    #endregion
  }
}