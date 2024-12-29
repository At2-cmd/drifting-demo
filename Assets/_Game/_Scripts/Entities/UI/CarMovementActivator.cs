using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CarMovementActivator : MonoBehaviour
{
    [Inject] IPlayerCarController _playerCarController;
    [SerializeField] private Button button;

    public void Initialize()
    {
        button.onClick.AddListener(OnActivatorClicked);
    }

    private void OnActivatorClicked()
    {
        _playerCarController.SetCarInteractibility(true);
        SetActivatorActiveness(false);
    }

    public void SetActivatorActiveness(bool value)
    {
        gameObject.SetActive(value);
    }
}
