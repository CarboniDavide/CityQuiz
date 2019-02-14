// Davide Carboni
// Check State: check for error in main menu 
//              enable or disable button list if any problem have found and enable a message error

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net;
using System.Threading;

public class ErrorManager : MonoBehaviour
{
    public GameObject listButtons;
    public GameObject api;
    public GameObject menuManager;

    /// <summary>
    /// Verify if api connection is available and if any quizzes are available
    /// </summary>
    void Update()
    {
        if (api == null) return;

        // check api connection
        if (!api.GetComponent<Api>().isConnected)
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().enabled = true;                        // enable this message box
            this.gameObject.GetComponent<TextMeshProUGUI>().text = "Loading...";       // set message information
            listButtons.SetActive(false);                                                          // disable the list of buttons
            return;
        }

        // check for quizzes
        if (GameManager.nQuizz == 0)
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().enabled = true;                 // enable this message box
            this.gameObject.GetComponent<TextMeshProUGUI>().text = "No Quizz Available";    // set message information
            listButtons.SetActive(false);                                                   // disable the list of buttons
            return;
        }

        // if no problem so...
        this.gameObject.GetComponent<TextMeshProUGUI>().enabled = false;                   // disable this message box
        listButtons.SetActive(true);                                                       // enable the list of buttons
    }
}
