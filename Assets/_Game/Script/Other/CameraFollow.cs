using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 gameCameraOffset;
    public Vector3 uiCameraOffset;
    public float smoothFactor = 0.5f;
    public bool lookAtTarget = false;
    public Button playButton;

    private Vector3 currentCameraOffset;

    void Start()
    {
        currentCameraOffset = uiCameraOffset;
        playButton.onClick.AddListener(SwitchToGameCamera);
    }

    void LateUpdate()
    {
        Vector3 newPosition = targetObject.transform.position + currentCameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);

        if (lookAtTarget)
        {
            transform.LookAt(targetObject);
        }
    }

    public void SwitchToUICamera()
    {
        currentCameraOffset = uiCameraOffset;
        transform.rotation = Quaternion.Euler(new Vector3(15, 1, 0));
    }

    public void SwitchToGameCamera()
    {
        currentCameraOffset = gameCameraOffset;
        transform.rotation = Quaternion.Euler(new Vector3(55, 1, 0));
    }
}
