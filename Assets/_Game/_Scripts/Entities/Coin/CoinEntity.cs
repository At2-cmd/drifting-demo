using UnityEngine;
using Zenject;

public class CoinEntity : MonoBehaviour, IGenerateableObjectOnRoad
{
    [Inject] IUIController _uiController;
    private Pool _pool;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out PlayerCarEntity player))
        {
            _uiController.IncreaseCoins();
            Despawn();
        }
    }

    public void Despawn()
    {
        if (!gameObject.activeSelf) return;
        _pool.Despawn(this);
    }

    private void SetPool(Pool pool)
    {
        _pool = pool;
    }

    private void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public class Pool : MonoMemoryPool<Vector3, CoinEntity>
    {
        protected override void OnCreated(CoinEntity item)
        {
            base.OnCreated(item);
            item.SetPool(this);
        }

        protected override void Reinitialize(Vector3 position, CoinEntity item)
        {
            base.Reinitialize(position, item);
            item.SetPosition(position);
        }
    }
}
