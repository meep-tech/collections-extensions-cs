namespace Meep.Tech.Collections {

  /// <summary>
  /// Nullable Value-Type focused Predicate functions for filtering enumerables.
  /// </summary>
  public static class Has {

    /// <summary>
    /// A predicate function that returns true if the nullable-value-type element has a value.
    /// </summary>
    public static bool Value<T>(T? nullableValue)
      where T : struct
      => nullableValue.HasValue;

    /// <summary>
    /// A predicate function that returns true if the nullable-value-type element has no value.
    /// </summary>
    public static bool NoValue<T>(T? nullableValue)
      where T : struct
      => !nullableValue.HasValue;
  }
}