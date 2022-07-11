using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{
	[SerializeField] private GameObject winLabel;
    [SerializeField] private float waitToLoad = 4f;

	private int numberOfAttackers = 0;
	private bool levelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
		numberOfAttackers++;
    }

	public void AttackerKilled()
    {
		numberOfAttackers--;

		if(numberOfAttackers <= 0 && levelTimerFinished == true)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

	public void LevelTimerFinished()
    {
		levelTimerFinished = true;
		StopSpawners();
    }

	private void StopSpawners()
    {
		AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();

		foreach(AttackerSpawner spawner in spawnerArray)
        {
			spawner.StopSpawning();
        }
    }
}
