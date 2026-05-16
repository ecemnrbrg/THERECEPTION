using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform targetCamera;

    void LateUpdate()
    {
        if (targetCamera == null)
            return;

        Vector3 direction = targetCamera.position - transform.position;

        direction.y = 0f;

        transform.forward = -direction;
    }
}