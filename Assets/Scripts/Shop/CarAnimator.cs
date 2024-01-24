using System.Collections;
using UnityEngine;

public class CarAnimator : MonoBehaviour
{
    [SerializeField] private float _speed;

    private CarSwiper _swiper;

    private void Start() {
        _swiper = GetComponent<CarSwiper>();
        StartCoroutine(StartAnimation());
    }

    private IEnumerator StartAnimation() {
        Vector3 destinyPosition = Vector3.zero;
        yield return new WaitUntil(() => {
            transform.position = Vector3.MoveTowards(
                transform.position,
                destinyPosition,
                _speed * Time.deltaTime
                );

            return transform.position == destinyPosition;
        });
        _swiper.enabled = true;
    }

    public IEnumerator Switching() {
        _swiper.enabled = false;
        Quaternion destinyRotation = Quaternion.Euler(0, 180, 0);
        yield return new WaitUntil(() => {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                destinyRotation,
                _speed * Time.deltaTime * 7
                );

            return Quaternion.Equals(transform.rotation, destinyRotation);
        });

        Vector3 destinyPosition = new Vector3(0, 0, -24);
        yield return new WaitUntil(() => {
            transform.position = Vector3.MoveTowards(
                transform.position,
                destinyPosition,
                _speed * Time.deltaTime
                );

            return transform.position == destinyPosition;
        });

        Loop();
    }

    private void Loop() {
        transform.position = new Vector3(0, 0, 24);
        StartCoroutine(StartAnimation());
    }
}
