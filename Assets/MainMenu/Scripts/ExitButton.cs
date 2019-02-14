// Davide Carboni
// Exit button handler

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    /// <summary>
    /// Add a close application vent to the button exit
    /// </summary>
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => Application.Quit());   // add close event
    }
}
