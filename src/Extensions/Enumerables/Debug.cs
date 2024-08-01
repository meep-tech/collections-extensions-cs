namespace Meep.Tech.Collections {

      /// <summary>
      /// Common Logging and Debugging Extensions for enumerables.
      /// </summary>
      public static class EnumerableDebuggingExtensions {

            /// <summary>
            /// Debug Log each item in the enumerable using it's default ToString method.
            /// </summary>
            public static IEnumerable<T> DebugEach<T>(this IEnumerable<T> source)
#if DEBUG
              => source.ForEach(t => Console.WriteLine(t?.ToString() ?? NullText));
#else
      => source;
#endif

            /// <summary>
            /// Debug Log each item in the enumerable using the specified template.
            /// </summary>
            /// <param name="source">The enumerable to debug each element of.</param>
            /// <param name="template">The template to use for debugging each element. (Use {0} as a placeholder for the element.)</param>
            /// <returns></returns>
            public static IEnumerable<T> DebugEach<T>(this IEnumerable<T> source, FormattableString template)
#if DEBUG
              => source.ForEach(t => Console.WriteLine(template.Format.Replace("{0}", t?.ToString() ?? NullText)));
#else
      => source;
#endif

            /// <summary>
            /// Debug Log each item in the enumerable using the specified templating function.
            /// </summary>
            public static IEnumerable<T> DebugEach<T>(this IEnumerable<T> source, Func<T, string> template)
#if DEBUG
              => source.ForEach(t => Console.WriteLine(template(t)));
#else
      => source;
#endif
      }
}