using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMulti2 : MonoBehaviour

{
    void FixedUpdate()
    {
        if (PlayerControllerMulti2.isDead) return;
        this.transform.position += PlayerControllerMulti2.player.transform.forward * -0.1f;
        if (PlayerControllerMulti2.currentPlatform == null) return;
        //stairs upward 
        if (PlayerControllerMulti2.currentPlatform.tag == "stairsUp")
            this.transform.Translate(0, -0.06f, 0);
        //stairs downward 
        if (PlayerControllerMulti2.currentPlatform.tag == "stairsDown")
            this.transform.Translate(0, 0.06f, 0);
    }
}
