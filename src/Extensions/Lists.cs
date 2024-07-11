using System.Collections;

namespace Meep.Tech.Collections {

  /// <summary>
  /// Common Extensions for List types.
  /// </summary>
  public static class ListExtensions {

    #region Try Get Value At

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

    #endregion

    #region Index Of

    /// <inheritdoc cref="IList.IndexOf(object)"/>
    public static int IndexOf<T>(this IReadOnlyList<T> list, T value) {
      for(int i = 0; i < list.Count; i++) {
        if(Equals(list[i], value)) {
          return i;
        }
      }

      return -1;
    }

    /// <inheritdoc cref="IList.IndexOf(object)"/>
    public static int IndexOf(this IList list, object? value) {
      for(int i = 0; i < list.Count; i++) {
        if(Equals(list[i], value)) {
          return i;
        }
      }

      return -1;
    }

    #endregion
  }
}