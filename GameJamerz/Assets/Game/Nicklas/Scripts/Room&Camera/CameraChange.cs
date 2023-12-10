using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [SerializeField] private Transform newLookAtTarget;
    [SerializeField] private Transform newFollowTarget;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ChangeRoomAngle();
        }
 
    }

    private void ChangeRoomAngle()
    {
        if (virtualCamera == null)
        {
            virtualCamera = Camera.main.GetComponent<CinemachineVirtualCamera>();
        }

        virtualCamera.LookAt = newLookAtTarget;
        virtualCamera.Follow = newFollowTarget;
    }
}

