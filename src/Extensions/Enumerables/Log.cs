namespace Meep.Tech.Collections {

  /// <summary>
  /// Common Logging and Debugging Extensions for enumerables.
  /// </summary>
  public static class DebugExtensions {

    /// <summary>
    /// The text to use when an item is null.
    /// </summary>
    public static string NullText { get; set; } = "<NULL>";

    /// <summary>
    /// Log each item in the enumerable using it's default ToString method.
    /// </summary>
    public static IEnumerable<T> LogEach<T>(this IEnumerable<T> source)
      => source.ForEach(t => Console.WriteLine(t?.ToString() ?? NullText));

    /// <summary>
    /// Log each item in the enumerable using the specified template.
    /// </summary>
    /// <param name="source">The enumerable to debug each element of.</param>
    /// <param name="template">The template to use for debugging each element. (Use {0} as a placeholder for the element.)</param>
    /// <returns></returns>S
    public static IEnumerable<T> LogEach<T>(this IEnumerable<T> source, FormattableString template)
      => source.ForEach(t => Console.WriteLine(template.Format.Replace("{0}", t?.ToString() ?? NullText)));

    /// <summary>
    /// Log each item in the enumerable using the specified templating function.
    /// </summary>
    public static IEnumerable<T> LogEach<T>(this IEnumerable<T> source, Func<T, string> template)
      => source.ForEach(t => Console.WriteLine(template(t)));
  }
}