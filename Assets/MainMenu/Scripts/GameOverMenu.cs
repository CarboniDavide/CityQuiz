// Davide Carboni
// The Game Over Panel 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public GameObject quizzeManager;                   // quizz manager
    public GameObject exitPanel;                       // the game over panel
    public GameObject Camera;                          // base camera
    public GameObject Player;                          // the game player 
    private bool isOpened = false;      

    /// <summary>
    /// Check if the game if finished then disable the player and open the game over menu
    /// </summary>
    void Update()
    {
        if (quizzeManager.GetComponent<QuizzeManager>().isFinished && isOpened == false)
        {
            isOpened = true;
            exitPanel.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = "Game Over";         // Menu Title
            exitPanel.SetActive(true);                                                                    // show menu panel                
            Player.SetActive(false);                                                                      // disable player
            Camera.GetComponent<ThirdPersonOrbitCamBasic>().enabled = false;                              // disable mouse mouvement in the camera 
            Cursor.visible = true;                                                                        // show mouse
        }
    }
}
