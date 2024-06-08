using Inputs.Tower;
using NewInputSystem;
using Zenject;

namespace MonoInstallers
{
	public class InputInstaller : MonoInstaller
	{
		// ReSharper disable Unity.PerformanceAnalysis
		public override void InstallBindings()
		{
			Container.Bind<MainInputMap>().FromNew().AsSingle().NonLazy();
			Container.BindInterfacesAndSelfTo<InputTower>().AsSingle();
		}
	}
}
