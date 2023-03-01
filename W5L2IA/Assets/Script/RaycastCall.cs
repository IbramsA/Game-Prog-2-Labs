using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RaycastCall : MonoBehaviour
{
    private AudioSource aS;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        aS=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            aS.Play();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.gameObject.tag == "Target") {
                    Destroy(hit.collider.gameObject);
                }
            }
            //gm.IncrementScore();
        }
    }
}
