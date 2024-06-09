using System;
using UnityEngine;

namespace Ball
{
	public interface IBallCollision
	{
		public event Action<Vector3> EnterCollision;
	}
}