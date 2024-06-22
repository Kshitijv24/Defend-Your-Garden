using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in SECONDS")]
    [SerializeField] private float levelTimer = 10f;

    private bool triggeredLevelFinished = false;
    private Slider slider;

    private void Awake() => slider = GetComponent<Slider>();

    private void Update()
    {
        if(triggeredLevelFinished == true) return;

        slider.value = Time.timeSinceLevelLoad / levelTimer;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTimer);

        if(timerFinished == true)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
