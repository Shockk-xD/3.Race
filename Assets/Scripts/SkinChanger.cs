using System.Linq;
using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject[] _skins;
    [SerializeField] private Vector3 _position;
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private Vector3 _scale;

    private void Awake() {
        SetSkin();
    }

    private void SetSkin() {
        foreach (var skin in _skins) {
            if (skin.name == GameData.SelectedSkin) {
                var newSkin = Instantiate(skin, _parent.transform);
                newSkin.transform.SetLocalPositionAndRotation(_position, Quaternion.Euler(_rotation));
                newSkin.transform.localScale = _scale;
            }
        }
    }
}
