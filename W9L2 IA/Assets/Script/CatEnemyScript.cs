using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class CatEnemyScript : MonoBehaviour
{
       public GameObject player;

    public Transform[] patrol;
    private int patrolp = 0;
    private UnityEngine.AI.NavMeshAgent mesh;

    public float maxAngle = 45;
    public float maxDistance = 2;
    public float timer = 1.0f;
    public float visionCheckRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        mesh.autoBraking = false;
        nextPatrolPoint();
    }


    // Update is called once per frame
    void Update()
    { 
        if(SeePlayer())
        {
            Vector3 dest = player.transform.position;
            mesh.destination = dest;
        }
        else {
            if (!mesh.pathPending && mesh.remainingDistance < 0.5f)
            {
                nextPatrolPoint();
            }
        }
    }

    public bool SeePlayer()
    {
        Vector3 vecPlayerTurret = player.transform.position - transform.position;
        if (vecPlayerTurret.magnitude > maxDistance)
        {
            return false;
        }
        Vector3 normVecPlayerTurret = Vector3.Normalize(vecPlayerTurret);
        float dotProduct = Vector3.Dot(transform.forward,normVecPlayerTurret);
        var angle = Mathf.Acos(dotProduct);
        float deg = angle * Mathf.Rad2Deg;
        if (deg < maxAngle)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, normVecPlayerTurret);
        
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Player")
                {
                    return true;
                }
                
            }
        }
        return false;
       
    }

    public void nextPatrolPoint()
    {
        if (patrol.Length == 0)
        {
            return;
        }

        mesh.destination = patrol[patrolp].position;

        patrolp = (patrolp + 1) % patrol.Length;
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
