using UnityEngine;

public class CarSoundController : MonoBehaviour
{
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    private AudioSource _engineSound;

    [SerializeField] private float _maxPitch;
    [SerializeField] private float _minPitch;
    private float _pitchFromCar;

    public static float currentSpeed;

    private void Start() {
        _engineSound = GetComponent<AudioSource>();
    }

    private void Update() {
        EngineSound();
    }

    private void EngineSound() {
        _pitchFromCar = Mathf.Clamp(currentSpeed, 0, 0.75f);

        if (currentSpeed <= _minSpeed)
            _engineSound.pitch = _minPitch;
        else if (currentSpeed > _minPitch && _maxPitch < currentSpeed)
            _engineSound.pitch = _minPitch + _pitchFromCar;
        else if (currentSpeed >= _maxSpeed)
            _engineSound.pitch = _maxPitch;
    }
}
