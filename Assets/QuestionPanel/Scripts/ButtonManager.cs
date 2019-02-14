// Davide Carboni
// Manage the event into the question panel

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject answer;           // the answer object for this button
    public GameObject panel;            // main question panel 
    public GameObject question;         // the questino game  
    public GameObject quizzeManager;    // the manager quiz

    UnityEngine.Color colorWin;         // base win color for panel   
    UnityEngine.Color colorDeny;        // base deny color for panel
    UnityEngine.Color colorAnswered;    // base color for disabled button

    /// <summary>
    /// Event on button click: check if selected answer is correct then change panel state
    /// </summary>
    public void ClickMe()
    {
        colorDeny = Color.red;
        colorDeny.a = 0.8f;

        colorWin = Color.green;
        colorWin.a = 0.8f;

        colorAnswered = Color.blue;

        panel.GetComponent<Animator>().enabled = false;

        // check answer
        if (answer.GetComponent<Answer>().value)
        {
            panel.GetComponent<Image>().color = colorWin;
            //update QuizzeManagerData
            quizzeManager.GetComponent<QuizzeManager>().answeredTrueQuestion += 1;
        }
        else
            panel.GetComponent<Image>().color = colorDeny;

        //update question state
        question.GetComponent<Question>().isAnswered = true;
        question.GetComponent<Question>().isAvailable = false;
        //update button state
        answer.GetComponent<Answer>().clicked = true;
        //update QuizzeManagerData
        quizzeManager.GetComponent<QuizzeManager>().answeredQuestion += 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => ClickMe());
    }

    // Update is called once per frame
    void Update()
    {
        GetComponentInChildren<Text>().text = answer.GetComponent<Answer>().name;  // update text button value
        if (GetComponentInChildren<Text>().text == "")                              // delete empty answers
            this.gameObject.SetActive(false);
        if (question.GetComponent<Question>().isAnswered == true)                   //disable button after answered the question
        {
            GetComponent<Button>().enabled = false;                                 //disable button
            if (answer.GetComponent<Answer>().clicked)                              //change selected color button
            {
                var colors = GetComponent<Button>().colors;
                colors.highlightedColor = colorAnswered;
                GetComponent<Button>().colors = colors;
            }
        }

    }
}