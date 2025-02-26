namespace KiriLib.LinqBackport.NullableReduce;

public static partial class Enumerable
{
	public static T? Single<T>(this IList<T> source, T? Or = null) where T : class => 
		(source.Count == 1) ? source[0] : Or;
	
	public static T? Single<T>(this IList<T> source, T? Or = null) where T : struct => 
		(source.Count == 1) ? source[0] : Or;

	public static T? Single<T>(this IEnumerable<T> source, T? Or = null) where T: class {
		switch (source) {
		case IList<T> list:
			return (list.Count == 1) ? list[0] : Or;
		default: {
			using var enu = source.GetEnumerator();
			if (!enu.MoveNext()) return Or;
			while (enu.MoveNext());
			return enu.Current;
		}}
	}

	public static T? Single<T>(this IEnumerable<T> source, T? Or = null) where T: struct {
		switch (source) {
		case IList<T> list:
			return (list.Count == 1) ? list[0] : Or;
		default: {
			using var enu = source.GetEnumerator();
			if (!enu.MoveNext()) return Or;
			while (enu.MoveNext());
			return enu.Current;
		}}
	}
}