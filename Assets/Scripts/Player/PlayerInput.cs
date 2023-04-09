using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    float HorizontalInput;

    bool JumpBtnDown;
    public float GetHorizaontalInput()
    {
        return HorizontalInput;
    }

    public bool JumpDown()
    {
        return JumpBtnDown;
    }
    private void FixedUpdate()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void Update()
    {
        
        
        //Jump Input
        if(Input.GetButtonDown("Jump"))
        {
            JumpBtnDown = true;
        }
        else
        {
            JumpBtnDown = false;
        }
    }
}
