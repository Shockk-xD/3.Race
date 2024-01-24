using UnityEngine;

public class SkinInfo : MonoBehaviour
{
    public new string name;
    public int price;

    private void OnValidate() {
        name = gameObject.name.Replace("(Clone)", "").Trim();
    }
}
