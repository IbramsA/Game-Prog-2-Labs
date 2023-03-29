using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform anchor;
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private float distanceFromPlayer = 2f;
    [SerializeField] private float maxAngle = 80f;
    [SerializeField] private float minAngle = -80f;
    [SerializeField] private float rotationSpeed = 5f;

    private float mouseX;
    private float mouseY;
    private float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, minAngle, maxAngle);

        xRotation += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        player.rotation = Quaternion.Euler(0f, xRotation, 0f);

        Quaternion targetRotation = Quaternion.Euler(mouseY, mouseX, 0);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        Vector3 targetPosition = anchor.position - transform.forward * distanceFromPlayer;
        transform.position = targetPosition;
    }
}