using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
	private const string MASTER_VOLUME_KEY = "Master Volume";
	private const string DIFFICULTY_KEY = "Difficulty";

	private const float MIN_VOLUME = 0f;
	private const float MAX_VOLUME = 1f;

	private const int MIN_DIFFICULTY = 0;
	private const int MAX_DIFFICULTY = 2;

	public static void SetMasterVolume(float volume)
    {
		if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
			Debug.Log("Master Volume set to " + volume);
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		}
        else
            Debug.LogError("Master volume is out of range");
    }

    public static float GetMasterVolume() => PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);

    public static void SetDifficulty(int difficulty)
    {
		if(difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
            PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
        else
            Debug.LogError("Difficulty settings not in range");
    }

    public static int GetDifficulty() => PlayerPrefs.GetInt(DIFFICULTY_KEY);
}
