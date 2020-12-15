using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    public Material level2sky;
    public Material level3Sky;
    public GameObject level2Text;
    public GameObject level3Text;
    // Start is called before the first frame update
    void Start()
    {
        level2Text.SetActive(false);
        level3Text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Level2Up();

    }

    void Level2Up()
    {
        // a varaible to store score string
        int levelUpScore;
        // acessing the score 
        levelUpScore = GameData.singleton.score;
       
        // checking if score is greater than or equal to 150 then change the sky box to show level change
        if (levelUpScore >= 200)
        {
            RenderSettings.skybox = level2sky;
            // checks if object is not destroyed
            if (level2Text != null)
            {
                // displays the level 3 text
                DisplayLevelUp();
                Destroy(level2Text, 2);
            }


        }
        // checking if score is greater than or equal to 400 then change the sky box to show level change
        if (levelUpScore >= 400)
        {
            RenderSettings.skybox = level3Sky;
            // checks if object is not destroyed
            if (level2Text != null)
            {
                // displays the level 3 text
                DisplayLevel3Up();
                Destroy(level3Text, 2);
            }

        }
    }
    void DisplayLevelUp()
    {
        level2Text.SetActive(true);

    }
    void DisplayLevel3Up()
    {
        level3Text.SetActive(true);

    }
}
