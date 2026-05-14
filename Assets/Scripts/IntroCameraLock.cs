using UnityEngine;

public class IntroCameraLock : MonoBehaviour
{
    public Transform introCameraPoint;
    public Transform playerCamera;

    public MonoBehaviour playerMovementScript;

    public bool lockMovementAtStart = true;

    void Start()
    {
        if (lockMovementAtStart)
        {
            LockMovementOnly();
        }
    }

    public void LockMovementOnly()
    {
        if (playerMovementScript != null)
            playerMovementScript.enabled = false;

        if (introCameraPoint != null && playerCamera != null)
        {
            playerCamera.position = introCameraPoint.position;
            playerCamera.rotation = introCameraPoint.rotation;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockMovement()
    {
        if (playerMovementScript != null)
            playerMovementScript.enabled = true;
    }
}
