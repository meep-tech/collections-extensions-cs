using System.Collections;

namespace Meep.Tech.Collections {

  /// <summary>
  /// Extensions for using objects with/like/as enumerables.
  /// </summary>
  public static class ObjectEnumerableExtensions {

    /// <summary>
    /// Used to either enumerate through an enumerable or wrap a non-enumerable object in a new enumerable.
    /// </summary>
    public static IEnumerable<T> Enumerate<T>(this T item) {
      yield return item;
    }

    /// <summary>
    /// Used to either enumerate through an enumerable or wrap a non-enumerable object in a new enumerable.
    /// </summary>
    public static IEnumerable Enumerate(this object item)
      => item switch {
        IEnumerable enumerable => enumerable,
        _ => item.Enumerate<object>()
      };

    /// <summary>
    /// Used to either enumerate through an enumerable or wrap a non-enumerable object in a new enumerable.
    /// </summary>
    public static IEnumerable<R> Enumerate<R>(this object item) {
      if(item is IEnumerable<R> enumerable) {
        return enumerable;
      }
      else if(item is IEnumerable e) {
        return e.Cast<R>();
      }
      else if(item is R t) {
        return t.Enumerate();
      }
      else {
        throw new InvalidCastException($"Cannot enumerate object of type {item.GetType().Name} as IEnumerable<{typeof(R).Name}>.");
      }
    }

    /// <summary>
    /// Used to either enumerate through an enumerable or wrap a non-enumerable object in a new enumerable.
    /// </summary>
    public static IEnumerable<T> Enumerate<T>(this IEnumerable<T> items)
      => items;

    /// <summary>
    /// Wraps an object in a new enumerable.
    /// </summary>
    public static IEnumerable<T> InEnumerable<T>(this T item) {
      yield return item;
    }
  }
}