using System.Collections;

namespace Meep.Tech.Collections {
  public static class ListExtensions {
    public static bool TryGetValueAt<T>(this IReadOnlyList<T> list, int index, out T value) {
      if(index >= 0 && index < list.Count) {
        value = list[index];
        return true;
      }

      value = default!;
      return false;
    }

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