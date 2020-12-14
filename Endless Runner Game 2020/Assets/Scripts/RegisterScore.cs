 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class RegisterScore : MonoBehaviour
{
    void Start()
    {
         GameData.singleton.scoreText = this.GetComponent<Text>();
        GameData.singleton.UpdateScore(0);
    }

    
}
