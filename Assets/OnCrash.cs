using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCrash : MonoBehaviour
{

    public WaypointManager wpManager;
    public MovementManager moveManager;
    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Waypoint")
        {
            transform.position = wpManager.currentWaypoint.transform.position;
            moveManager.canMove = false;
            StartCoroutine(timer.StartCrashCountdown(3.0f));
        }
    }

}
