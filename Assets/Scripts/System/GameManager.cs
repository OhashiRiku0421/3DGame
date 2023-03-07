using UnityEngine;

public class GameManager
{

    //singleton

    private static GameManager _instance = new();

    public static GameManager Instance => _instance;

    private GameManager() { }

    /// <summary>
    /// �Q�[���I�[�o�[�̃p�l�����A�N�e�B�u�ɂ���Pause����
    /// </summary>
    public void GameOver(GameObject over)
    {
        over.SetActive(true);
        PauseManager.Instance.Pause();
    }

    /// <summary>
    /// �Q�[���N���A�̃p�l�����A�N�e�B�u�ɂ���Pause����
    /// </summary>
    public void GameClear(GameObject clear)
    {
        clear.SetActive(true);
        PauseManager.Instance.Pause();
    }
}
