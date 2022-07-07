using UnityEngine;

public class Gravestone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        Attacker attacker = otherCollider.GetComponent<Attacker>();
    }
}
