namespace KiriLib.LinqBackport.NullableReduce;

public static partial class Enumerable
{
	public static T? ElementAt<T>(this IList<T> source, int index, T? Or = null)
		where T : class => 
		(source.Count > index) ? source[index] : Or;

	public static T? ElementAt<T>(this IList<T> source, int index, T? Or = null)
		where T : struct => 
		(source.Count > index) ? source[index] : Or;

	public static T? ElementAt<T>(this IEnumerable<T> source, int index, T? Or = null) 
		where T: class 
	{
		switch (source) {
		case IList<T> list:
			return (list.Count > index) ? list[index] : Or;
		default: {
			using var enu = source.GetEnumerator();
			int i;
			for (i = 0; enu.MoveNext() && i < index; i++);
			if (i < index) return Or;
			return enu.Current;
		}}
	}

	public static T? ElementAt<T>(this IEnumerable<T> source, int index, T? Or = null) 
		where T: struct 
	{
		switch (source) {
		case IList<T> list:
			return (list.Count > index) ? list[index] : Or;
		default: {
			using var enu = source.GetEnumerator();
			int i;
			for (i = 0; enu.MoveNext() && i < index; i++);
			if (i < index) return Or;
			return enu.Current;
		}}
	}
}