using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControllerMulti2 : MonoBehaviour
{
    Animator anim;
    public static GameObject player;
    public static GameObject currentPlatform;
    public static AudioSource[] sfx;

    bool canTurn = false;
    Vector3 startPosition;
    public static bool isDead = false; 
    Rigidbody rb;

    public GameObject magic;
    public Transform magicStartPos;
    Rigidbody mRb;

    int livesLeft;
    public Texture aliveIcon;
    public Texture deadIcon;
    public RawImage[] icons;

    public GameObject multiGameOverPanel;

    public Text highScore;

    
    void RestartGame()
    {
        
        SceneManager.LoadScene("PlatformsMulti2", LoadSceneMode.Single);
    }
    void OnCollisionEnter (Collision other)
    {
        //player dead
       if ((other.gameObject.tag =="Fire" || other.gameObject.tag == "Wall") && !isDead)
        {
            anim.SetTrigger("isDead");
            isDead = true;
            sfx[7].Play();
            livesLeft-- ;  
            PlayerPrefs.SetInt("lives", livesLeft);
            
            if (livesLeft > 0)
                Invoke("RestartGame", 1);
            else
            {
                icons[0].texture = deadIcon;
                // setting player 2 Score
                PlayerPrefs.SetInt("player2Score", PlayerPrefs.GetInt("score"));
                multiGameOverPanel.SetActive(true);

                PlayerPrefs.SetInt("lastscore", PlayerPrefs.GetInt("score"));
                if (PlayerPrefs.HasKey("highscore"))
                {
                    int hs = PlayerPrefs.GetInt("highscore");
                    if (hs < PlayerPrefs.GetInt("score"))
                        PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score"));
                }
                else
                    PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score"));
            } 
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
        sfx = GameObject.FindWithTag("gamedata").GetComponentsInChildren<AudioSource>();

        player = this.gameObject;
        startPosition = player.transform.position;
        GenerateWorld2.RunDummy();

        if (PlayerPrefs.HasKey("highscore")) 
             highScore.text = "High Score :" + PlayerPrefs.GetInt("highscore");
       else
            highScore.text = "High Score :0";
         
        isDead = false;
        livesLeft = PlayerPrefs.GetInt("lives");

        for (int i = 0; i < icons.Length; i++)
        {
            if (i >=livesLeft)
                icons[i].texture = deadIcon;
        }
    }

    //method to cast magic spell
    void CastMagic()
    {
        magic.transform.position = magicStartPos.position;
        magic.SetActive(true);
        mRb.AddForce(this.transform.forward * 500);
        //deactive magic after spell
        Invoke("KillMagic", 1);
        
    }
    //method to kill magic
    void KillMagic()
    {
        magic.SetActive(false);
    }
    void PlayMagic()
    {
        sfx[8].Play(); 

    }
    void FootStep1()
    {
        sfx[5].Play();    
    }
    void FootStep2()
    {
        sfx[4].Play();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other is BoxCollider && GenerateWorld2.lastPlatform.tag != "platformTSection") 
        GenerateWorld2.RunDummy();
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
            sfx[3].Play();
        }
        else if (Input.GetKeyDown(KeyCode.M) && anim.GetBool("isJumping") == false)
        {
            anim.SetBool("isMagic", true);
        }  
        else if (Input.GetKeyDown(KeyCode.RightArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * 90);
            GenerateWorld2.dummyTraveller.transform.forward = -this.transform.forward;
            GenerateWorld2.RunDummy();

            if (GenerateWorld2.lastPlatform.tag != "platformTSection")
                 GenerateWorld2.RunDummy();
            this.transform.position = new Vector3(startPosition.x,
                                                    this.transform.position.
                                                        y, startPosition.z);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * -90);
            GenerateWorld2.dummyTraveller.transform.forward = -this.transform.forward;
            GenerateWorld2.RunDummy();

            if (GenerateWorld2.lastPlatform.tag != "platformTSection")
                GenerateWorld2.RunDummy();

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
