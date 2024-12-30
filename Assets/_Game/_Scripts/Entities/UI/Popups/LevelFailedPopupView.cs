public class LevelFailedPopupView : PopupBase
{
    public override void Initialize()
    {
        base.Initialize();
    }
    public void OnRetryLevelButtonClicked()
    {
        SetPopupActiveness(false);
        ShowBlackScreenOnTransition();
        EventController.Instance.RaiseRetryLevelButtonClicked();
    }
}
