using Abstractions;
using UnityEngine;
using Utils;
using Zenject;


namespace Model
{
    public sealed class ModelInstaller : MonoInstaller
    {
        #region Fields

        [SerializeField] private AssetStorage _assets;
        [SerializeField] private GroundClickModel _currentGroundClick;

        #endregion


        #region Methods

        public override void InstallBindings()
        {
            Container.Bind<AssetStorage>().FromInstance(_assets).AsSingle();
            Container.Bind<GroundClickModel>().FromInstance(_currentGroundClick).AsSingle();

            Container.Bind<ControlButtonPanel>().AsSingle();
            Container.Bind<CommandCreator<IProduceUnitCommand>>().To<ProduceUnitCommandCreator>().AsSingle();
            Container.Bind<CommandCreator<IStopCommand>>().To<StopUnitCommandCreator>().AsSingle();
            Container.Bind<CommandCreator<IMoveCommand>>().To<MoveUnitCommandCreator>().AsSingle();
            Container.Bind<CommandCreator<IAttackCommand>>().To<AttackUnitCommandCreator>().AsSingle();
            Container.Bind<CommandCreator<IPatroulCommand>>().To<PatroulUnitCommandCreator>().AsSingle();
        }

        #endregion
    }
}