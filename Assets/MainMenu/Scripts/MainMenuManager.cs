// Davide Carboni
// Main Menu Manager

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class MainMenuManager : MonoBehaviour
{
    public bool isLoaded = false;                  // flag to check if the buttons in the menus are loaded
    public bool isStarted = false;
    public GameObject itemTemplate;                 // base template button
    public GameObject api;
    public GameObject content;

    private ApiData.GameQuizzes gameQuizzes;        // Base classe to store all quizzes from api
    public ApiData.GameQuizzes GameQuizzes { get => gameQuizzes; set => gameQuizzes = value; }

    /// <summary>
    /// On load: reset all variable to set a new game menu
    /// </summary>
    private void OnEnable()
    {
        isLoaded = false;
        GameManager.nQuizz = 0;
        isStarted = true;
    }

    /// <summary>
    /// Get data from api and create the buttons in the menu
    /// </summary>
    void Update()
    {
        if (api == null) return;                                // do nothing if api object is not available

        if (api.GetComponent<Api>().isConnected)                // repeat until api is available or not quizzes are availables
            if (GameManager.nQuizz == 0 && !isLoaded)              
                LoadQuizFromAPI();
            else
                AddButtons();                                   // add buttons in the menu    
        
    }


    /// <summary>
    /// Load all quizzes from api
    /// </summary>
    public void LoadQuizFromAPI()
    {
        this.GameQuizzes = api.GetComponent<Api>().getGameQuizzesFromAPI();
        GameManager.nQuizz = this.GameQuizzes.quizzes.Count;
    }

    /// <summary>
    /// Add buttons dinamically in the menu
    /// </summary>
    public void AddButtons()
    {
        if (isLoaded) return;                                               // do nothing if menu has been loaded

        isLoaded = true;
        foreach (ApiData.IndexQuizzes q in gameQuizzes.quizzes)             // get all quizzes informations
        {
            var copy = Instantiate(itemTemplate);                           // get the base template button
            copy.GetComponent<ButtonData>().id = q.id;                      // set the id data in the data button class
            copy.GetComponent<ButtonData>().title = q.title;                // set the title data in the data button class
            copy.GetComponentInChildren<TextMeshProUGUI>().text = q.title;  // modify string text the new button 
            copy.SetActive(true);                                           // show the new button 
            copy.transform.parent = content.transform;                      // add the new button in the list  
        }
    }
}
