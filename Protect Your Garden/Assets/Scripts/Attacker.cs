using UnityEngine;

public class Attacker : MonoBehaviour
{
    //[Range(0f, 5f)]
    private float currentSpeed = 1f;

    private void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }
}
