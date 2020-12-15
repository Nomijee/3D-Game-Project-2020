using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MultiplayerNames : MonoBehaviour
{
    public InputField player1Name;
    public InputField player2Name;
    string p1Name;
    string p2Name;
    public void SaveNames()
    {
        p1Name = player1Name.text;
        p2Name = player2Name.text;
        PlayerPrefs.SetString("player1Name", p1Name);
        PlayerPrefs.SetString("player2Name", p2Name);
        PlayerPrefs.Save();
    }
}