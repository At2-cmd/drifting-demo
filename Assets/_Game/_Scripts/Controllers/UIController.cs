using System;
using TMPro;
using UnityEngine;
using Zenject;

public class UIController : MonoBehaviour, IInitializable, IUIController
{
    [SerializeField] private PopupBase successPopupView;
    [SerializeField] private PopupBase failedPopupView;
    [SerializeField] private CarMovementActivator carMovementActivatorButton;
    [SerializeField] private SteeringView steeringView;
    [SerializeField] private CoinsPanelView coinsPanel;
    [SerializeField] private TraveledPathPanel travelledPathPanel;
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
        coinsPanel.ResetCoins();
        travelledPathPanel.ResetTravelledPath();
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

    public void IncreaseCoins()
    {
        coinsPanel.IncreaseCoins();
    }

    public void SetTravelledPathText(int travelledAmount)
    {
        travelledPathPanel.SetTravelledPathText(travelledAmount);
    }
}
