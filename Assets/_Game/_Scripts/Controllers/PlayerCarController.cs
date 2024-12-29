using UnityEngine;
using Zenject;

public class PlayerCarController : MonoBehaviour, IInitializable
{
    [SerializeField] private PlayerCarEntity playerCarEntity;
    public void Initialize()
    {
        if (playerCarEntity == null)
        {
            Debug.LogWarning("Player Car is not assigned. Please assign!");
            return;
        }
        playerCarEntity.Initialize();
    }
}
