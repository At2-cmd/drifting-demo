using UnityEngine;
using Zenject;

public class InputController : MonoBehaviour, IInitializable, IInputDataProvider
{
    private Vector3 _movementVector;
    public float HorizontalInput => Input.GetAxis("Horizontal");
    public float VerticalInput => Input.GetAxis("Vertical");

    public void Initialize(){}

    public Vector3 GetMovementVector()
    {
        _movementVector.x = HorizontalInput;
        _movementVector.y = 0f;
        _movementVector.z = VerticalInput;
        return _movementVector;
    }
}
