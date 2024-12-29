using UnityEngine;

public interface IInputDataProvider
{
    float VerticalInput { get; }
    float HorizontalInput { get; }
    bool IsPressing { get; }
    Vector3 GetMovementVector();
}
