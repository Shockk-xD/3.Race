using UnityEngine;

public class LyricChanger : MonoBehaviour
{
    [SerializeField] private Spotify _spotify;

    public void Change() {
        _spotify.UpdateLyric();
    }
}
