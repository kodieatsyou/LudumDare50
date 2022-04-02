using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    Controls playerControls;

    public GameObject leftStrum;
    public GameObject rightStrum;
    public GameObject upStrum;
    public GameObject downStrum;

    private void Awake()
    {
        playerControls = new Controls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerControls.Player.Left.performed += StrumLeft;
        playerControls.Player.Right.performed += StrumRight;
        playerControls.Player.Up.performed += StrumUp;
        playerControls.Player.Down.performed += StrumDown;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StrumLeft(InputAction.CallbackContext context)
    {
        leftStrum.GetComponent<Strummer>().Strum();
    }
    void StrumRight(InputAction.CallbackContext context)
    {
        rightStrum.GetComponent<Strummer>().Strum();
    }
    void StrumUp(InputAction.CallbackContext context)
    {
        upStrum.GetComponent<Strummer>().Strum();
    }
    void StrumDown(InputAction.CallbackContext context)
    {
        downStrum.GetComponent<Strummer>().Strum();
    }
}
