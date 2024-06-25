using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] private int baseLives = 3;
    [SerializeField] private int damage = 1;

    private TextMeshProUGUI livesText;
    private int lives;

    private void Awake() => livesText = GetComponent<TextMeshProUGUI>();

    private void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        UpdateStarDisplay();
        Debug.Log("difficulty is currently set to " + PlayerPrefsController.GetDifficulty());
    }

    private void UpdateStarDisplay() => livesText.text = lives.ToString();

    public void TakeLife()
    {
        lives -= damage;
        UpdateStarDisplay();

        if (lives <= 0)
            LevelController.Instance.HandleLoseCondition();
    }
}
