using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 2;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal")*speed,rb.velocity.y,0);
        rb.velocity = move;
    }

    void OnCollisionEnter(Collision c) {

        if (c.gameObject.CompareTag("Fruit")) {
            GameManager.Instance.UpdateScore();
            Destroy (c.gameObject);
        }
    }
}