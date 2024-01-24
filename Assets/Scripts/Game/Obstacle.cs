using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Start() {
        GetComponent<AudioSource>().pitch = Random.Range(0.5f, 1f);
    }

    private void Update() {
        Move();

        if (transform.position.z < -30)
            Destroy(gameObject);
    }

    private void Move() {
        transform.Translate(_speed * Time.deltaTime * -Vector3.forward, Space.World);
    }
}
