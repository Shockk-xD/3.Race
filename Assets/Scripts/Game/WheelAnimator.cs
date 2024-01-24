using UnityEngine;

public class WheelAnimator : MonoBehaviour
{
    [SerializeField] private float _spinSpeed;
    [SerializeField] private bool _isFrontWheel = false;


    private void Update() {
        if (_isFrontWheel)
            Turn();

        Spin();
    }

    private void Spin() {
        transform.Rotate(_spinSpeed * Time.deltaTime, 0, 0);
    }

    private void Turn() {
        transform.rotation = Quaternion.Euler(transform.rotation.x, 0, 0);
    }
}
