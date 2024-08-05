/// <summary>
/// Extensions aiding in simple ordering of enumerable elements.
/// </summary>
public static class OrderingExtensions {

  #region Order [First | Last]

  /// <summary>
  /// Orders the source enumerable so that the given element(s) match their desired position(s).
  /// </summary>
  public static IEnumerable<TType> Order<TType>(
      this IEnumerable<TType> source,
      TType? first = default,
      TType? last = default
  ) {
    if(first is not null) {
      yield return first;
    }

    foreach(TType? item in source) {
      if(item is not null && !item.Equals(first) && !item.Equals(last)) {
        yield return item;
      }
    }

    if(last is not null) {
      yield return last;
    }
  }

  /// <summary>
  /// Orders the source enumerable so that the given element(s) match their desired position(s).
  /// </summary>
  public static IEnumerable<TType> Order<TType>(
      this IEnumerable<TType> source,
      Func<TType, bool>? first = default,
      Func<TType, bool>? last = default
  ) {
    if(first is not null) {
      foreach(TType? item in source) {
        if(first(item)) {
          yield return item;
          break;
        }
      }
    }

    foreach(TType? item in source) {
      if(first is null || !first(item)) {
        if(last is null || !last(item)) {
          yield return item;
        }
      }
    }

    if(last is not null) {
      foreach(TType? item in source) {
        if(last(item)) {
          yield return item;
          break;
        }
      }
    }
  }

  #endregion
}