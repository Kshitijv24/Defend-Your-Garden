using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;

        if (otherObject.GetComponent<Gravestone>())
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        else if (otherObject.GetComponent<Defender>())
            GetComponent<Attacker>().Attack(otherObject);
    }
}
