using UnityEngine;

public abstract class BasePowerup : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90f;
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private float movementRange = 0.25f;

    [SerializeField] private ParticleSystem particleSystem;

    private Vector3 startPos;

    protected virtual void Start()
    {
        // Store the starting y position of the powerup
        startPos = transform.localPosition;
    }

    protected virtual void Update()
    {
        // Rotate the powerup around the y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Move the powerup up and down along the y-axis
        float newY = startPos.y + movementRange * Mathf.Sin(movementSpeed * Time.time);
        transform.localPosition = new Vector3(startPos.x, newY, startPos.z);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        // If the powerup collides with the player, destroy it
        if (other.gameObject.CompareTag("Player"))
        {
            PowerUp();
            particleSystem.Play();
        }
    }

    public abstract void PowerUp();
}