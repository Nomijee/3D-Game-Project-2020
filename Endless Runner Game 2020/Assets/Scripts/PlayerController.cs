using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    public static GameObject player;
    public static GameObject currentPlatform;
    bool canTurn = false;
    Vector3 startPosition;
    public static bool isDead = false; 
    Rigidbody rb;

    public GameObject magic;
    public Transform magicStartPos;
    Rigidbody mRb;
    
    void OnCollisionEnter (Collision other)
    {
       if (other.gameObject.tag =="Fire" || other.gameObject.tag == "Wall")
        {
            anim.SetTrigger("isDead");
            isDead = true;
        }
       else 
        currentPlatform = other.gameObject;
    } 
        
    void Start()
    {
        //Anim will ne null if no animator
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        mRb = magic.GetComponent<Rigidbody>();

        player = this.gameObject;
        startPosition = player.transform.position;
        GenerateWorld.RunDummy();
    }

    //method to cast magic spell
    void CastMagic()
    {
        magic.transform.position = magicStartPos.position;
        magic.SetActive(true);
        mRb.AddForce(this.transform.forward * 4000);
        //deactive magic after spell
        Invoke("KillMagic", 1);
    }
    //method to kill magic
    void KillMagic()
    {
        magic.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other is BoxCollider && GenerateWorld.lastPlatform.tag != "platformTSection") 
        GenerateWorld.RunDummy();
        if (other is SphereCollider)
            canTurn = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other is SphereCollider)
            canTurn = false;
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
        if (PlayerController.isDead) return; 
        if  (Input.GetKeyDown(KeyCode.Space)&& anim.GetBool("isMagic") == false)
        {
            anim.SetBool("isJumping", true);
            rb.AddForce(Vector3.up * 200);   
        }
        else if (Input.GetKeyDown(KeyCode.M) && anim.GetBool("isJumping") == false)
        {
            anim.SetBool("isMagic", true);
        }  
        else if (Input.GetKeyDown(KeyCode.RightArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * 90);
            GenerateWorld.dummyTraveller.transform.forward = -this.transform.forward;
            GenerateWorld.RunDummy();

            if (GenerateWorld.lastPlatform.tag != "platformTSection")
                 GenerateWorld.RunDummy();
            this.transform.position = new Vector3(startPosition.x,
                                                    this.transform.position.
                                                        y, startPosition.z);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * -90);
            GenerateWorld.dummyTraveller.transform.forward = -this.transform.forward;
            GenerateWorld.RunDummy();

            if (GenerateWorld.lastPlatform.tag != "platformTSection")
                GenerateWorld.RunDummy();

            this.transform.position = new Vector3(startPosition.x,
                                                    this.transform.position.
                                                        y, startPosition.z);
        }
        //for displacement to left
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Translate(-0.5f, 0, 0);
        }
        //for displacement to right
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.Translate(0.5f, 0, 0);
        }
    }
}
