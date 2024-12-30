public interface IUIController
{
    void ShowSuccessPopup();
    void ShowFailPopup();
    void ChangeSteeringViewRotation(float targetRotation);
    void IncreaseCoins();
    void SetTravelledPathText(int travelledAmount);
    void AdjustSpeedPanelView(float value, int minSpeed, int maxSpeed);
}
