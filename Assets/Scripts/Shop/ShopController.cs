using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private CarAnimator _carAnimator;
    [SerializeField] private GameObject[] _skins;
    [SerializeField] private Transform _mainCarParent;
    [SerializeField] private Text _infoText;
    [SerializeField] private Text _mainButtonText;
    [SerializeField] private Animator _errorTextAnimator;
    [SerializeField] private Text _balanceText;

    private int _index = 0;

    private void Start() {
        StartCoroutine(ChangeSkin(true));
        UpdateBalanceText();

        UpdateMainButtonText();
    }

    public void ShowNextSkin() {
        SetNextIndex(+1);
        StopAllCoroutines();
        StartCoroutine(ChangeSkin(false));
    }

    public void ShowPreviousSkin() {
        SetNextIndex(-1);
        StopAllCoroutines();
        StartCoroutine(ChangeSkin(false));
    }

    private IEnumerator ChangeSkin(bool isFirstLaunch) {
        if (!isFirstLaunch) {
            yield return StartCoroutine(_carAnimator.Switching());

            if (_mainCarParent.childCount > 0) {
                var child = _mainCarParent.GetChild(0);
                Destroy(child.gameObject);
            }
        }

        Instantiate(_skins[_index], _mainCarParent);
        StartCoroutine(ChangeInfo());
    }

    private void SetNextIndex(int delta) {
        _index += delta;

        if (_index >= _skins.Length)
            _index = 0;
        else if (_index < 0)
            _index = _skins.Length - 1;
    }

    private IEnumerator ChangeInfo() {
        yield return new WaitForSeconds(0.1f);

        SkinInfo info = _mainCarParent.GetComponentInChildren<SkinInfo>();
        if (info != null)
            _infoText.text = info.name + "\n" + info.price + "$";
        UpdateMainButtonText();
    }

    public void OnBuyOrSelectButtonClick() {
        SkinInfo info = _mainCarParent.GetComponentInChildren<SkinInfo>();
        if (_mainButtonText.text == "Купить") {
            if (GameData.Balance >= info.price) {
                GameData.AddPurchasedSkin(info.name);
                GameData.Balance -= info.price;
                
                UpdateMainButtonText();
                UpdateBalanceText();
            } else
                _errorTextAnimator.SetTrigger("Play");
        } else if (_mainButtonText.text == "Выбрать") {
            GameData.SelectedSkin = info.name;

            UpdateMainButtonText();
        }
    }

    private void UpdateMainButtonText() {
        var skinName = _skins[_index].GetComponent<SkinInfo>().name;
        if (GameData.SelectedSkin == skinName)
            _mainButtonText.text = "Выбрано";
        else if (GameData.IsSkinPurchased(skinName))
            _mainButtonText.text = "Выбрать";
        else
            _mainButtonText.text = "Купить";
    }

    private void UpdateBalanceText() {
        _balanceText.text = $"{GameData.Balance}$";
    }
}
