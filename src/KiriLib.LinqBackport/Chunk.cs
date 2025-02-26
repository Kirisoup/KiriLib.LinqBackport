namespace KiriLib.LinqBackport;

public static partial class Enumerable
{
	public static IEnumerable<T[]> Chunk<T>(this T[] src, int size) {
		for (
			int i = 0, csize = Math.Min(size, src.Length - i); 
			i < src.Length; 
			i += csize
		) {
			T[] chunk = new T[csize];
			Array.Copy(src, i, chunk, 0, csize);
			yield return chunk;
		}
	}

	public static IEnumerable<T[]> Chunk<T>(this IEnumerable<T> src, int size) {
		using IEnumerator<T> enu = src.GetEnumerator();
		while (enu.MoveNext()) {
			List<T> chunk = new(Math.Min(size, 4));
			chunk.Add(enu.Current);	
			for (int i = 1; i < size && enu.MoveNext(); i++) {
				chunk.Add(enu.Current);
			}
			yield return chunk.ToArray();
		}
	}
}