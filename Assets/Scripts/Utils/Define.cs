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
        W_KeyDown,
        W_KeyUp,
        W_KeyPress,
        W_KeyClick,
        S_KeyDown,
        S_KeyUp,
        S_KeyPress,
        S_KeyClick,
        A_KeyDown,
        A_KeyUp,
        A_KeyPress,
        A_KeyClick,
        D_KeyDown,
        D_KeyUp,
        D_KeyPress,
        D_KeyClick,
        Space_KeyDown,
        Space_KeyUp,
        Space_KeyPress,
        Space_KeyClick,
    }

    public enum CameraMode
    {
        QuarterView,
    }
}
