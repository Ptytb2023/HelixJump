using UnityEngine;

namespace Extension
{
	public static class TransformExtension
	{
		private const Transform WorldParent = null;

		public static void ClearParent(this Transform transform) => 
			transform.SetParent(WorldParent);
	}
}