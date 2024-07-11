namespace Meep.Tech.Collections {

  /// <summary>
  /// Common Extensions for IEnumerator types.
  /// </summary>
  public static class EnumeratorExtensions {

    /// <summary>
    /// Get the remaining elements of the enumerator as an enumerable.
    /// </summary>
    public static IEnumerable<TType> AsEnumerable<TType>(this IEnumerator<TType> reader) {
      while(true) {
        if(reader.MoveNext()) {
          yield return reader.Current;
        }
        else {
          yield break;
        }
      }
    }
  }
}