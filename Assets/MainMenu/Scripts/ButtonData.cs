// Davide Carboni
// Button data prefab in the main menu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonData : MonoBehaviour
{
    public string id;
    public string title;

    public void Init(string id, string title)
    {
        this.id = id;
        this.title = title;
    }
}
