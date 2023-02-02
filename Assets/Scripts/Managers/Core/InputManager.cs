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

    bool _Space_KeyPressed = false;
    float _Space_KeyPressedTime = 0;

    bool _Wasd_KeyPressed = false;
    float _Wasd_KeyPressedTime = 0;

    float xInput = 0f;
    float zInput = 0f;
    public Vector3 xzInput = Vector3.zero;

    public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        // 키보드
        if (KeyAction != null)
        {
            // 점프, space키가 눌리면,
            if (Input.GetKey(KeyCode.Space))
            {
                // 이전에 점프키가 안눌려 있었으면 KeyDown 이벤트를 Invoke.
                if (!_Space_KeyPressed)
                {
                    KeyAction.Invoke(Define.KeyEvent.Space_KeyDown);
                    _Space_KeyPressedTime = Time.time;
                    Debug.Log("Space_Down");
                }
                // 그리고 점프키Press 이벤트를 Invoke
                KeyAction.Invoke(Define.KeyEvent.Space_KeyPress);
                _Space_KeyPressed = true;
                Debug.Log("Space_Pressed " + _Space_KeyPressed.ToString());
            }
            // 그렇지 않고 점프키에 값이 안 들어왔으면
            else
            {
                // 이전에 점프키가 눌려 있었으면
                if (_Space_KeyPressed)
                {
                    // 0.2초보다 짧게 눌렸다면 KeyClick 이벤트를 Invoke.
                    if (Time.time < _Space_KeyPressedTime + 0.2f)
                    {
                        KeyAction.Invoke(Define.KeyEvent.Space_KeyClick);
                        Debug.Log("Space_Clicked");
                    }
                    // 그리고 점프키Up 이벤트를 Invoke
                    KeyAction.Invoke(Define.KeyEvent.Space_KeyUp);
                    Debug.Log("Space_Up");
                }
                // 그리고 점프키 정보 초기화.
                _Space_KeyPressed = false;
                _Space_KeyPressedTime = 0;
            }

            // 움직임 인풋키에 값이 있으면
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                // 앞뒤좌우, 대각 움직임 인풋키 
                xInput = Input.GetAxisRaw("Horizontal");
                zInput = Input.GetAxisRaw("Vertical");
                xzInput = new Vector3(xInput, 0f, zInput).normalized;
                // 이전에 움직임키가 안눌려 있었으면 KeyDown 이벤트를 Invoke.
                if (!_Wasd_KeyPressed)
                {
                    KeyAction.Invoke(Define.KeyEvent.Wasd_KeyDown);
                    _Wasd_KeyPressedTime = Time.time;
                    Debug.Log("Wasd_Down");
                }
                // 그리고 움직임키Press 이벤트를 Invoke.
                KeyAction.Invoke(Define.KeyEvent.Wasd_KeyPress);
                _Wasd_KeyPressed = true;
                Debug.Log("Wasd_Pressed " + _Wasd_KeyPressed.ToString());
            }
            // 그렇지 않고 움직임 인풋키에 값이 안 들어왔으면
            else
            {
                // 이전에 움직임키가 눌려 있었으면
                if (_Wasd_KeyPressed)
                {
                    // 0.2초보다 짧게 눌렸다면 KeyClick 이벤트를 Invoke.
                    if (Time.time < _Wasd_KeyPressedTime + 0.2f)
                    {
                        KeyAction.Invoke(Define.KeyEvent.Wasd_KeyClick);
                        Debug.Log("Wasd_Clicked");
                    }
                    // 그리고 움직임키Up 이벤트를 Invoke.
                    KeyAction.Invoke(Define.KeyEvent.Wasd_KeyUp);
                    Debug.Log("Wasd_Up");
                }
                // 그리고 움직임키 정보 초기화.
                _Wasd_KeyPressed = false;
                _Wasd_KeyPressedTime = 0;
            }
        }

        // 마우스
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
