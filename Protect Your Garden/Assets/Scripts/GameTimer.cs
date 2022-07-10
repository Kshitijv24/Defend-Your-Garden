using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in SECONDS")]
    [SerializeField] private float levelTimer = 10f;



    private void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTimer;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTimer);

        if(timerFinished == true)
        {
            Debug.Log("level timer expired");
        }
    }
}
