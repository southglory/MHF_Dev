using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action<Define.MouseEvent> MouseAction = null;
    public Action<Define.KeyEvent> KeyAction = null;

    bool _MousePressed = false;
    float _MousePressedTime = 0;

    bool _W_KeyPressed = false;
    float _W_KeyPressedTime = 0;
    bool _S_KeyPressed = false;
    float _S_KeyPressedTime = 0;
    bool _A_KeyPressed = false;
    float _A_KeyPressedTime = 0;
    bool _D_KeyPressed = false;
    float _D_KeyPressedTime = 0;
    bool _Space_KeyPressed = false;
    float _Space_KeyPressedTime = 0;

    public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //if (Input.anyKey && KeyAction != null)
        //    KeyAction.invoke();

        if (KeyAction != null)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (!_W_KeyPressed)
                {
                    KeyAction.Invoke(Define.KeyEvent.W_KeyDown);
                    _W_KeyPressedTime = Time.time;
                    Debug.Log("W_Down");
                }
                KeyAction.Invoke(Define.KeyEvent.W_KeyPress);
                _W_KeyPressed = true;
                Debug.Log("W_Pressed " + _W_KeyPressed.ToString());
            }
            else
            {
                if (_W_KeyPressed)
                {
                    if (Time.time < _W_KeyPressedTime + 0.2f)
                    {
                        KeyAction.Invoke(Define.KeyEvent.W_KeyClick);
                        Debug.Log("W_Clicked");
                    }
                    KeyAction.Invoke(Define.KeyEvent.W_KeyUp);
                    Debug.Log("W_Up");
                }
                _W_KeyPressed = false;
                _W_KeyPressedTime = 0;
            }
            
            if (Input.GetKey(KeyCode.S))
            {
                if (!_S_KeyPressed)
                {
                    KeyAction.Invoke(Define.KeyEvent.S_KeyDown);
                    _S_KeyPressedTime = Time.time;
                    Debug.Log("S_Down");
                }
                KeyAction.Invoke(Define.KeyEvent.S_KeyPress);
                _S_KeyPressed = true;
                Debug.Log("S_Pressed " + _S_KeyPressed.ToString());
            }
            else
            {
                if (_S_KeyPressed)
                {
                    if (Time.time < _S_KeyPressedTime + 0.2f)
                    {
                        KeyAction.Invoke(Define.KeyEvent.S_KeyClick);
                        Debug.Log("S_Clicked");
                    }
                    KeyAction.Invoke(Define.KeyEvent.S_KeyUp);
                    Debug.Log("S_Up");
                }
                _S_KeyPressed = false;
                _S_KeyPressedTime = 0;
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                if (!_A_KeyPressed)
                {
                    KeyAction.Invoke(Define.KeyEvent.A_KeyDown);
                    _A_KeyPressedTime = Time.time;
                    Debug.Log("A_Down");
                }
                KeyAction.Invoke(Define.KeyEvent.A_KeyPress);
                _A_KeyPressed = true;
                Debug.Log("A_Pressed " + _A_KeyPressed.ToString());
            }
            else
            {
                if (_A_KeyPressed)
                {
                    if (Time.time < _A_KeyPressedTime + 0.2f)
                    {
                        KeyAction.Invoke(Define.KeyEvent.A_KeyClick);
                        Debug.Log("A_Clicked");
                    }
                    KeyAction.Invoke(Define.KeyEvent.A_KeyUp);
                    Debug.Log("A_Up");
                }
                _A_KeyPressed = false;
                _A_KeyPressedTime = 0;
            }

            if (Input.GetKey(KeyCode.D))
            {
                if (!_D_KeyPressed)
                {
                    KeyAction.Invoke(Define.KeyEvent.D_KeyDown);
                    _D_KeyPressedTime = Time.time;
                    Debug.Log("D_Down");
                }
                KeyAction.Invoke(Define.KeyEvent.D_KeyPress);
                _D_KeyPressed = true;
                Debug.Log("D_Pressed " + _A_KeyPressed.ToString());
            }
            else
            {
                if (_D_KeyPressed)
                {
                    if (Time.time < _D_KeyPressedTime + 0.2f)
                    {
                        KeyAction.Invoke(Define.KeyEvent.D_KeyClick);
                        Debug.Log("D_Clicked");
                    }
                    KeyAction.Invoke(Define.KeyEvent.D_KeyUp);
                    Debug.Log("D_Up");
                }
                _D_KeyPressed = false;
                _D_KeyPressedTime = 0;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                if (!_Space_KeyPressed)
                {
                    KeyAction.Invoke(Define.KeyEvent.Space_KeyDown);
                    _D_KeyPressedTime = Time.time;
                    Debug.Log("Space_Down");
                }
                KeyAction.Invoke(Define.KeyEvent.Space_KeyPress);
                _D_KeyPressed = true;
                Debug.Log("Space_Pressed " + _Space_KeyPressed.ToString());
            }
            else
            {
                if (_Space_KeyPressed)
                {
                    if (Time.time < _Space_KeyPressedTime + 0.2f)
                    {
                        KeyAction.Invoke(Define.KeyEvent.Space_KeyClick);
                        Debug.Log("Space_Clicked");
                    }
                    KeyAction.Invoke(Define.KeyEvent.Space_KeyUp);
                    Debug.Log("Space_Up");
                }
                _Space_KeyPressed = false;
                _Space_KeyPressedTime = 0;
            }
        }

        if (MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                if (!_MousePressed)
                {
                    MouseAction.Invoke(Define.MouseEvent.PointerDown);
                    _MousePressedTime = Time.time;              
                }
                MouseAction.Invoke(Define.MouseEvent.Press);
                _MousePressed = true;
            }
            else
            {
                if (_MousePressed)
                {
                    if (Time.time < _MousePressedTime + 0.2f)
                        MouseAction.Invoke(Define.MouseEvent.Click);
                    MouseAction.Invoke(Define.MouseEvent.PointerUp);
                }
                _MousePressed = false;
                _MousePressedTime = 0;
            }
        }
    }

    public void Clear()
    {
        KeyAction = null;
        MouseAction = null;
    }
}
