using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePlayer : MonoBehaviour
{
    NavMeshAgent playerMesh;
    // Start is called before the first frame update
    void Start()
    {
        playerMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit h;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out h, 100))
            {
                playerMesh.destination = h.point;
            }
        }
    }
}
