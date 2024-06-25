using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject ShootingPoint;

    private const string PROJECTILE_PARENT_NAME = "Projectiles";

    private AttackerSpawner myLaneSpawner;
    private Animator animator;
    private GameObject projectileParent;

    private void Awake() => animator = GetComponent<Animator>();

    private void Start()
    {
        SetLaneSpawner();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);

        if (!projectileParent)
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
    }

    private void Update()
    {
        if (IsAttackerInLane())
            animator.SetBool("isAttacking", true);
        else
            animator.SetBool("isAttacking", false);
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (isCloseEnough)
                myLaneSpawner = spawner;
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner != null)
        {
            return myLaneSpawner.transform.childCount > 0;
        }
        return false;
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, ShootingPoint.transform.position, Quaternion.identity);
        newProjectile.transform.parent = projectileParent.transform;
    }
}
