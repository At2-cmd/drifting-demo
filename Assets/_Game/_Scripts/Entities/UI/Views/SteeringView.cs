using UnityEngine;

public class SteeringView : MonoBehaviour
{
    [SerializeField] private RectTransform _steeringImage;
    private float _rotationMultiplier = 5f;
    public void ChangeRotation(float targetRotation)
    {
        _steeringImage.rotation = Quaternion.Euler(0, 0, targetRotation * _rotationMultiplier);
    }
}
