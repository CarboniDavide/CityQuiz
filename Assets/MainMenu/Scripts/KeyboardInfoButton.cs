// Davide Carboni
// Button handler to load keyboardInfo

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyboardInfoButton : MonoBehaviour
{
    /// <summary>
    /// Load the keyboard info key menu
    /// </summary>
    void loadKeyboardInfo()
    {
        SceneManager.LoadScene("KeyInfo", LoadSceneMode.Single);          // load scene     
    }

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => loadKeyboardInfo());  // add new event on click
    }
}
