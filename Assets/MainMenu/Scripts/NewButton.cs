// Davide Carboni
// Button handler to comeback in the main menu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewButton : MonoBehaviour
{
    /// <summary>
    /// Add new game event to the button new
    /// </summary>
    void Start()
    {
        // add new event on click
        GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("MainMenu", LoadSceneMode.Single));  // come back to the main menu for a new game quiz
    }
}
