namespace Meep.Tech.Collections {

  /// <summary>
  /// Predicate functions for filtering enumerables.
  /// </summary>
  public static class Is {

    /// <summary>
    /// A predicate function that returns true if the ref-type value is null.
    /// </summary>
    public static bool Null<T>(T value)
      where T : class
      => value == null;

    /// <summary>
    /// A predicate function that returns true if the value-type value is null.
    /// </summary>
    public static bool Null<T>(T? nullableValue)
      where T : struct
      => !nullableValue.HasValue;

    /// <summary>
    /// A predicate function that returns true if the ref-type value is not null.
    /// </summary>
    public static bool NotNull<T>(T value)
      where T : class
      => value != null;

    /// <summary>
    /// A predicate function that returns true if the value-type value is not null.
    /// </summary>
    public static bool NotNull<T>(T? nullableValue)
      where T : struct
      => nullableValue.HasValue;
  }
}