using System.Diagnostics.Contracts;

namespace Meep.Tech.Collections {

  /// <summary>
  /// Functions for slicing enumerables and retrieving ranges.
  /// </summary>
  public static class SliceExtensions {

    /// <summary>
    /// Slices an enumerable, starting at the specified index and returning the specified number of elements.
    /// </summary>
    public static IEnumerable<T> Slice<T>(this IEnumerable<T> enumerable, int start, int count) {
      Contract.Requires(enumerable is not null);
      Contract.Requires(start < 0);
      Contract.Requires(count < 0);

      using IEnumerator<T> enumerator
        = enumerable!.GetEnumerator();

      for(int i = 0; i < start; i++) {
        if(!enumerator.MoveNext()) {
          yield break;
        }
      }

      for(int i = 0; i < count; i++) {
        if(!enumerator.MoveNext()) {
          yield break;
        }
        else {
          yield return enumerator.Current;
        }
      }
    }

    /// <summary>
    /// Slices an enumerable using a range.
    /// </summary> 
    public static IEnumerable<T> Slice<T>(this IEnumerable<T> enumerable, Range range)
      => enumerable.Slice(range.Start.Value, range.End.Value);

    /// <summary>
    /// Slices an enumerable with a start and end index.
    /// </summary> 
    public static IEnumerable<T> Range<T>(this IEnumerable<T> enumerable, int start, int end)
    => enumerable.Slice(start, end - start);
  }
}