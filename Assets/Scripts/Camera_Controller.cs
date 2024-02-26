using UnityEngine;
using System.Collections;
 
public class Camera_Controller : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public float mouseSensitivity = 6.0f;
    public float verticalSpeed = 0.5f;
    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;

    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            //Debug.Log("made it in here8");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            float rotX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float rotY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            transform.Rotate(Vector3.up * rotX);
            verticalRotation -= rotY;
            verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

            horizontalRotation -= rotX;
            //horizontalRotation = Mathf.Clamp(-90f, horizontalRotation, 90f);
            Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, -1.0f*horizontalRotation, 0);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        Vector3 moveDirection = transform.forward * forwardSpeed + transform.right * sideSpeed;
        float yAdjustment = 0f;
        if (Input.GetKey(KeyCode.Q)) // Move down
        {
            yAdjustment = -verticalSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.E)) // Move up
        {
            yAdjustment = verticalSpeed * Time.deltaTime;
        }
        transform.position += moveDirection + Vector3.up * yAdjustment;
    }
}