using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Parse : MonoBehaviour
{
	public TextAsset file;
	public List<Vector3> waypoints;
	public GameObject waypointModel;
	public XROrigin player;
	public List<GameObject> waypointObjects;

	// Start is called before the first frame update
	void Start()
	{
		waypoints = ParseFile();
		int index = 0;
		foreach (Vector3 wp in waypoints)
        {
			GameObject point = Instantiate(waypointModel, wp, Quaternion.identity);
			waypointObjects.Add(point);
			point.GetComponent<WaypointScript>().wpNum = index;
			index++;

		}

		waypointModel.SetActive(false);
		player.transform.position = waypoints[0];
        waypointObjects[0].GetComponent<WaypointScript>().hasReached = true;
		waypointObjects[0].transform.GetChild(2).GetComponent<MeshRenderer>().material.SetColor("_Color", Color.clear);
		waypointObjects[0].transform.GetChild(2).GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.green);
		waypointObjects[0].transform.GetChild(3).GetComponent<MeshRenderer>().material.SetColor("_Color", Color.clear);
		waypointObjects[0].transform.GetChild(3).GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.green);
	}

	// Update is called once per frame
	void Update()
	{

	}

	List<Vector3> ParseFile()
	{
		float ScaleFactor = 1.0f / 39.37f;
		List<Vector3> positions = new List<Vector3>();
		string content = file.ToString();
		string[] lines = content.Split('\n');
		for (int i = 0; i < lines.Length; i++)
		{
			string[] coords = lines[i].Split(' ');
			Vector3 pos = new Vector3(float.Parse(coords[0]), float.Parse(coords[1]), float.Parse(coords[2]));
			positions.Add(pos * ScaleFactor);
		}
		return positions;
	}
}
