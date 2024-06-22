using UnityEngine;
using TMPro;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] private int stars = 100;
    private TextMeshProUGUI starText;

    private void Awake() => starText = GetComponent<TextMeshProUGUI>();

    private void Start() => UpdateStarDisplay();

    private void UpdateStarDisplay() => starText.text = stars.ToString();

    public bool HaveEnoughStars(int amount) => stars >= amount;

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateStarDisplay();
    }

    public void SpendStars(int amount)
    {
        if(stars >= amount)
        {
            stars -= amount;
            UpdateStarDisplay();
        }
    }
}
