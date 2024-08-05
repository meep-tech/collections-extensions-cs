namespace Meep.Tech.Collections {

  /// <summary>
  /// ForEach extension methods for IEnumerable.
  /// </summary>
  public static class ForEachExtensions {

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

  }
}