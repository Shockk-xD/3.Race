using UnityEngine;
using UnityEngine.UIElements;

public class CarController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _forwardForce;

    private float _defaultForwardForce;
    private Player _player;

    public float additionalRoadSpeed = 0;

    private void Start() {
        _defaultForwardForce = _forwardForce;
        _player = GetComponent<Player>();
    }

    private void Update() {
        if (!GameManager.isPlaying) return;

        Move();
        ClampPosition();
        MoveBackward();
        Rotate();
    }

    private void Move() {
        float verticalSpeed = Input.GetAxis("Vertical");
        CarSoundController.currentSpeed = Mathf.Abs(verticalSpeed);

        if (verticalSpeed > 0) {
            _forwardForce = 0;
            transform.position += verticalSpeed * _speed * Time.deltaTime * Vector3.forward;
            additionalRoadSpeed = 5 * verticalSpeed;
        } else if (verticalSpeed == 0) 
            _forwardForce = _defaultForwardForce;

        float horizontalSpeed = Input.GetAxis("Horizontal");
        transform.position += _turnSpeed * horizontalSpeed * Time.deltaTime * Vector3.right;

        _player.passedDistance += Time.deltaTime * 0.5f;
    }

    private void ClampPosition() {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -4, 4),
            transform.position.y,
            Mathf.Clamp(transform.position.z, -9.75f, -7.25f)
            );
    }

    private void MoveBackward() {
        transform.position += _forwardForce * Time.deltaTime * -Vector3.forward;
    }

    private void Rotate() {
        float horizontalSpeed = Input.GetAxis("Horizontal");
        float targetRotation = horizontalSpeed * 30f;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, targetRotation, transform.rotation.z), Time.deltaTime * 100);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Obstacle")) {
            _player.Lose();
        } else if (other.CompareTag("Coin")) {
            Coin coin = other.GetComponentInParent<Coin>();
            _player.collectedCoins += coin.RewardPlayer();
            GameManager.instance.UpdateBalanceText();
        }
    }
}
