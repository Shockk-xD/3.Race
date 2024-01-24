using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnPlayButtonClick() {
        SceneManager.LoadScene(1);
    }
}
