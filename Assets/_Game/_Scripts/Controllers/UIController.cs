using System;
using UnityEngine;
using Zenject;

public class UIController : MonoBehaviour, IInitializable, IUIController
{
    [SerializeField] private PopupBase successPopupView;
    [SerializeField] private PopupBase failedPopupView;
    [SerializeField] private CarMovementActivator carMovementActivatorButton;
    [SerializeField] private SteeringView steeringView;
    public void Initialize()
    {
        Subscribe();
        carMovementActivatorButton.Initialize();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }
    private void Subscribe()
    {
        EventController.Instance.OnBlackScreenOpened += OnBlackScreenOpenedHandler;
        EventController.Instance.OnBlackScreenClosed += OnBlackScreenClosedHandler;
    }
    private void Unsubscribe()
    {
        EventController.Instance.OnBlackScreenOpened -= OnBlackScreenOpenedHandler;
        EventController.Instance.OnBlackScreenClosed -= OnBlackScreenClosedHandler;
    }

    private void OnBlackScreenClosedHandler()
    {
        carMovementActivatorButton.SetActivatorActiveness(true);
    }

    private void OnBlackScreenOpenedHandler()
    {

    }

    public void ShowSuccessPopup()
    {
        successPopupView.SetPopupActiveness(true);
        successPopupView.Initialize();
    }
    public void ShowFailPopup()
    {
        failedPopupView.SetPopupActiveness(true);
        failedPopupView.Initialize();
    }

    public void ChangeSteeringViewRotation(float targetRotation)
    {
        steeringView.ChangeRotation(targetRotation);
    }
}
