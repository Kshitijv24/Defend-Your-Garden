using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance { get; private set; }

    AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("There are more than one " + this.GetType() + " Instances", this);
            return;
        }

        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }

    private void Start() => audioSource.volume = PlayerPrefsController.GetMasterVolume();

    public void SetVolume(float volume) => audioSource.volume = volume;
}
