using System.Collections;

namespace Meep.Tech.Collections {
  /// <summary>
  /// Additional extensions for non-generic enumerables.
  /// </summary>
  public static class NonGenericExtensions {

    /// <summary>
    /// Used to either enumerate through an enumerable or wrap a non-enumerable object in a new enumerable.
    /// </summary>
    public static T Enumerate<T>(this T items)
      where T : IEnumerable
        => items;
  }
}