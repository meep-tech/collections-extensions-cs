namespace Meep.Tech.Collections {

  /// <summary>
  /// Additional extensions for enumerating though enumerables.
  /// </summary>
  public static class EnumerationExtensions {

    /// <summary>
    /// Used to either enumerate through an enumerable or wrap a non-enumerable object in a new enumerable.
    /// </summary>
    public static IEnumerable<TItem> Enumerate<TEnumerable, TItem>(this TEnumerable items)
      where TEnumerable : IEnumerable<TItem>
        => items;

  }
}