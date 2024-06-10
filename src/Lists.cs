using System.Collections;

namespace Meep.Tech.Collections {

  /// <summary>
  /// Common Extensions for List types.
  /// </summary>
  public static class ListExtensions {

    /// <summary>
    /// Used to check if a list is long enough before accessing an index.
    /// </summary>
    /// <returns>True if the index is within the list bounds, false otherwise.</returns>
    public static bool TryGetValueAt<T>(this IReadOnlyList<T> list, int index, out T value) {
      if(index >= 0 && index < list.Count) {
        value = list[index];
        return true;
      }

      value = default!;
      return false;
    }

    /// <inheritdoc cref="TryGetValueAt{T}(IReadOnlyList{T}, int, out T)"/>
    public static bool TryGetValueAt(this IList list, int index, out object? value) {
      if(index >= 0 && index < list.Count) {
        value = list[index];
        return true;
      }

      value = default!;
      return false;
    }
  }
}