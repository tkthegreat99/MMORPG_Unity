using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{ 
    public Action KeyAction = null; //Action -> delegate
    public Action<Define.MouseEvent> MouseAction = null;

    bool _pressed = false;
    public void OnUpdate()
    {
        

        if(Input.anyKey && KeyAction != null)
            KeyAction.Invoke(); //delegate ȣ��.

        if (MouseAction != null)
        {
            if(Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;
            }
            else
            {
                if(_pressed)
                    MouseAction.Invoke(Define.MouseEvent.Click);
                _pressed = false;
            }
        }
    }
}
