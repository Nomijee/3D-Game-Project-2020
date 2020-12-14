using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    MeshRenderer[] mrs;
    private void Start() 
    {
        mrs = this.GetComponentsInChildren<MeshRenderer>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
             GameData.singleton.UpdateScore(10);
            foreach (MeshRenderer m in mrs)
                m.enabled = false;
        }
    }
    private void OnEnable()   
    {
        if (mrs != null)
        foreach (MeshRenderer m in mrs)
            m.enabled = true;

    }
}
