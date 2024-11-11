using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 10f;
    public float mouseSensitivity = 500f;

    private float yaw = 0f; // EJE Y
    private float pitch = 0f; // EJE X

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // YAM / PITCH
        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -90f, 90f); // LIMIT

        // ROTACION
        transform.eulerAngles = new Vector3(pitch, yaw, 0);

        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement -= forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement -= right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += right;
        }

        // UPDATED
        transform.position += movement * speed * Time.deltaTime;
    }
}