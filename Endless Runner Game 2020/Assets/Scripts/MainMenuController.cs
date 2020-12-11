using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject helpPanel;

    void Start()
    {
        helpPanel.SetActive(false);
    }
    public void CloseHelpPanel()
    {
        helpPanel.SetActive(false);
    }
    public void OpenHelpPanel()
    {
        helpPanel.SetActive(true);
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Platforms", LoadSceneMode.Single);
    }
    public void QuitGame()
        {
            Application.Quit();
        }
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            QuitGame();
        }
    }

}
