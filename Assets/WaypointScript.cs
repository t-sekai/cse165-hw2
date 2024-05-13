using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    public WaypointManager wpManager;
    public bool hasReached;
    public int wpNum;
    public GameObject model1;
    public GameObject model2;

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
        if (other.tag == "Player" && !hasReached && wpNum == wpManager.index)
        {
            hasReached = true;
            model1.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.clear);
            model1.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.green);
            model2.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.clear);
            model2.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.green);
        }
    }
}