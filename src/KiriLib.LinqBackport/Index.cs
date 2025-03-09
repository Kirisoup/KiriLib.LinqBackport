namespace KiriLib.LinqBackport;

public static partial class Enumerable
{
	public static IEnumerable<(int Index, T Item)> Index<T>(this T[] src) {
		for (int i = 0; i < src.Length; i++) yield return (i, src[i]);
	}

	public static IEnumerable<(int Index, T Item)> Index<T>(this IList<T> src) {
		for (int i = 0; i < src.Count; i++) yield return (i, src[i]);
	}

	public static IEnumerable<(int Index, T Item)> Index<T>(this IEnumerable<T> src) {
		using var enu = src.GetEnumerator();
		for (int i = 0; enu.MoveNext(); i++) yield return (i, enu.Current);
	}
}