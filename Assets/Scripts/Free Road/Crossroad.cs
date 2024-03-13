using UnityEngine;

public class Crossroad : MonoBehaviour
{
    [SerializeField] private GameObject _caseA;
    [SerializeField] private GameObject _caseB;
    [SerializeField] private GameObject _road;

    [SerializeField] private bool _isCaseA;

    private void OnTriggerEnter(Collider other) {
        if (_isCaseA) {
            _caseA.SetActive(false);
            _caseB.SetActive(true);
            _road.transform.localRotation = Quaternion.Euler(0, 90, 0);
        } else {
            _caseA.SetActive(true);
            _caseB.SetActive(false);
            _road.transform.localRotation = Quaternion.Euler(Vector3.zero);
        }
    }
}
