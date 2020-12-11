using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    //to flag on or off upon multiple bouncing so deactivation doesnt triger multiple times 
    bool dScheduled = false;
   void OnCollisionExit(Collision player)
    {
        if (PlayerController.isDead) return; 
        if (player.gameObject.tag == "Player" && !dScheduled)
        {
            Invoke("SetInactive", 4.0f);
            dScheduled = true;
        }
            
    }
    void SetInactive()
    {
        this.gameObject.SetActive(false);
        dScheduled = false;
    }
}
