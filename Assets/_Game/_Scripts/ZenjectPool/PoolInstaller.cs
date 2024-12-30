using UnityEngine;
using Zenject;

public class PoolInstaller : MonoInstaller
{
    [SerializeField] private NPCCarEntity npcCarEntity;
    [SerializeField] private CoinEntity coinEntity;
    public override void InstallBindings()
    {
        Container.BindMemoryPool<NPCCarEntity, NPCCarEntity.Pool>()
                .WithInitialSize(20)
                .ExpandByDoubling()
                .FromComponentInNewPrefab(npcCarEntity)
                .UnderTransformGroup("NPCCarsPool");
        
        Container.BindMemoryPool<CoinEntity, CoinEntity.Pool>()
                .WithInitialSize(20)
                .ExpandByDoubling()
                .FromComponentInNewPrefab(coinEntity)
                .UnderTransformGroup("CoinsPool");
    }
}