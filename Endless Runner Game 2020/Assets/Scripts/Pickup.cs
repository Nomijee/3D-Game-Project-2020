using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
     void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
             GameData.singleton.UpdateScore(10);
            Destroy(this.gameObject, 0.5f);
           // Debug.Log("Pickup");
        }
    }
}
