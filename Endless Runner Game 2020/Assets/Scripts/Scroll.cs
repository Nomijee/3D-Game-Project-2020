using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour

{
    void FixedUpdate()
    {
        this.transform.position += PlayerController.player.transform.forward * -0.1f;
        if (PlayerController.currentPlatform == null) return;
        //stairs upward 
        if (PlayerController.currentPlatform.tag == "stairsUp")
            this.transform.Translate(0, -0.06f, 0);
        //stairs downward 
        if (PlayerController.currentPlatform.tag == "stairsDown")
            this.transform.Translate(0, 0.06f, 0);
    }
}
