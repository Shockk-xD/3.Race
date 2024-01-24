using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private int _reward;

    private AudioSource _audioSource;

    private void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        transform.Rotate(0, _rotateSpeed * Time.deltaTime, 0);
        transform.Translate(_speed * Time.deltaTime * -Vector3.forward, Space.World);

        if (transform.position.z < -30)
            Destroy(gameObject);
    }

    public int RewardPlayer() {
        _audioSource.Play();
        StartCoroutine(PickedupAnimation());
        return _reward;
    }

    private IEnumerator PickedupAnimation() {
        GetComponentInChildren<Collider>().enabled = false;

        float duration = 3f;
        float timer = 0;
        float destinyY = transform.position.y + 4;
        Vector3 destinyScale = new Vector3(0.1f, 0.1f, 0.1f);

        yield return new WaitUntil(() => {
            timer += Time.deltaTime;
            float t = timer / duration;

            transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(
                    transform.position.x,
                    destinyY,
                    transform.position.z
                    ),
                t
                );
            transform.localScale = Vector3.MoveTowards(
                transform.localScale,
                destinyScale,
                t
                );
            return transform.localScale == destinyScale && transform.position.y == destinyY;
        });

        Destroy(gameObject);
    }
}
