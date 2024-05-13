using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Toggle : MonoBehaviour
{

    public GameObject drone;
    public GameObject cockpit;
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private XROrigin player;
    [SerializeField] private GameObject leftSphere;
    [SerializeField] private GameObject rightSphere;
    private InputAction leftPinch;

    public int perspective; // is the left hand pinching

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = player.Camera.transform.rotation;

        leftPinch = actionAsset.FindActionMap("XRI LeftHand Interaction").FindAction("Perspective");
        leftPinch.Enable();
        leftPinch.started += OnPressLeftPinch;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnPressLeftPinch(InputAction.CallbackContext context)
    {
        switch(perspective)
        {
            case 2:
                perspective = 0;
                drone.SetActive(false);
                cockpit.SetActive(false);
                player.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, 0);
                return;
            case 0:
                perspective++;
                drone.SetActive(false);
                cockpit.SetActive(true);
                player.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, 0);
                return;
            case 1:
                perspective++;
                drone.SetActive(true);
                cockpit.SetActive(false);
                player.transform.GetChild(0).transform.localPosition = new Vector3(0, 0.75f, -2.5f);
                return;
            default:
                return;
        }
    }
}
