// Davide Carboni
// Button events for base button prefab in the main menu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    /// <summary>
    /// Load the selected quiz in the Quizze scene
    /// </summary>
    void loadQuizze()
    {
        GameManager.selectedQuizz = GetComponent<ButtonData>().id;       // get the quiz id inside the button data
        SceneManager.LoadScene("Quizze", LoadSceneMode.Single);          // load scene     
    }
    
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => loadQuizze());  // add new event on click
    }
}
