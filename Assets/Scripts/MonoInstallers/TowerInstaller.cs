using Tower;
using UnityEngine;
using Zenject;

namespace MonoInstallers
{
	public class TowerInstaller: MonoInstaller
	{
		[SerializeField] private TowerView _tower;
		
		public override void InstallBindings()
		{
		}
	}
}