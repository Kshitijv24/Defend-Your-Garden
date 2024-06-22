using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float damage = 50f;


    private void Update() => transform.Translate(Vector2.right * speed * Time.deltaTime);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        Attacker attacker = collision.GetComponent<Attacker>();
        
        if(attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
