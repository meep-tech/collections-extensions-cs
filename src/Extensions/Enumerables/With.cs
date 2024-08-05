
namespace Meep.Tech.Collections {

  /// <summary>
  /// Extensions for adding items to collections.
  /// </summary> 
  public static partial class WithExtensions {

    /// <summary>
    /// Adds an item to the source collection.
    /// </summary>
    public static TCollection With<TCollection, TItem>(
      this TCollection source,
      TItem item
    ) where TCollection : ICollection<TItem> {
      source.Add(item);
      return source;
    }

    /// <summary>
    /// Adds an item to the end of the source dictionary.
    /// </summary>
    public static TDictionary With<TDictionary, TKey, TValue>(
      this TDictionary source,
      TKey key,
      TValue value
    ) where TDictionary : IDictionary<TKey, TValue> {
      source.Add(key, value);
      return source;
    }
  }
}