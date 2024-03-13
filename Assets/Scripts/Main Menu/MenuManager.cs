using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnPlayButtonClick() {
        SceneManager.LoadScene(1);
    }

    public void OnShopButtonClick() {
        SceneManager.LoadScene(2);
    }

    public void OnFreeRoadButtonClick() {
        SceneManager.LoadScene(3);
    }
}
