using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MA : MonoBehaviour
{   
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private bool isBreaking;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);        
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
        Debug.Log(horizontalInput);
        Debug.Log(verticalInput);
        Debug.Log(isBreaking);

    }
}
