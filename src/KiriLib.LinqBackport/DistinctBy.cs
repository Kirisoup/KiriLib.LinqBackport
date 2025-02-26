namespace KiriLib.LinqBackport;

public static partial class Enumerable
{
	public static IEnumerable<T> DistinctBy<T, K>(
		this IEnumerable<T> src, 
		Func<T, K> keySel
	) where K: IEquatable<K> =>
		DistinctBy_Common(set: [], src, keySel);

	public static IEnumerable<T> DistinctBy<T, K>(
		this IEnumerable<T> src, 
		Func<T, K> keySel, 
		IEqualityComparer<K>? cmp
	) => DistinctBy_Common(
		set: new(cmp ?? EqualityComparer<K>.Default), 
		src, keySel);

	private static IEnumerable<T> DistinctBy_Common<T, K>(
		HashSet<K> set,
		IEnumerable<T> source, 
		Func<T, K> keySel
	) {
		using var enu = source.GetEnumerator();
		if (!enu.MoveNext()) yield break;
		do {
			T item = enu.Current;
			if (set.Add(keySel(enu.Current))) yield return item;
		} while (enu.MoveNext());
	}
}