namespace KiriLib.LinqBackport;

public static partial class Enumerable
{
	public static IEnumerable<T> IntersectBy<T>(
		IEnumerable<T> src1,
		IEnumerable<T> src2
	) where T: IEquatable<T> => IntersectBy_Common(
		src1,
		new(src2));

	public static IEnumerable<T> IntersectBy<T>(
		IEnumerable<T> src1,
		IEnumerable<T> src2,
		IEqualityComparer<T>? cpr
	) => IntersectBy_Common(
		src1,
		new(src2, cpr ?? EqualityComparer<T>.Default));

	private static IEnumerable<T> IntersectBy_Common<T>(
		IEnumerable<T> src,
		HashSet<T> set
	) {
		foreach (T item in src) if (set.Remove(item)) 
			yield return item;
	}
}