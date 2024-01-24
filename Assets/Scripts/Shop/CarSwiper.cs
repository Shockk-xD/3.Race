using UnityEngine;

public class CarSwiper : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private bool _isSwiping;
    private bool _isMobile;

    private Vector2 _touchPosition;

    private void Start() {
        _isMobile = Application.isMobilePlatform;
    }

    private void Update() {
        if (_isMobile) {
            HandleMobileInput();
        } else {
            HandleDesktopInput();
        }
        CheckSwipe();
    }

    private void HandleMobileInput() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                _touchPosition = touch.position;
                if (_touchPosition.y > 226 && _touchPosition.y < 916)
                    _isSwiping = true;
            } else if (touch.phase == TouchPhase.Ended ||
                touch.phase == TouchPhase.Canceled)
                ResetSwipe();
        }
    }

    private void HandleDesktopInput() {
        if (Input.GetMouseButtonDown(0)) {
            _touchPosition = Input.mousePosition;
            if (_touchPosition.y > 226 && _touchPosition.y < 916)
                _isSwiping = true;
        } else if (Input.GetMouseButtonUp(0))
            ResetSwipe();
    }

    private void CheckSwipe() {
        if (_isSwiping) {
            float rotateAmount;

            if (_isMobile)
                rotateAmount = Input.GetTouch(0).deltaPosition.x;
            else
                rotateAmount = (Input.mousePosition.x - _touchPosition.x) * 0.1f;
            
            Rotate(rotateAmount);
        }

    }

    private void ResetSwipe() {
        _isSwiping = false;
        _touchPosition = Vector2.zero;
    }

    private void Rotate(float rotateAmount) {
        Vector3 currentRotation = transform.eulerAngles;
        Quaternion targetRotation = Quaternion.Euler(currentRotation.x, currentRotation.y + rotateAmount, currentRotation.z);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * _rotateSpeed);
    }
}
