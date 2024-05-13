using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private GameObject leftSphere;
    [SerializeField] private GameObject rightSphere;
    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject rightHand;
    [SerializeField] private Toggle toggle;
    private InputAction leftPinch;
    private InputAction rightPinch;

    public bool isLeftActive; // is the left hand pinching
    public bool isRightActive; // is the right hand 
    public bool canMove;

    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = transform.forward;

        leftPinch = actionAsset.FindActionMap("XRI LeftHand Interaction").FindAction("Select");
        leftPinch.Enable();
        leftPinch.started += OnPressLeftPinch;
        leftPinch.canceled += OnReleaseLeftPinch;

        rightPinch = actionAsset.FindActionMap("XRI RightHand Interaction").FindAction("Select");
        rightPinch.Enable();
        rightPinch.started += OnPressRightPinch;
        rightPinch.canceled += OnRleaseRightPinch;

        
    }

    // Update is called once per frame
    void Update()
    {

        if(isRightActive)// && !isLeftActive)
        {
            if(toggle.perspective==2) // slow rotate speed for drone, don't think this is necessary anymore tho
            {
                rotate(0.04f); 
            }
            else
            {
                rotate(0.05f);
            }
            
        }
        else
        {
            dir = transform.forward;
        }

        if (isLeftActive && canMove)
        {
            move();
        }
    }

    private void move()
    {
        float velocity = Mathf.Clamp(1.5f*(XRHandDevice.leftHand.pinchPosition.value - leftSphere.transform.localPosition).z, 0, 1);
        transform.position += velocity*velocity * dir;
    }

    private void rotate(float scale)
    {
        Vector3 dist = XRHandDevice.rightHand.pinchPosition.value - rightSphere.transform.localPosition;
        dist.z = Mathf.Clamp(dir.z, 0, float.MaxValue);
        dir = dist.normalized;
        dir = transform.TransformDirection(dir);

        Vector3 rot_dir = dir;
        rot_dir.y = 0;
        rot_dir = rot_dir.normalized;
        Quaternion lookAt = Quaternion.LookRotation(rot_dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookAt, scale * dist.magnitude);
    }

    void OnPressLeftPinch(InputAction.CallbackContext context)
    {
        isLeftActive = true;
    }

    void OnReleaseLeftPinch(InputAction.CallbackContext context)
    {
        isLeftActive = false;
    }

    void OnPressRightPinch(InputAction.CallbackContext context)
    {
        isRightActive = true;
    }

    void OnRleaseRightPinch(InputAction.CallbackContext context)
    {
        isRightActive = false;
    }
}
