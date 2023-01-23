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
            Debug.Log("Pressed " + _W_KeyPressed.ToString());

            //if (Input.GetKey(KeyCode.S))
            //{
            //    if (!_W_KeyPressed)
            //    {
            //        KeyAction.Invoke(Define.KeyEvent.W_KeyDown);
            //        _W_KeyPressedTime = Time.time;
            //    }
            //    KeyAction.Invoke(Define.KeyEvent.W_KeyPress);
            //    _W_KeyPressed = true;
            //}
            //else
            //{
            //    if (_W_KeyPressed)
            //    {
            //        if (Time.time < _W_KeyPressedTime + 0.2f)
            //            KeyAction.Invoke(Define.KeyEvent.W_KeyClick);
            //        KeyAction.Invoke(Define.KeyEvent.W_KeyUp);
            //    }
            //    _W_KeyPressed = false;
            //    _W_KeyPressedTime = 0;
            //}
            //if (Input.GetKey(KeyCode.A))
            //{
            //    if (!_W_KeyPressed)
            //    {
            //        KeyAction.Invoke(Define.KeyEvent.W_KeyDown);
            //        _W_KeyPressedTime = Time.time;
            //    }
            //    KeyAction.Invoke(Define.KeyEvent.W_KeyPress);
            //    _W_KeyPressed = true;
            //}
            //else
            //{
            //    if (_W_KeyPressed)
            //    {
            //        if (Time.time < _W_KeyPressedTime + 0.2f)
            //            KeyAction.Invoke(Define.KeyEvent.W_KeyClick);
            //        KeyAction.Invoke(Define.KeyEvent.W_KeyUp);
            //    }
            //    _W_KeyPressed = false;
            //    _W_KeyPressedTime = 0;
            //}
            //if (Input.GetKey(KeyCode.D))
            //{
            //    if (!_W_KeyPressed)
            //    {
            //        KeyAction.Invoke(Define.KeyEvent.W_KeyDown);
            //        _W_KeyPressedTime = Time.time;
            //    }
            //    KeyAction.Invoke(Define.KeyEvent.W_KeyPress);
            //    _W_KeyPressed = true;
            //}
            //else
            //{
            //    if (_W_KeyPressed)
            //    {
            //        if (Time.time < _W_KeyPressedTime + 0.2f)
            //            KeyAction.Invoke(Define.KeyEvent.W_KeyClick);
            //        KeyAction.Invoke(Define.KeyEvent.W_KeyUp);
            //    }
            //    _W_KeyPressed = false;
            //    _W_KeyPressedTime = 0;
            //}
        }


        //   void OnKeyboard()
        //   {
        //	if (Input.GetKey(KeyCode.W))
        //	{
        //		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
        //		transform.position += Vector3.forward * Time.deltaTime * _speed;
        //	}

        //	if (Input.GetKey(KeyCode.S))
        //	{
        //		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
        //		transform.position += Vector3.back * Time.deltaTime * _speed;
        //	}

        //	if (Input.GetKey(KeyCode.A))
        //	{
        //		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
        //		transform.position += Vector3.left * Time.deltaTime * _speed;
        //	}

        //	if (Input.GetKey(KeyCode.D))
        //	{
        //		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
        //		transform.position += Vector3.right * Time.deltaTime * _speed;
        //	}

        //	_moveToDest = false;
        //}

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
