using Zenject;

public class GameManagerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<EventController>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesTo<GameManager>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesTo<InputController>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesTo<PlayerCarController>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesTo<RoadController>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesTo<UIController>().FromComponentInHierarchy().AsSingle();
    }
}