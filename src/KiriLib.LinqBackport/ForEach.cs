namespace KiriLib.LinqBackport;

public static partial class Enumerable
{
	public static void ForEach<T>(this T[] src, Action<T> op) {
		for (int i = 0; i < src.Length; i++) op(src[i]);
	}

	public static void ForEach<T>(this IList<T> src, Action<T> op) {
		for (int i = 0; i < src.Count; i++) op(src[i]);
	}

	public static void ForEach<T>(this IEnumerable<T> src, Action<T> op) {
		foreach (var item in src) op(item);
	}
}