using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] private float minSpawnDealy = 1f;
    [SerializeField] private float maxSpawnDealy = 5f;
    [SerializeField] private Attacker attackerPrefab;

    private bool spawn = true;

    private IEnumerator Start()
    {
        while(spawn == true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDealy, maxSpawnDealy));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Instantiate(attackerPrefab, transform.position, Quaternion.identity);
    }
}
