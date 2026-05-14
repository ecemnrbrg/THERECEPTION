using UnityEngine;

public class FPSController : MonoBehaviour
{
    public bool canMove = true;
    public CharacterController controller;
    public Transform playerCamera;

    public float startCameraRotationX = 0f;
    public float moveSpeed = 3f;
    public float mouseSensitivity = 150f;
    public float gravity = -9.81f;

    private float xRotation = 0f;
    private Vector3 velocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        xRotation = startCameraRotationX;

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void Update()
    {
        Look();
        MovePlayer();
        ApplyGravity();
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }

    void MovePlayer()
    {
        if (!canMove)
            return;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * moveSpeed * Time.deltaTime);
    }

    void ApplyGravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}