namespace Meep.Tech.Collections
{
  /// <summary>
  /// Negated predicate functions for filtering enumerables.
  /// </summary>
  public static class Not
  {

    /// <summary>
    /// A predicate function that returns true if the ref-type value is not null.
    /// </summary>
    public static bool Null<T>(T value)
      where T : class
      => value != null;
  }
}