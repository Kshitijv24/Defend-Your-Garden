using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private int starCost = 100;

    public int GetStarCost() => starCost;

    public void AddStarsCaller(int amount) => FindObjectOfType<StarDisplay>().AddStars(amount);
}
