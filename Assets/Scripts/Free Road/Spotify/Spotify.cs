using UnityEngine;
using UnityEngine.UI;

public class Spotify : MonoBehaviour
{
    [SerializeField] private Lyric[] _lyrics;
    [SerializeField] private Text _currentLyricText;
    [SerializeField] private Animator _currentLyricTextAnimator;

    [Header("Info")]
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _currentTimelineText;

    [Space(10)]
    private float _timer = 0;
    private bool _isLyricChanged = false;

    private bool[] _lyricStates;
    private int _currentLyricIndex;

    private void Start() {
        _lyricStates = new bool[_lyrics.Length];
    }

    private void Update() {
        _timer += Time.deltaTime;

        for (int i = 0; i < _lyrics.Length; i++) {
            if (_lyricStates[i]) continue;

            if (_timer > _lyrics[i].from && !_isLyricChanged) {
                _currentLyricIndex = i;
                _currentLyricTextAnimator.SetTrigger("Change");
                _isLyricChanged = true;
            } else if (_timer > _lyrics[i].to) {
                _lyricStates[i] = true;
                _isLyricChanged = false;

                if (i == _lyrics.Length - 1) {
                    _currentLyricIndex = -1;
                    _currentLyricTextAnimator.SetTrigger("Change");
                }
            }
        }

        if (_timer <= 257f) {
            _currentTimelineText.text = (int)_timer / 60 + ":" + ((int)_timer % 60).ToString("00");
            _slider.value = (int)_timer;
        }
    }

    public void UpdateLyric() {
        if (_currentLyricIndex != -1) {
            _currentLyricText.text = "♪ " + _lyrics[_currentLyricIndex].text + " ♪";
        } else {
            _currentLyricText.text = "";
        }
    }
}
