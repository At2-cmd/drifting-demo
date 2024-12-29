using UnityEngine;
using Zenject;

public class NPCCarEntity : MonoBehaviour
{
    private Pool _pool;

    private void OnSpawned()
    {

    }
    public void Despawn()
    {
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

    public class Pool : MonoMemoryPool<Vector3, NPCCarEntity>
    {
        protected override void OnCreated(NPCCarEntity item)
        {
            base.OnCreated(item);
            item.SetPool(this);
        }

        protected override void Reinitialize(Vector3 position, NPCCarEntity item)
        {
            base.Reinitialize(position, item);
            item.SetPosition(position);
            item.OnSpawned();
        }
    }
}
