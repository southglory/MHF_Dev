using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Windows;

public class PlayerController : BaseController
{

    int _mask = (1 << (int)Define.Layer.Ground) | (1 << (int)Define.Layer.Monster);

    PlayerStat _stat;
    private CapsuleCollider coll;
    private Rigidbody playerRigidbody;

    bool _stopSkill = false;

    float _JumpPower = 3.0f;
    float _speed = 3.0f;
    float _yAngle = 0.0f;

    float xInput;
    float yInput;

    public override void Init()
    {
        coll = gameObject.GetComponent<CapsuleCollider>();
        PhysicMaterial material = new PhysicMaterial();
        material.dynamicFriction = 1;
        coll.material = material;

        WorldObjectType = Define.WorldObject.Player;
        _stat = gameObject.GetComponent<PlayerStat>();
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
		Managers.Input.KeyAction -= OnKeyEvent;
		Managers.Input.KeyAction += OnKeyEvent;

        if (gameObject.GetComponentInChildren<UI_HPBar>() == null)
            Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);
    }

	protected override void UpdateMoving()
	{

    }

    protected override void UpdateSkill()
	{
        if (_lockTarget != null)
        {
            Vector3 dir = _lockTarget.transform.position - transform.position;
            Quaternion quat = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, quat, 20 * Time.deltaTime);
        }
	}

	void OnHitEvent()
	{
        if (_lockTarget != null)
        {
            Stat targetStat = _lockTarget.GetComponent<Stat>();
            targetStat.OnAttacked(_stat);
        }

        if (_stopSkill)
        {
            State = Define.State.Idle;
        }
        else
        {
            State = Define.State.Skill;
        }
   
	}

    void OnKeyEvent(Define.KeyEvent evt)
    {
        switch (State)
        {
            case Define.State.Idle:
                onKeyEvent_IdleRun(evt);
                break;
            case Define.State.Moving:
                onKeyEvent_IdleRun(evt);
                break;
            case Define.State.Skill:
                break;
        }
    }

    void onKeyEvent_IdleRun(Define.KeyEvent evt)
    {
        switch (evt)
        {
            case Define.KeyEvent.Space_KeyDown:
                //transform.position += 
                //Vector3 _ = new Vector3(0f, _jumpSpeed * Time.deltaTime, 0f) - transform.position;
                //transform.Translate(Vector3.Lerp(transform.position, _, 0.2f));
                //playerRigidbody.transform.Translate(_);
                playerRigidbody.AddForce(Vector3.up * _JumpPower, ForceMode.Impulse);
                break;
            case Define.KeyEvent.Wasd_KeyPress:
                transform.position += Managers.Input.xzInput * _speed * Time.deltaTime;
                break;
        }
    }       
	
}
