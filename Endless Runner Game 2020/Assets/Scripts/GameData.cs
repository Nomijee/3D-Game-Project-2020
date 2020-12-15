using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameData : MonoBehaviour
{
    public static GameData singleton;
    public Text scoreText = null; 
    public int score = 0;
    public GameObject musicSlider;
    public GameObject soundSlider;


    void Awake()
    {
        GameObject[] gd = GameObject.FindGameObjectsWithTag("gamedata");
         
        if (gd.Length >1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        singleton = this;

        musicSlider.GetComponent<UpdateMusic>().Start();
        soundSlider.GetComponent<UpdateSound>().Start();
        ///////////////
         PlayerPrefs.SetInt("score", 0);
    }
    public void UpdateScore(int s) 
    {
        score += s;
        PlayerPrefs.SetInt("score", score); 
        if (scoreText != null)
            scoreText.text = "Score " + score; 

    }

}
