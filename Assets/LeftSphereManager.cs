using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Hands;

public class LeftSphereManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject leftSphere;
    [SerializeField] private XROrigin player;
    [SerializeField] private GameObject leftHand;

    public Vector3 savedPos;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!player.GetComponent<MovementManager>().isLeftActive && XRHandDevice.leftHand != null)
        {
            Vector3 leftHandPinchPosition = XRHandDevice.leftHand.pinchPosition.value;
            leftSphere.transform.localPosition = leftHandPinchPosition;
            savedPos = leftSphere.transform.position;
        }
    }
}
