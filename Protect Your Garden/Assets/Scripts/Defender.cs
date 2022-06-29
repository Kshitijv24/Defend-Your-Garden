using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private int starCost = 100;

    public void AddStarsCaller(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }
}
