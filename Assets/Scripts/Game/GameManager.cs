using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Настройка начальной кат-сцены")]
    [SerializeField] private GameObject _car;
    [SerializeField] private GameObject _startBlocks;
    [SerializeField] private Animator _canvasCinemaAnimator;
    [SerializeField] private GameObject _pauseButton;

    [Header("Настройка UI")]
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _confirmMenu;
    [SerializeField] private GameObject _balance;
    [SerializeField] private Text _balanceText;

    public static GameManager instance;
    public static bool isPlaying = false;

    private Player _player;

    private void Start() {
        instance = this;
        _player = _car.GetComponent<Player>();
        StartCoroutine(StartAnimation());
        UpdateBalanceText();
    }

    public IEnumerator StartAnimation() {
        isPlaying = false;
        _car.transform.position = new Vector3(0, 0.25f, -45);
        Vector3 destiny = new Vector3(0, 0.25f, -6.5f);
        _canvasCinemaAnimator.gameObject.SetActive(true);
        float timer = 4;
        Text textCountdown = _canvasCinemaAnimator.GetComponentInChildren<Text>();

        yield return new WaitUntil(() => {
            timer -= Time.deltaTime;
            if (timer >= 1)
                textCountdown.text = "" + Mathf.Floor(timer);
            _car.transform.position = Vector3.Lerp(_car.transform.position, destiny, (4 - timer) / 4f * Time.deltaTime);
            return timer <= -0.5f;
        });
        isPlaying = true;
        textCountdown.text = "Go!";
        _canvasCinemaAnimator.SetTrigger("Fade");
        Destroy(_startBlocks);

        yield return new WaitForSeconds(1f);
        _pauseButton.SetActive(true);
        _balance.SetActive(true);
    }

    public void Stop() {
        isPlaying = false;
        Time.timeScale = 0;
    }

    public void Pause() {
        _confirmMenu.SetActive(false);
        _pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume() {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ConfirmToExit() {
        _confirmMenu.SetActive(true);
    }

    public void Restart() {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void ExitToMenu() {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void UpdateBalanceText() {
        _balanceText.text = $"{GameData.Balance} + {_player.collectedCoins}";
    }
}
