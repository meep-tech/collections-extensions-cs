namespace Meep.Tech.Collections {

  /// <summary>
  /// Methods for deconstructing enumerables.
  /// </summary>
  public static class DeconstructionExtensions {

    #region Deconstruct

    /// <summary>
    /// Deconstructs an array into a tuple of the first element and the rest of the enumerable.
    /// </summary>
    public static void Deconstruct<TType>(
        this TType[] source,
        out TType? first,
        out TType[] rest
    ) {
      if(source.Length > 0) {
        first = source[0];
        rest = source[1..];
      }
      else {
        first = default;
        rest = [];
      }
    }

    /// <summary>
    /// Deconstructs any enumerable into a tuple of the first element and the rest of the enumerable.
    /// </summary>
    public static void Deconstruct<TType>(
        this IEnumerable<TType> source,
        out TType? first,
        out IEnumerable<TType> rest
    ) {
      using IEnumerator<TType> enumerator
                = source.GetEnumerator();

      if(enumerator.MoveNext()) {
        first = enumerator.Current;
        rest = enumerator.AsEnumerable();
      }
      else {
        first = default;
        rest = [];
      }
    }

    /// <summary>
    /// Deconstructs any enumerable into a tuple of the two first elements and the rest of the enumerable.
    /// </summary>
    public static void Deconstruct<TType>(
        this IEnumerable<TType> source,
        out TType? first,
        out TType? second,
        out IEnumerable<TType> rest
    ) => (first, (second, rest)) = source;

    /// <summary>
    /// Deconstructs any enumerable into a tuple of the three first elements and the rest of the enumerable.
    /// </summary>
    public static void Deconstruct<TType>(
        this IEnumerable<TType> source,
        out TType? first,
        out TType? second,
        out TType? third,
        out IEnumerable<TType> rest
    ) => (first, second, (third, rest)) = source;

    /// <summary>
    /// Deconstructs any enumerable into a tuple of the four first elements and the rest of the enumerable.
    /// </summary>
    public static void Deconstruct<TType>(
        this IEnumerable<TType> source,
        out TType? first,
        out TType? second,
        out TType? third,
        out TType? fourth,
        out IEnumerable<TType> rest
    ) => (first, second, third, (fourth, rest)) = source;

    #endregion
  }
}