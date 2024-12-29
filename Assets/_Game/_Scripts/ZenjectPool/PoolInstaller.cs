using UnityEngine;
using Zenject;

public class PoolInstaller : MonoInstaller
{
    [SerializeField] private NPCCarEntity npcCarEntity;
    public override void InstallBindings()
    {
        Container.BindMemoryPool<NPCCarEntity, NPCCarEntity.Pool>()
                .WithInitialSize(20)
                .ExpandByDoubling()
                .FromComponentInNewPrefab(npcCarEntity)
                .UnderTransformGroup("NPCCarsPool");
    }
}