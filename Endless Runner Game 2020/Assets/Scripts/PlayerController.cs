using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    public static GameObject player;
    public static GameObject currentPlatform;
    
    void OnCollisionEnter (Collision other)
    {
        currentPlatform = other.gameObject;
    } 
        
    void Start()
    {
        //Anim will ne null if no animator
        anim = this.GetComponent<Animator>();
        player = this.gameObject; 
    }
    void StopJump()
    {
        anim.SetBool("isJumping", false);
    }
    void StopMagic()
    {
        anim.SetBool("isMagic", false);
    }
    // Update is called once per frame
    void Update() 
    {
        if  (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("isMagic", true);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.Rotate(Vector3.up * 90);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.Rotate(Vector3.up * -90);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Translate(-0.1f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.Translate(0.1f, 0, 0);
        }
    }
}
