using RootMotion;
using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class StartAnimation : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Image _panel;
    [SerializeField] private GameObject _car;
    [SerializeField] private GameObject _carLight;

    [SerializeField] private Animator _curtainsAnimator;
    [SerializeField] private Animator _spotifyAnimator;

    [SerializeField] private CarControl _carControl;
    [SerializeField] private WheelControl[] _wheelControls;

    [SerializeField] private GameObject _directionalLight;

    private void Start() {
        StartCoroutine(Animation());
    }

    private IEnumerator Animation() {
        _directionalLight.transform.rotation = Quaternion.Euler(new Vector3(-70.45f, 189.08f, -129.8f));

        _panel.color = Color.black;

        Vector3 cameraStartPosition = new Vector3(47.9f, 49.9f, -83.06f);
        Vector3 cameraStartRotation = new Vector3(-25.35f, 41.72f, 0f);
        _mainCamera.transform.SetLocalPositionAndRotation(
            cameraStartPosition,
            Quaternion.Euler(cameraStartRotation)
            );

        yield return new WaitForSeconds(4.0f);

        Vector3 cameraDestinyRotation = new Vector3(25.13f, -8.29f, 2.69f);
        for (float time = 0f; time < 5f; time += Time.deltaTime) {
            float t = time / 5f;

            _panel.color = Color.Lerp(Color.black, new Color(0f, 0f, 0f, 0f), t);
            _mainCamera.transform.localRotation = Quaternion.Lerp(
                Quaternion.Euler(cameraStartRotation),
                Quaternion.Euler(cameraDestinyRotation),
                t
                );
            yield return null;
        }

        Vector3 carStartPosition = new Vector3(120.12f, 1, -74.23f);
        Vector3 carStartRotation = new Vector3(0, 180, 0);

        Vector3 cameraPosition1 = new Vector3(120.13f, 0.7f, -79.55f);
        Vector3 cameraRotation1 = Vector3.zero;

        _car.transform.SetPositionAndRotation(
            carStartPosition,
            Quaternion.Euler(carStartRotation)
            );
        _mainCamera.transform.SetPositionAndRotation(
            cameraPosition1,
            Quaternion.Euler(cameraRotation1)
            );

        yield return new WaitForSeconds(1.8f);

        _carLight.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        Vector3 carPosition1 = new Vector3(120.12f, 1, -92f);
        Vector3 carRotation1 = carStartRotation;
        Vector3 cameraPosition2 = new Vector3(120.13f, 0.7f, -99f);
        for (float timer = 0; timer < 3f; timer += Time.deltaTime) {
            float t = timer / 3f;

            _car.transform.position = Vector3.Lerp(carStartPosition, carPosition1, t);
            _mainCamera.transform.position = Vector3.Lerp(
                cameraPosition1,
                cameraPosition2,
                t
                );

            yield return null;
        }

        Vector3 cameraPosition3 = new Vector3(128.94f, 6.34f, -95.58f);
        Vector3 cameraRotation3 = new Vector3(20.4f, -140f, 0);
        _mainCamera.transform.SetPositionAndRotation(
            cameraPosition3,
            Quaternion.Euler(cameraRotation3)
            );

        Vector3 carPosition2 = new Vector3(119.87f, 1f, -102.5f);
        Vector3 carRotation2 = new Vector3(0, 202.21f, 0);

        for (float timer = 0f; timer < 1f; timer += Time.deltaTime) {
            float t = timer / 1f;

            _car.transform.SetPositionAndRotation(
                    Vector3.Lerp(
                    carPosition1,
                    carPosition2,
                    t
                    ),
                    Quaternion.Lerp(
                    Quaternion.Euler(carRotation1),
                    Quaternion.Euler(carRotation2),
                    t)
                );

            yield return null;
        }

        Vector3 carPosition3 = new Vector3(116.41f, 1f, -109.1f);
        Vector3 carRotation3 = new Vector3(0, 217.15f, 0);

        for (float timer = 0f; timer < 1f; timer += Time.deltaTime) {
            float t = timer / 1f;

            _car.transform.SetPositionAndRotation(
                    Vector3.Lerp(
                    carPosition2,
                    carPosition3,
                    t
                    ),
                    Quaternion.Lerp(
                    Quaternion.Euler(carRotation2),
                    Quaternion.Euler(carRotation3),
                    t)
                );

            yield return null;
        }

        Vector3 carPosition4 = new Vector3(109.86f, 1f, -115.72f);
        Vector3 carRotation4 = new Vector3(0, 237.46f, 0);

        for (float timer = 0f; timer < 1f; timer += Time.deltaTime) {
            float t = timer / 1f;

            _car.transform.SetPositionAndRotation(
                    Vector3.Lerp(
                    carPosition3,
                    carPosition4,
                    t
                    ),
                    Quaternion.Lerp(
                    Quaternion.Euler(carRotation3),
                    Quaternion.Euler(carRotation4),
                    t)
                );

            yield return null;
        }

        Vector3 carPosition5 = new Vector3(98.5f, 1f, -119.4f);
        Vector3 carRotation5 = new Vector3(0, 268.48f, 0);

        for (float timer = 0f; timer < 1f; timer += Time.deltaTime) {
            float t = timer / 1f;

            _car.transform.SetPositionAndRotation(
                    Vector3.Lerp(
                    carPosition4,
                    carPosition5,
                    t
                    ),
                    Quaternion.Lerp(
                    Quaternion.Euler(carRotation4),
                    Quaternion.Euler(carRotation5),
                    t)
                );

            yield return null;
        }

        Vector3 carPosition6 = new Vector3(89.32f, 1f, -119.6f);
        Vector3 carRotation6 = new Vector3(0, 268.48f, 0);

        for (float timer = 0f; timer < 1f; timer += Time.deltaTime) {
            float t = timer / 1f;

            _car.transform.SetPositionAndRotation(
                    Vector3.Lerp(
                    carPosition5,
                    carPosition6,
                    t
                    ),
                    Quaternion.Lerp(
                    Quaternion.Euler(carRotation5),
                    Quaternion.Euler(carRotation6),
                    t)
                );

            yield return null;
        }

        Vector3 cameraPosition4 = new Vector3(78.33f, 0.08f, -119.64f);
        Vector3 cameraRotation4 = new Vector3(-15.32f, 90, 0);
        _mainCamera.transform.SetPositionAndRotation(
            cameraPosition4,
            Quaternion.Euler(cameraRotation4)
            );

        Vector3 carPosition7 = new Vector3(75.88f, 1f, -119.99f);
        Vector3 carRotation7 = new Vector3(0, 268.48f, 0);

        for (float timer = 0f; timer < 1f; timer += Time.deltaTime) {
            float t = timer / 1f;

            _car.transform.SetPositionAndRotation(
                    Vector3.Lerp(
                    carPosition6,
                    carPosition7,
                    t
                    ),
                    Quaternion.Lerp(
                    Quaternion.Euler(carRotation6),
                    Quaternion.Euler(carRotation7),
                    t)
                );

            yield return null;
        }

        Vector3 cameraPosition5 = new Vector3(78.33f, 4f, -119.99f);
        Vector3 cameraRotation5 = new Vector3(0, -90, 0);
        _mainCamera.transform.SetPositionAndRotation(
            cameraPosition5,
            Quaternion.Euler(cameraRotation5)
            );

        Vector3 carPosition8 = new Vector3(35f, 1f, -119.99f);
        Vector3 carRotation8 = new Vector3(0, 271.24f, 0);

        for (float timer = 0f; timer < 5f; timer += Time.deltaTime) {
            float t = timer / 5f;

            _car.transform.SetPositionAndRotation(
                    Vector3.Lerp(
                    carPosition7,
                    carPosition8,
                    t
                    ),
                    Quaternion.Lerp(
                    Quaternion.Euler(carRotation7),
                    Quaternion.Euler(carRotation8),
                    t)
                );

            yield return null;
        }

        _carLight.SetActive(false);

        Vector3 cameraPosition6 = new Vector3(0, 6.61f, 1.1f);
        Vector3 cameraRotation6 = new Vector3(0, 180, 0);
        _mainCamera.transform.SetPositionAndRotation(
            cameraPosition6,
            Quaternion.Euler(cameraRotation6)
            );

        Vector3 carPosition9 = new Vector3(0, 1f, -55.5f);
        Vector3 carRotation9 = Vector3.zero;

        Vector3 carPosition10 = new Vector3(0, 1f, 10.5f);
        Vector3 carRotation10 = Vector3.zero;

        for (float timer = 0f; timer < 6f; timer += Time.deltaTime) {
            float t = timer / 6f;

            _car.transform.SetPositionAndRotation(
                    Vector3.Lerp(
                    carPosition9,
                    carPosition10,
                    t
                    ),
                    Quaternion.Lerp(
                    Quaternion.Euler(carRotation9),
                    Quaternion.Euler(carRotation10),
                    t)
                );

            _mainCamera.transform.LookAt(_car.transform);
            yield return null;
        }


        _curtainsAnimator.SetTrigger("Off");
        for (int i = 0; i < _wheelControls.Length; i++) {
            _wheelControls[i].enabled = true;
        }
        _carControl.enabled = true;
        _car.GetComponent<Rigidbody>().isKinematic = false;
        _mainCamera.GetComponent<CameraController>().enabled = true;

        Vector3 cameraPosition7 = new Vector3(0.07f, 4.27f, 1.27f);
        Vector3 cameraRotation7 = new Vector3(10.4f, 0f, 0f);
        _mainCamera.transform.SetPositionAndRotation(
            cameraPosition7,
            Quaternion.Euler(cameraRotation7)
            );

        _spotifyAnimator.SetTrigger("Show");
        StartCoroutine(LightAnimation());
    }

    private IEnumerator LightAnimation() {
        Vector3 startEulerAngles = new Vector3(-70.45f, 189.08f, -129.8f);
        Quaternion startQuaternion = Quaternion.Euler(startEulerAngles);

        Vector3 destinyEulerAngles = new Vector3(47.46f, 99.29f, -7.64f);
        Quaternion destinyQuaternion = Quaternion.Euler(destinyEulerAngles);

        for (float s = 0; s <= 10; s += Time.deltaTime) {
            float t = s / 10;

            _directionalLight.transform.rotation = Quaternion.Slerp(
                startQuaternion,
                destinyQuaternion,
                t
                );

            yield return null;
        }
    }
}
