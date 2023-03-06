using System.Collections;
using UnityEngine;
using System;

public class PauseManager
{

    private static PauseManager _instance = new();

    public static PauseManager Instance => _instance;

    private PauseManager() { }

    public Action OnPause;
    public Action OnResume;

    public void Entry(GameObject pauseObject)
    {
        if(pauseObject.TryGetComponent<IPause>(out IPause pause))
        {
            OnPause += pause.Pause;
            OnResume += pause.Resume;
        }
    }

    public void Lift(GameObject pauseObject)
    {
        if (pauseObject.TryGetComponent<IPause>(out IPause pause))
        {
            OnPause -= pause.Pause;
            OnResume -= pause.Resume;
        }
    }

    public void Pause()
    {
        OnPause?.Invoke();
    }
}
