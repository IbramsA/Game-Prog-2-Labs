using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject particleSystemPrefab;
    public Transform turret;
    // Start is called before the first frame update
    void Start()
    {
        turret = GameObject.Find("Turret").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit h;
            Ray r = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
            Instantiate(particleSystemPrefab, transform.position, transform.rotation);
            if (Physics.Raycast(r, out h))
            {
                if(h.collider.tag == "Turret"){
                    GameObject target = h.collider.gameObject;
                    TurretComponent tc = turret.GetComponent<TurretComponent>();
                    tc.TakeDamage(20);
                }
            }
        }
    }
}