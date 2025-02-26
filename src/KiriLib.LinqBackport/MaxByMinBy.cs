namespace KiriLib.LinqBackport;

public static partial class Enumerable
{
	public static T? MaxBy<T, K>(this IEnumerable<T> source,
		Func<T, K> selector, IComparer<K>? comparer = null) 
	{
		using var enu = source.GetEnumerator();
		if (!enu.MoveNext()) return (default(T) is null) ? default 
			: throw new InvalidOperationException($"sequence contains no element");

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

	public static T? MinBy<T, K>(this IEnumerable<T> source,
		Func<T, K> selector, IComparer<K>? comparer = null) 
	{
		using var enu = source.GetEnumerator();
		if (!enu.MoveNext()) return (default(T) is null) ? default 
			: throw new InvalidOperationException($"sequence contains no element");

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