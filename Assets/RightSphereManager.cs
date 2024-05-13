using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Hands;

public class RightSphereManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject rightSphere;
    [SerializeField] private XROrigin player;
    [SerializeField] private GameObject rightHand;

    public Vector3 savedPos;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!player.GetComponent<MovementManager>().isRightActive && XRHandDevice.rightHand != null)
        {
            Vector3 rightHandPinchPosition = XRHandDevice.rightHand.pinchPosition.value;
            rightSphere.transform.localPosition = rightHandPinchPosition;
            savedPos = rightSphere.transform.position;
        }
    }
}
