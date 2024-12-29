using UnityEngine;
using Zenject;

public class PlayerCarEntity : MonoBehaviour
{
    [Inject] IInputDataProvider _inputDataProvider;

    [SerializeField] private Transform frontLeftWheel;
    [SerializeField] private Transform frontRightWheel;

    [SerializeField] private float defaultSpeed = 10f;
    [SerializeField] private float pressedSpeed = 20f;
    [SerializeField] private float speedLerpFactor = 5f;

    [SerializeField] private float swerveSpeed = 5f;
    [SerializeField] private float swerveLimit = 5f;
    [SerializeField] private float driftRotation = 15f;
    [SerializeField] private float rotationSmoothness = 0.1f;

    [SerializeField] private float wheelTurnAngle = 30f; // Maximum wheel turn angle
    [SerializeField] private float wheelTurnSmoothness = 0.2f;

    private float _currentSpeed;
    private float _currentSwerve;
    private float _currentRotation;
    private float _targetSpeed;
    private float _targetRotation;
    private float _currentWheelAngle;
    private Vector3 _lastPosition;
    private Transform _transform;

    public void Initialize()
    {
        _transform = transform;
        _currentSpeed = defaultSpeed;
        _lastPosition = _transform.position;
    }

    void Update()
    {
        DetermineTargetSpeedByInput();
        MoveForward();

        if (_inputDataProvider.IsPressing)
        {
            HandleSwerve();
            HandleRotation();
            RotateWheels();
        }
        else
        {
            ReturnToDefaultRotation();
            ResetWheelRotation();
        }
    }

    private void MoveForward()
    {
        _transform.Translate(Vector3.forward * _currentSpeed * Time.deltaTime);
    }

    private void DetermineTargetSpeedByInput()
    {
        _targetSpeed = _inputDataProvider.IsPressing ? pressedSpeed : defaultSpeed;
        _currentSpeed = Mathf.Lerp(_currentSpeed, _targetSpeed, speedLerpFactor * Time.deltaTime);
    }

    private void HandleSwerve()
    {
        float swerveDelta = _inputDataProvider.HorizontalInput * swerveSpeed * Time.deltaTime;

        _currentSwerve += swerveDelta;
        _currentSwerve = Mathf.Clamp(_currentSwerve, -swerveLimit, swerveLimit);

        Vector3 targetPosition = new Vector3(_lastPosition.x + _currentSwerve, _transform.position.y, _transform.position.z);
        _transform.position = targetPosition;
    }

    private void HandleRotation()
    {
        _targetRotation = -_inputDataProvider.HorizontalInput * driftRotation;
        _currentRotation = Mathf.Lerp(_currentRotation, _targetRotation, rotationSmoothness);
        _transform.rotation = Quaternion.Euler(0, _currentRotation, 0);
    }

    private void RotateWheels()
    {
        float targetWheelAngle = _inputDataProvider.HorizontalInput * wheelTurnAngle;
        _currentWheelAngle = Mathf.Lerp(_currentWheelAngle, targetWheelAngle, wheelTurnSmoothness);

        // Apply rotation to wheels
        frontLeftWheel.localRotation = Quaternion.Euler(0, _currentWheelAngle, 0);
        frontRightWheel.localRotation = Quaternion.Euler(0, _currentWheelAngle, 0);
    }

    private void ResetWheelRotation()
    {
        _currentWheelAngle = Mathf.Lerp(_currentWheelAngle, 0, wheelTurnSmoothness);

        // Reset wheel rotation to default
        frontLeftWheel.localRotation = Quaternion.Euler(0, _currentWheelAngle, 0);
        frontRightWheel.localRotation = Quaternion.Euler(0, _currentWheelAngle, 0);
    }

    private void ReturnToDefaultRotation()
    {
        _targetRotation = 0f;
        _currentRotation = Mathf.Lerp(_currentRotation, _targetRotation, rotationSmoothness);
        _transform.rotation = Quaternion.Euler(0, _currentRotation, 0);

        _lastPosition = _transform.position;
        _currentSwerve = 0f;
    }
}
