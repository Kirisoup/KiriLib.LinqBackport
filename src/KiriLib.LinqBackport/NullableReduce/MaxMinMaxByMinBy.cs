namespace KiriLib.LinqBackport.NullableReduce;

public static partial class Enumerable
{
	public static T? Max<T>(this IEnumerable<T> source, IComparer<T>? comparer, T? Or = null) 
		where T: class 
	{
		using var enu = source.GetEnumerator();
		if (!enu.MoveNext()) return Or;

		T item = enu.Current;
		comparer ??= Comparer<T>.Default;

		while (enu.MoveNext()) {
			T nextItem = enu.Current;
			if (comparer.Compare(nextItem, item) > 0) {
				item = nextItem;
			}
		}

		return item;
	}

	public static T? Max<T>(this IEnumerable<T> source, IComparer<T>? comparer, T? Or = null) 
		where T: struct
	{
		using var enu = source.GetEnumerator();
		if (!enu.MoveNext()) return Or;

		T item = enu.Current;
		comparer ??= Comparer<T>.Default;

		while (enu.MoveNext()) {
			T nextItem = enu.Current;
			if (comparer.Compare(nextItem, item) > 0) {
				item = nextItem;
			}
		}

		return item;
	}

	public static T? MaxBy<T, K>(this IEnumerable<T> source,
		Func<T, K> selector, IComparer<K>? comparer = null, T? Or = null) 
		where T: class
	{
		using var enu = source.GetEnumerator();
		if (!enu.MoveNext()) return Or;

		T item = enu.Current;
		K key = selector(item);
		comparer ??= Comparer<K>.Default;

		while (enu.MoveNext()) {
			T nextItem = enu.Current;
			K nextKey = selector(nextItem);
			if (comparer.Compare(nextKey, key) > 0) {
				item = nextItem;
				key = nextKey;
			}
		}

		return item;
	}

	public static T? MaxBy<T, K>(this IEnumerable<T> source,
		Func<T, K> selector, IComparer<K>? comparer = null, T? Or = null) 
		where T: struct
	{
		using var enu = source.GetEnumerator();
		if (!enu.MoveNext()) return Or;

		T item = enu.Current;
		K key = selector(item);
		comparer ??= Comparer<K>.Default;

		while (enu.MoveNext()) {
			T nextItem = enu.Current;
			K nextKey = selector(nextItem);
			if (comparer.Compare(nextKey, key) > 0) {
				item = nextItem;
				key = nextKey;
			}
		}

		return item;
	}

	public static T? Min<T>(this IEnumerable<T> source, IComparer<T>? comparer, T? Or = null) 
		where T: class 
	{
		using var enu = source.GetEnumerator();
		if (!enu.MoveNext()) return Or;

		T item = enu.Current;
		comparer ??= Comparer<T>.Default;

		while (enu.MoveNext()) {
			T nextItem = enu.Current;
			if (comparer.Compare(nextItem, item) < 0) {
				item = nextItem;
			}
		}

		return item;
	}

	public static T? Min<T>(this IEnumerable<T> source, IComparer<T>? comparer, T? Or = null) 
		where T: struct
	{
		using var enu = source.GetEnumerator();
		if (!enu.MoveNext()) return Or;

		T item = enu.Current;
		comparer ??= Comparer<T>.Default;

		while (enu.MoveNext()) {
			T nextItem = enu.Current;
			if (comparer.Compare(nextItem, item) < 0) {
				item = nextItem;
			}
		}

		return item;
	}

	public static T? MinBy<T, K>(this IEnumerable<T> source,
		Func<T, K> selector, IComparer<K>? comparer = null, T? Or = null) 
		where T: class
	{
		using var enu = source.GetEnumerator();
		if (!enu.MoveNext()) return Or;

		T item = enu.Current;
		K key = selector(item);
		comparer ??= Comparer<K>.Default;

		while (enu.MoveNext()) {
			T nextItem = enu.Current;
			K nextKey = selector(nextItem);
			if (comparer.Compare(nextKey, key) < 0) {
				item = nextItem;
				key = nextKey;
			}
		}

		return item;
	}

	public static T? MinBy<T, K>(this IEnumerable<T> source,
		Func<T, K> selector, IComparer<K>? comparer = null, T? Or = null) 
		where T: struct
	{
		using var enu = source.GetEnumerator();
		if (!enu.MoveNext()) return Or;

		T item = enu.Current;
		K key = selector(item);
		comparer ??= Comparer<K>.Default;

		while (enu.MoveNext()) {
			T nextItem = enu.Current;
			K nextKey = selector(nextItem);
			if (comparer.Compare(nextKey, key) < 0) {
				item = nextItem;
				key = nextKey;
			}
		}

		return item;
	}
}