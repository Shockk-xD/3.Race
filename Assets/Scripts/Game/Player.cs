using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _loseMenu;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _odometerText;

    public float passedDistance = 0;
    public int collectedCoins = 0;

    public void Lose() {
        GameManager.instance.Stop();

        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach(var audioSource in audioSources) {
            if (audioSource.gameObject.name != "Lose Menu")
                audioSource.enabled = false;
        }
        _loseMenu.SetActive(true);

        _scoreText.text = "Вы разбились\n" + "Собрано монет: " + collectedCoins;
        GameData.Balance += collectedCoins;
    }

    private void Update() {
        UpdateOdometer();
    }

    private void UpdateOdometer() {
        if (!GameManager.isPlaying) return;

        _odometerText.text = string.Format("{0:0.00} km", passedDistance);
    }
}
