namespace Meep.Tech.Collections {

  /// <summary>
  /// Extensions for <see cref="IEnumerable{T}"/> that provide additional functionality related to <see cref="SelectMany{TResult}"/>.
  /// </summary>
  public static class SelectManyExtensions {

    /// <summary>
    /// Projects each element of a sequence to an <see cref="IEnumerable{T}"/> and flattens the resulting sequences into one sequence.
    /// </summary>
    public static IEnumerable<TResult> SelectMany<TResult>(
      this IEnumerable<IEnumerable<TResult>> source
    ) {
      foreach(IEnumerable<TResult> item in source) {
        foreach(TResult? subItem in item) {
          yield return subItem;
        }
      }
    }
  }
}