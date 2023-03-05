using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretComponent : MonoBehaviour
{
    public float maxAngle = 45;
    public Transform targetToAttack;
    public float rotationSpeed = 20f;
    private Quaternion originalRotation;
    public Image healthBarImage;

    public CharacterMovement movement;

    public ShootingScript shoot;

    public int maxHealthPoints = 200;
    private int currentHealthPoints;


    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.rotation;
        currentHealthPoints = maxHealthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToTarget = targetToAttack.position - transform.position;
        float angleToTarget = Mathf.Acos(Vector3.Dot(transform.forward, directionToTarget.normalized)) * Mathf.Rad2Deg;

        if (angleToTarget <= maxAngle)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (currentHealthPoints <= 0)
        {
            Destroy(gameObject);
            Debug.Log("You Win");
            movement.enabled = false;
            shoot.enabled = false;
        }

        currentHealthPoints -= damageAmount;
        healthBarImage.fillAmount = ((float)currentHealthPoints / (float)maxHealthPoints);
    }
}