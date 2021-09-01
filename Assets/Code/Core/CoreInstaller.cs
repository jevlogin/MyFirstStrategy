using CommandExecutors;
using UnityEngine;
using Zenject;


namespace Core
{
    public sealed class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TimeModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<ProduceUnitCommandExecutor>().FromComponentsInHierarchy().AsSingle();
        }
    }
}