using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private float defaultVolume = 0.5f;

    [SerializeField] private Slider difficultySlider;
    [SerializeField] private int defaultDifficulty = 0;

    private MusicPlayer musicPlayer;

    private void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    private void Update()
    {
        if (musicPlayer)
            musicPlayer.SetVolume(volumeSlider.value);
        else
            Debug.LogWarning("No music player found... did you start form the splash screen?");
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty((int)difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
