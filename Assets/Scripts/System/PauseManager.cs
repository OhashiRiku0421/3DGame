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
    /// IPause���p�����Ă���I�u�W�F�N�g��������A�N�V�����ɓo�^����
    /// </summary>
    public void Entry(GameObject pauseObject)
    {
        if(pauseObject.TryGetComponent<IPause>(out IPause pause))
        {
            OnPause += pause.Pause;
            OnResume += pause.Resume;
        }
    }

    /// <summary>
    /// IPause���p�����Ă���I�u�W�F�N�g��������A�N�V��������������
    /// </summary>
    public void Lift(GameObject pauseObject)
    {
        if (pauseObject.TryGetComponent<IPause>(out IPause pause))
        {
            OnPause -= pause.Pause;
            OnResume -= pause.Resume;
        }
    }

    /// <summary>
    /// OnPause�ɓo�^���Ă��郁�\�b�h���g�p����
    /// </summary>
    public void Pause()
    {
        OnPause?.Invoke();
    }
}
