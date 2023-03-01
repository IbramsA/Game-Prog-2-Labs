using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RaycastCall : MonoBehaviour
{
    private AudioSource aS;
    public GameManager gm;
        public GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        aS=GetComponent<AudioSource>();
    }

    // // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            aS.Play();

            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.tag == "Target") {
                    GameObject hitObject = hit.collider.gameObject;
                    GameManager.Instance.IncrementScore();
                    Destroy(hitObject);
                }
            }
            Instantiate(particle, hit.point, Quaternion.identity);
        }
    }

}