using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance { get; private set; }

    [SerializeField] private GameObject winLabel;
    [SerializeField] private GameObject loseLabel;
    [SerializeField] private float waitToLoad = 4f;

	private int numberOfAttackers = 0;
	private bool levelTimerFinished = false;
    private AttackerSpawner[] spawnerArray;
    private AudioSource audioSource;
    private LevelLoader levelLoader;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("There are more than one " + this.GetType() + " Instances", this);
            return;
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);

        spawnerArray = FindObjectsOfType<AttackerSpawner>();
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    public void AttackerSpawned() => numberOfAttackers++;

    public void AttackerKilled()
    {
		numberOfAttackers--;

		if(numberOfAttackers <= 0 && levelTimerFinished == true)
            StartCoroutine(HandleWinCondition());
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        audioSource.Play();
        yield return new WaitForSeconds(waitToLoad);
        levelLoader.LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

	public void LevelTimerFinished()
    {
		levelTimerFinished = true;
		StopSpawners();
    }

	private void StopSpawners()
    {
		foreach(AttackerSpawner spawner in spawnerArray)
            spawner.StopSpawning();
    }
}
