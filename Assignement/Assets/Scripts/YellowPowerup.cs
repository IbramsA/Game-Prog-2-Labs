using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPowerup : BasePowerup
{
    public override void PowerUp()
    {
        GameManager.Instance.AddScore(50);

        GetComponentInChildren<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 1f);
    }
}
