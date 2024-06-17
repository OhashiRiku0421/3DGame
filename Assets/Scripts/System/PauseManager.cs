using UnityEngine;
using System;

public class PauseManager
{

    //singleton

    private static PauseManager _instance = new();

    public static PauseManager Instance => _instance;

    private PauseManager() { }

    public Action OnPause;
    public Action OnResume;

    /// <summary>
    /// IPauseを継承しているオブジェクトだったらアクションに登録する
    /// </summary>
    public void Entry(IPause pause)
    {
        OnPause += pause.Pause;
        OnResume += pause.Resume;
    }

    /// <summary>
    /// IPauseを継承しているオブジェクトだったらアクションを解除する
    /// </summary>
    public void Lift(IPause pause)
    {
        OnPause -= pause.Pause;
        OnResume -= pause.Resume;
    }

    /// <summary>
    /// OnPauseに登録しているメソッドを使用する
    /// </summary>
    public void Pause()
    {
        OnPause?.Invoke();
    }
}
