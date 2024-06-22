using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake() => audioSource = GetComponent<AudioSource>();

    private void Start()
    {
        DontDestroyOnLoad(this);
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void SetVolume(float volume) => audioSource.volume = volume;
}
