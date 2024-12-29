using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour, IInitializable, IGameManager
{
    [Inject] IUIController _uiController;
    [Inject] IPlayerCarController _playerCarController;
    public void Initialize()
    {
        Debug.Log("Game Manager Initialized");
    }
    public void OnGameSuccessed()
    {
        _playerCarController.SetCarInteractibility(false);
        _uiController.ShowSuccessPopup();
    }

    public void OnGameFailed()
    {
        _playerCarController.SetCarInteractibility(false);
        _uiController.ShowFailPopup();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) OnGameSuccessed();
        if (Input.GetKeyDown(KeyCode.F)) OnGameFailed();
    }
}
