using UnityEngine;

public class ArrowKeyInput : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;

    private bool rotateWithMouse = false;

    void Update()
    {
        // Check for "R" key press to toggle mouse rotation
        if (Input.GetKeyDown(KeyCode.R))
        {
            rotateWithMouse = !rotateWithMouse;
            Cursor.lockState = rotateWithMouse ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !rotateWithMouse;
        }

        if (rotateWithMouse)
        {
            // Get arrow key input for movement
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Calculate movement direction
            Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

            // Move the GameObject
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

            // Get mouse input for rotation
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Calculate rotation
            Vector3 rotation = new Vector3(-mouseY, mouseX, 0f) * rotationSpeed;
            transform.Rotate(rotation);

            // Clamp vertical rotation to avoid camera flipping
            float currentXRotation = transform.eulerAngles.x;
            if (currentXRotation > 180f)
            {
                currentXRotation -= 360f;
            }

            currentXRotation = Mathf.Clamp(currentXRotation, -90f, 90f);
            transform.rotation = Quaternion.Euler(currentXRotation, transform.eulerAngles.y, 0f);
        }
    }
}


