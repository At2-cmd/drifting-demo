using System;
using UnityEngine;

[Serializable]
public class CarDriftData
{
    [SerializeField] private float defaultSpeed;
    [SerializeField] private float pressedSpeed;
    [SerializeField] private float maxPressedSpeed;
    [SerializeField] private float speedLerpFactor;
    [SerializeField] private float swerveSpeed;
    [SerializeField] private float swerveLimit;
    [SerializeField] private float driftRotation;
    [SerializeField] private float rotationSmoothness;
    [SerializeField] private float releasedRotationSmoothness;
    [SerializeField] private float wheelTurnAngle;
    [SerializeField] private float wheelTurnSmoothness;
    [SerializeField] private float pressedMaxSpeedLerpDuration;

    public float DefaultSpeed => defaultSpeed;
    public float PressedSpeed => pressedSpeed;
    public float MaxPressedSpeed => maxPressedSpeed;
    public float SpeedLerpFactor => speedLerpFactor;
    public float SwerveSpeed => swerveSpeed;
    public float SwerveLimit => swerveLimit;
    public float DriftRotation => driftRotation;
    public float RotationSmoothness => rotationSmoothness;
    public float ReleasedRotationSmoothness => releasedRotationSmoothness;
    public float WheelTurnAngle => wheelTurnAngle;
    public float WheelTurnSmoothness => wheelTurnSmoothness;
    public float PressedMaxSpeedLerpDuration => pressedMaxSpeedLerpDuration;
}

