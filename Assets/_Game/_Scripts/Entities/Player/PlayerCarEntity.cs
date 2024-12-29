using System;
using UnityEngine;
using Zenject;

public class PlayerCarEntity : MonoBehaviour
{
    [Inject] IInputDataProvider _inputDataProvider;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float swerveSpeed = 5f;
    [SerializeField] private float swerveLimit = 5f;
    [SerializeField] private float driftRotation = 15f;
    [SerializeField] private float rotationSmoothness = 0.1f;

    private float currentSwerve = 0f;
    private float currentRotation = 0f;
    private Vector3 initialPosition;
    private Transform _transform;
    public void Initialize()
    {
        initialPosition = transform.position;
        _transform = transform;
    }

    void Update()
    {
        _transform.Translate(Vector3.forward * speed * Time.deltaTime);

        currentSwerve += _inputDataProvider.HorizontalInput * swerveSpeed * Time.deltaTime;
        currentSwerve = Mathf.Clamp(currentSwerve, -swerveLimit, swerveLimit);

        Vector3 targetPosition = new Vector3(initialPosition.x + currentSwerve, _transform.position.y, _transform.position.z);
        _transform.position = targetPosition;

        float targetRotation = -_inputDataProvider.HorizontalInput * driftRotation;

        currentRotation = Mathf.Lerp(currentRotation, targetRotation, rotationSmoothness);
        _transform.rotation = Quaternion.Euler(0, currentRotation, 0);
    }
}
