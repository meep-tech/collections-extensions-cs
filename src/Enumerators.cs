namespace Meep.Tech.Collections {

  /// <summary>
  /// Common Extensions for IEnumerator types.
  /// </summary>
  public static class EnumeratorExtensions {

    /// <summary>
    /// Get an enumerable of characters from a text reader.
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