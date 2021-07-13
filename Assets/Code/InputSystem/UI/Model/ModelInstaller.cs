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
        [SerializeField] private SelectedItemModel _selectedItemModel;
        [SerializeField] private AttackableTargetModel _dummyTarget;

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

            Container.Bind<IAwaitable<Vector3>>().FromInstance(_currentGroundClick).AsSingle();
            Container.Bind<IAwaitable<IAttackable>>().FromInstance(_dummyTarget).AsSingle();
            Container.Bind<AttackableTargetModel>().FromInstance(_dummyTarget).AsSingle();
            Container.Bind<SelectedItemModel>().FromInstance(_selectedItemModel).AsSingle();
        }

        #endregion
    }
}