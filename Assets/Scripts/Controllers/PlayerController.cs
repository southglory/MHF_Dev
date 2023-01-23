using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : BaseController
{

    int _mask = (1 << (int)Define.Layer.Ground) | (1 << (int)Define.Layer.Monster);

    PlayerStat _stat;
    bool _stopSkill = false;

    float _speed = 3.0f;
    float _yAngle = 0.0f;


    public override void Init()
    {
        WorldObjectType = Define.WorldObject.Player;
        _stat = gameObject.GetComponent<PlayerStat>();
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
            case Define.KeyEvent.W_KeyPress:
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
                transform.position += _speed * Time.deltaTime * Vector3.forward;
                break;
        }
    }       
	
}
