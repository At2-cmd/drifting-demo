using System;
using UnityEngine;
using Zenject;

public class PlayerCarEntity : MonoBehaviour
{
    [Inject] IInputDataProvider _inputDataProvider;

    [SerializeField] private CarCrashSimulator carCrashSimulator;
    [SerializeField] private Transform carModelTransform;
    [SerializeField] private Transform frontLeftWheel;
    [SerializeField] private Transform frontRightWheel;
    [SerializeField] private Transform bodyTransform;
    [SerializeField] private CarDriftData carDriftData;
    

    private float _currentSpeed;
    private float _currentSwerve;
    private float _currentRotation;
    private float _targetSpeed;
    private float _targetRotation;
    private float _currentWheelAngle;
    private Vector3 _lastPosition;
    private Vector3 _initialPosition;
    private Transform _transform;
    private bool _isCarInteractable;
    public void Initialize()
    {
        carCrashSimulator.Initialize();
        _transform = transform;
        _currentSpeed = carDriftData.DefaultSpeed;
        _lastPosition = _transform.position;
        _initialPosition = _transform.position;
    }

    void Update()
    {
        if (!_isCarInteractable) return;
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
        _targetSpeed = _inputDataProvider.IsPressing ? carDriftData.PressedSpeed : carDriftData.DefaultSpeed;
        _currentSpeed = Mathf.Lerp(_currentSpeed, _targetSpeed, carDriftData.SpeedLerpFactor * Time.deltaTime);
    }

    private void HandleSwerve()
    {
        float swerveDelta = _inputDataProvider.HorizontalInput * carDriftData.SwerveSpeed * Time.deltaTime;

        _currentSwerve += swerveDelta;
        _currentSwerve = Mathf.Clamp(_currentSwerve, -carDriftData.SwerveLimit, carDriftData.SwerveLimit);

        Vector3 targetPosition = new Vector3(_lastPosition.x + _currentSwerve, _transform.position.y, _transform.position.z);
        _transform.position = targetPosition;
    }

    private void HandleRotation()
    {
        _targetRotation = -_inputDataProvider.HorizontalInput * carDriftData.DriftRotation;
        _currentRotation = Mathf.Lerp(_currentRotation, _targetRotation, carDriftData.RotationSmoothness);
        carModelTransform.rotation = Quaternion.Euler(0, _currentRotation, 0);
        bodyTransform.localRotation = Quaternion.Euler(0, 0, _currentRotation);
    }

    private void RotateWheels()
    {
        float targetWheelAngle = _inputDataProvider.HorizontalInput * carDriftData.WheelTurnAngle;
        _currentWheelAngle = Mathf.Lerp(_currentWheelAngle, targetWheelAngle, carDriftData.WheelTurnSmoothness);

        frontLeftWheel.localRotation = Quaternion.Euler(0, _currentWheelAngle, 0);
        frontRightWheel.localRotation = Quaternion.Euler(0, _currentWheelAngle, 0);
    }

    private void ResetWheelRotation(bool isInstant = false)
    {
        if (!isInstant)
        {
            _currentWheelAngle = Mathf.Lerp(_currentWheelAngle, 0, carDriftData.WheelTurnSmoothness);
        }
        else
        {
            _currentWheelAngle = 0f;
        }

        frontLeftWheel.localRotation = Quaternion.Euler(0, _currentWheelAngle, 0);
        frontRightWheel.localRotation = Quaternion.Euler(0, _currentWheelAngle, 0);
    }

    private void ReturnToDefaultRotation(bool isInstant = false)
    {
        _targetRotation = 0f;
        if (!isInstant)
        {
            _currentRotation = Mathf.Lerp(_currentRotation, _targetRotation, carDriftData.ReleasedRotationSmoothness);
        }
        else
        {
            _currentRotation = 0f;
        }
        carModelTransform.rotation = Quaternion.Euler(0, _currentRotation, 0);
        bodyTransform.localRotation = Quaternion.Euler(0, 0, _currentRotation);

        _lastPosition = _transform.position;
        _currentSwerve = 0f;
    }

    public void SetCarInteractibility(bool value)
    {
        _isCarInteractable = value;
    }

    public void GetBackToInitialPosition()
    {
        transform.position = _initialPosition;
    }

    public void DeactivatePhysicsCrashSimulation()
    {
        ResetWheelRotation(true); 
        ReturnToDefaultRotation(true);
        transform.rotation = Quaternion.Euler(Vector3.zero);
        carModelTransform.localRotation = Quaternion.Euler(Vector3.zero);
        carCrashSimulator.DeactivatePhysics();
    }
}
