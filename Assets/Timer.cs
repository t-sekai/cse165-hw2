using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private bool raceStarted;
    private float raceTime;

    public TMPro.TMP_Text timeDisplay;
    public TMPro.TMP_Text countdownDisplay;
    public XROrigin player;
    public float countdown;
    public WaypointManager wpManager;
    public MovementManager moveManager;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCountdown(countdown));
        countdownDisplay.text = "Countdown Start";
        timeDisplay.text = "Time Elapsed: 0.00";

    }

    // Update is called once per frame
    void Update()
    {
        if (raceStarted)
        {
            if (wpManager.isFinalWaypoint)
            {
                raceStarted = false;
                timeDisplay.text = "Final Time: " + raceTime.ToString();
            }
            else
            {
                timeDisplay.text = "Time Elapsed: " + raceTime.ToString();
                raceTime += Time.deltaTime;
            }
        }
    }

    public IEnumerator StartCountdown(float countdown)
    {
        yield return new WaitForSeconds(3.0f);
        while (countdown >= 0)
        {
            countdownDisplay.text = countdown.ToString();
            yield return new WaitForSeconds(1.0f);
            countdown--;
        }
        raceStarted = true;
        moveManager.canMove = true;
        countdownDisplay.text = "";
    }

    public IEnumerator StartCrashCountdown(float countdown)
    {
        while (countdown >= 0)
        {
            countdownDisplay.text = countdown.ToString();
            yield return new WaitForSeconds(1.0f);
            countdown--;
        }
        moveManager.canMove = true;
        countdownDisplay.text = "";
    }
}
