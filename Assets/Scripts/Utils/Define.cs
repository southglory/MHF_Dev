using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum WorldObject
    {
        Unkown,
        Player,
        Monster,
    }
    public enum State
    {
        Die,
        Moving,
        Idle,
        Skill,
    }
    public enum Layer
    {
        Monster = 8,
        Ground = 9,
        Block = 10,
    }
    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum UIEvent
    {
        Click,
        Drag,
    }

    public enum MouseEvent
    {
        Press,
        PointerDown,
        PointerUp,
        Click,
    }

    public enum KeyEvent
    {
        Space_KeyDown,
        Space_KeyUp,
        Space_KeyPress,
        Space_KeyClick,

        Wasd_KeyDown,
        Wasd_KeyUp,
        Wasd_KeyPress,
        Wasd_KeyClick,
    }

    public enum CameraMode
    {
        QuarterView,
    }
}
