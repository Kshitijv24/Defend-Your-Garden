using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] private float minSpawnDealy = 1f;
    [SerializeField] private float maxSpawnDealy = 5f;
    [SerializeField] private Attacker[] attackerPrefabArray;

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
        int attackerIndex = Random.Range(0, attackerPrefabArray.Length);

        Spawn(attackerPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, Quaternion.identity)
                    as Attacker;

        newAttacker.transform.parent = transform;
    }
}
