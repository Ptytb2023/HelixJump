using System;
using UnityEngine;

namespace Interfaces
{
	public interface ICollisionHandler
	{
		public Vector3 PointContact { get; }
		
		public event Action<Collision> CollisionEnter;
	}
}