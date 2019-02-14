// Davide Carboni
// The Pause Panel 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public bool isPause = false;
    public GameObject pauseMenu;
    public GameObject Camera;
    public GameObject Player;
    public GameObject quizzeManager;

   /// <summary>
   /// Open / Close the pause menu
   /// </summary>
    void DoAction()
    {
        pauseMenu.transform.Find("Title").GetComponent<TextMeshProUGUI>().text ="Pause";       // Menu Title
        isPause = !isPause;                                                                    // change state Close <-> Open
        pauseMenu.SetActive(isPause);                                                          // enable / disable menu
        Player.SetActive(!isPause);                                                            // disable player scripts mouse  
        Camera.GetComponent<ThirdPersonOrbitCamBasic>().enabled = !isPause;                    // enable disable camera mouse mouvement in the camera
        Cursor.lockState = !isPause ? CursorLockMode.Locked : CursorLockMode.None;             // set mouse in the center of screen
        Cursor.visible = isPause;                                                              // show mouse
    }

    /// <summary>
    /// Verify if the Escape key has been pressed in the keyboard then 
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !quizzeManager.GetComponent<QuizzeManager>().isFinished)  DoAction();
    }
}
