namespace KiriLib.LinqBackport.NullableReduce;

public static partial class Enumerable
{
	public static T? First<T>(this IList<T> source, T? Or = null) where T : class => 
		(source.Count > 0) ? source[0] : Or;
	
	public static T? First<T>(this IList<T> source, T? Or = null) where T : struct => 
		(source.Count > 0) ? source[0] : Or;
	
	public static T? First<T>(this IEnumerable<T> source, T? Or = null) where T: class {
		switch (source) {
		case IList<T> list:
			return (list.Count > 0) ? list[0] : Or;
		default: {
			using var enu = source.GetEnumerator();
			return enu.MoveNext() ? enu.Current : Or;
		}}
	}
	
	public static T? First<T>(this IEnumerable<T> source, T? Or = null) where T: struct {
		switch (source) {
		case IList<T> list:
			return (list.Count > 0) ? list[0] : Or;
		default: {
			using var enu = source.GetEnumerator();
			return enu.MoveNext() ? enu.Current : Or;
		}}
	}

	public static T? First<T>(this IList<T> source, Predicate<T> f, T? Or = null) 
		where T : class 
	{
		for (int i = 0; i < source.Count; i++) {
			var item = source[i];
			if (f(item)) return item;
		}
		return Or;
	}

	public static T? First<T>(this IList<T> source, Predicate<T> f, T? Or = null) 
		where T : struct
	{
		for (int i = 0; i < source.Count; i++) {
			var item = source[i];
			if (f(item)) return item;
		}
		return Or;
	}

	public static T? First<T>(this IEnumerable<T> source, Predicate<T> f, T? Or = null) 
		where T: class 
	{
		switch (source) {
		case IList<T> list:
			for (int i = 0; i < list.Count; i++) {
				var item = list[i];
				if (f(item)) return item;
			}
			break;
		default: {
			foreach (var item in source) {
				if (f(item)) return item;
			}
			break;
		}}
		return Or;
	}

	public static T? First<T>(this IEnumerable<T> source, Predicate<T> f, T? Or = null) 
		where T: struct 
	{
		switch (source) {
		case IList<T> list:
			for (int i = 0; i < list.Count; i++) {
				var item = list[i];
				if (f(item)) return item;
			}
			break;
		default: {
			foreach (var item in source) {
				if (f(item)) return item;
			}
			break;
		}}
		return Or;
	}
}