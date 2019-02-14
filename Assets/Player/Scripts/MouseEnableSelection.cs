// Davide Carboni
// Enable the mouse selection when Q is pressed

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEnableSelection : MonoBehaviour
{
    public GameObject Camera;             // default camera
    public GameObject Player;             // default player
    bool isMouseHide = true;              // initial mouse state
    float walkSpeed;                      // default walk speed.
    float runSpeed;
    float sprintSpeed;
    float noSpeed = 0f;                   // defualt no speed value

    /// <summary>
    /// Start is called before the first frame update: Initial value for player
    /// </summary>
    void Start() { Init(); }

    /// <summary>
    /// Disable mouse and store the original walk valuew to use after
    /// </summary>
    void Init()
    {
        Cursor.visible = false;                                   //Disable Mouse
        walkSpeed = GetComponent<MoveBehaviour>().walkSpeed;      //Get original walk speed
        runSpeed = GetComponent<MoveBehaviour>().runSpeed;        //Get original run speed
        sprintSpeed = GetComponent<MoveBehaviour>().sprintSpeed;  //Get original sprint speed
    }

    /// <summary>
    /// Enable mouse selection
    /// </summary>
    void EnableMouseSelection()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.X)) isMouseHide = false;
            if (Input.GetKeyUp(KeyCode.X)) isMouseHide = true;
        }
        else isMouseHide = true;

        Cursor.lockState = isMouseHide ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !isMouseHide;
    }

    /// <summary>
    /// Enable/Disable component object
    /// </summary>
    /// <param name="state"></param>
    void TPCamera(bool state)
    {
        Camera.GetComponent<ThirdPersonOrbitCamBasic>().enabled = state;                    // Stop mouse control in the main camera
        GetComponent<FlyBehaviour>().enabled = state;                                       // Disable fly modality
        GetComponent<MoveBehaviour>().runSpeed = state ? runSpeed : noSpeed;                // stop walking player if necessary    
        GetComponent<MoveBehaviour>().walkSpeed = state ? walkSpeed : noSpeed;              // stop running player if necessary
        GetComponent<MoveBehaviour>().sprintSpeed = state ? sprintSpeed : noSpeed;          // stop sprint player if necessary
    }

    // Update is called once per frame
    void Update()
    {
        EnableMouseSelection();                    // Verify Keyboard inout
        TPCamera(isMouseHide);                     // Change state of player and camera if necessary          
    }
}
