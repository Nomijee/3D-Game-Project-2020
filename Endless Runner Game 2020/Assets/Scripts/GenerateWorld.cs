using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateWorld : MonoBehaviour
{
    
    public static GameObject dummyTraveller;
    public static GameObject lastPlatform;

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    void Awake()
    {
        dummyTraveller = new GameObject("dummy");
    }
        
//method get called by PlayerController because it knows which platform its on 
    public static void RunDummy()
    {
        GameObject p = Pool.singleton.GetRandom();
        //check if sucessfull getting an object
        if (p == null) return;
        if (lastPlatform != null)
        {
            if (lastPlatform.tag == "platformTSection")
            dummyTraveller.transform.position = lastPlatform.transform.position +
                //moving forward 
                PlayerController.player.transform.forward * 20;
            else 
            dummyTraveller.transform.position = lastPlatform.transform.position +
                PlayerController.player.transform.forward * 10;

            if (lastPlatform.tag == "stairsUp")
            dummyTraveller.transform.Translate(0, 5, 0);

        }

        lastPlatform = p;
        p.SetActive(true);
        p.transform.position = dummyTraveller.transform.position;
        p.transform.rotation = dummyTraveller.transform.rotation;

        if(p.tag == "stairsDown")
        {
            dummyTraveller.transform.Translate(0, -5, 0);
            //rotate stairs 
            p.transform.Rotate(0, 180, 0);
            p.transform.position = dummyTraveller.transform.position;

        }

    } 
    
}
   