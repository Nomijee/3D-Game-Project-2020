using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    
    GameObject dummyTraveller;

    void Start()
    {
        dummyTraveller = new GameObject("dummy");
        
        for (int i = 0; i < 20; i++)
        {
            
            GameObject p =Pool.singleton.GetRandom();
            if (p == null) return;

            p.SetActive(true);
            p.transform.position = dummyTraveller.transform.position;
            p.transform.rotation = dummyTraveller.transform.rotation;


            if (p.tag == "stairsUp")
            {
                dummyTraveller.transform.Translate(0, 5, 0);
            }
            if (p.tag == "stairsDown")
            {
                dummyTraveller.transform.Translate(0, -5, 0);
                p.transform.Rotate(new Vector3(0, 180, 0));
                p.transform.position = dummyTraveller.transform.position;
            }
            else if (p.tag == "platformTSection")
            {
                //Adding tile to right turn
                if(Random.Range(0, 2)==0)
                dummyTraveller.transform.Rotate(new Vector3(0, 90, 0));
                else //Adding tile to left turn
                    dummyTraveller.transform.Rotate(new Vector3(0, -90, 0));
                dummyTraveller.transform.Translate(Vector3.forward * -10);
            }
            dummyTraveller.transform.Translate(Vector3.forward * -10);
        } 
    }
}
   