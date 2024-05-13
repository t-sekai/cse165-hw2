using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public XROrigin player;
    public LineRenderer line;
    private Vector3 unit;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 0.8f, 0);
        unit = normalize(transform.position - (player.transform.position + offset));
        line.positionCount = 2;
        line.SetPosition(0, (player.transform.position + offset) + 0.3f * unit);
        line.SetPosition(1, (player.transform.position + offset) + 0.5f * unit);
    }

    // Update is called once per frame
    void Update()
    {
        unit = normalize(transform.position - (player.transform.position));
        line.SetPosition(0, (player.transform.position + offset)  + 0.3f * unit);
        line.SetPosition(1, (player.transform.position + offset) + 0.5f * unit);
    }

    Vector3 normalize (Vector3 pos)
    {
        float norm = Mathf.Sqrt(pos.x * pos.x + pos.y * pos.y + pos.z * pos.z);
        return pos / norm;
    }
}
