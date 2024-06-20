using System;
using Interfaces;

namespace Ball
{
	public interface ICollisionBall : ICollisionHandler
	{
		public event Action CollisionObstacleEnter;
	}
}