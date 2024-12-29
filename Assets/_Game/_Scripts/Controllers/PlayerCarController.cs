using System;
using UnityEngine;
using Zenject;

public class PlayerCarController : MonoBehaviour, IInitializable, IPlayerCarController
{
    [SerializeField] private PlayerCarEntity playerCarEntity;
    public void Initialize()
    {
        Subscribe();
        if (playerCarEntity == null)
        {
            Debug.LogWarning("Player Car is not assigned. Please assign!");
            return;
        }
        playerCarEntity.Initialize();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }
    private void Subscribe()
    {
        EventController.Instance.OnBlackScreenOpened += OnBlackScreenOpenedHandler;
    }
    private void Unsubscribe()
    {
        EventController.Instance.OnBlackScreenOpened -= OnBlackScreenOpenedHandler;
    }

    private void OnBlackScreenOpenedHandler()
    {
        playerCarEntity.DeactivatePhysicsCrashSimulation();
        playerCarEntity.GetBackToInitialPosition();
    }

    public void SetCarInteractibility(bool value)
    {
        playerCarEntity.SetCarInteractibility(value);
    }
}
