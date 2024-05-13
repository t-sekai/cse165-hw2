using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public GameObject currentWaypoint;
    public GameObject nextWaypoint;
    public int index; // next waypoint's index
    public Parse waypointList;
    public TMPro.TMP_Text wpNotif;
    public bool isFinalWaypoint;
    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFinalWaypoint)
        {
            return;
        }

        if (waypointList.waypointObjects.Count == 1)
        {
            wpNotif.text = "Congratulations!\n";
            isFinalWaypoint = true;
            return;
        }

        if (index == 0)
        {
            currentWaypoint = waypointList.waypointObjects[index];
            nextWaypoint = waypointList.waypointObjects[++index];
            nextWaypoint.transform.GetChild(0).GetComponent<LineRenderer>().enabled = true;
        }

        if (nextWaypoint.GetComponent<WaypointScript>().hasReached == true)
        {
            wpNotif.text = "Waypoint reached!\n" + (index+1).ToString() + "/" + waypointList.waypointObjects.Count;
            nextWaypoint.transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
            currentWaypoint = waypointList.waypointObjects[index];

            if (index < waypointList.waypointObjects.Count - 1)
            {
                nextWaypoint = waypointList.waypointObjects[++index];
                nextWaypoint.transform.GetChild(0).GetComponent<LineRenderer>().enabled = true;
            }
            else
            {
                wpNotif.text = "Congratulations!\n";
                isFinalWaypoint = true;
            }
            StartCoroutine(Delay());

        }
    }
    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(5.0f);
        wpNotif.text = "";
    }
}
