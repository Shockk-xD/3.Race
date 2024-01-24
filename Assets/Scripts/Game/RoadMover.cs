using UnityEngine;

public class RoadMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private CarController _controller;

    private void Update() {
        if (GameManager.isPlaying) {
            Move();

            if (transform.position.z <= -30f)
                TeleportToBegin();
        }
    }

    private void Move() {
        transform.Translate((_moveSpeed + _controller.additionalRoadSpeed) * Time.deltaTime * -transform.forward);
    }

    private void TeleportToBegin() {
        transform.position = new Vector3(0, 0, 60f);
    }
}
