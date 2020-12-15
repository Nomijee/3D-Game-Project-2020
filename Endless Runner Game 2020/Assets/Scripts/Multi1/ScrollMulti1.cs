using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMulti1 : MonoBehaviour

{
    void FixedUpdate()
    {
        if (PlayerControllerMulti1.isDead) return;
        this.transform.position += PlayerControllerMulti1.player.transform.forward * -0.1f;
        if (PlayerControllerMulti1.currentPlatform == null) return;
        //stairs upward 
        if (PlayerControllerMulti1.currentPlatform.tag == "stairsUp")
            this.transform.Translate(0, -0.06f, 0);
        //stairs downward 
        if (PlayerControllerMulti1.currentPlatform.tag == "stairsDown")
            this.transform.Translate(0, 0.06f, 0);
    }
}
