using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePowerup : BasePowerup
{
    [SerializeField] private float reenableTime = 30;

    public override void PowerUp()
    {
        CharacterController.Instance.canDoubleJump = true;

        GetComponentInChildren<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        StartCoroutine(ReEnable());
    }

    IEnumerator ReEnable()
    {
        yield return new WaitForSeconds(reenableTime);

        GetComponentInChildren<MeshRenderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }
}
