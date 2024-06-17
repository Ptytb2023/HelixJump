using System.Collections.Generic;

namespace Extension
{
	public static class ReadOnlyListExtension
	{
		public static TSource Random<TSource>(this IReadOnlyList<TSource> collection)
		{
			int index = UnityEngine.Random.Range(0, collection.Count);
			return collection[index];
		}
		public static TSource Random<TSource>(this IReadOnlyList<TSource> collection,int min,int max)
		{
			int index = UnityEngine.Random.Range(min, max);
			return collection[index];
		}
	}
}