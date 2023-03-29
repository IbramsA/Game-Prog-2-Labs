using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 axis = Vector3.up; // The axis to rotate around
    public float speed = 10f; // The speed of rotation

    void Update()
    {
        // Rotate the GameObject around the specified axis at the specified speed
        transform.Rotate(axis, speed * Time.deltaTime);
    }
}