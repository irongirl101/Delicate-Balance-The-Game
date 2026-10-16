
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCameraLook : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 0.15f;

    private float verticalRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Mouse.current == null ||
            Cursor.lockState != CursorLockMode.Locked)
            return;

        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float mouseX = mouseDelta.x * mouseSensitivity;
        float mouseY = mouseDelta.y * mouseSensitivity;

        // Rotate the player horizontally
        playerBody.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(
            verticalRotation, -85f, 85f
        );

        transform.localRotation =
            Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}

