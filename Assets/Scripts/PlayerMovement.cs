
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private float verticalVelocity;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Keyboard keyboard = Keyboard.current;

        if (keyboard == null)
            return;

        float x = 0f;
        float z = 0f;

        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
            x -= 1f;
        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
            x += 1f;
        if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed)
            z += 1f;
        if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed)
            z -= 1f;

        Vector3 move = transform.right * x
                     + transform.forward * z;

        move = Vector3.ClampMagnitude(move, 1f);

        if (controller.isGrounded && verticalVelocity < 0f)
            verticalVelocity = -2f;

        if (controller.isGrounded &&
            keyboard.spaceKey.wasPressedThisFrame)
        {
            verticalVelocity = Mathf.Sqrt(
                jumpHeight * -2f * gravity
            );
        }

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 velocity = move * speed;
        velocity.y = verticalVelocity;

        controller.Move(velocity * Time.deltaTime);
    }
}
