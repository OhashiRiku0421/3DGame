using UnityEngine;

public class GameManager
{

    //singleton

    private static GameManager _instance = new();

    public static GameManager Instance => _instance;

    private GameManager() { }

    /// <summary>
    /// ゲームオーバーのパネルをアクティブにしてPauseする
    /// </summary>
    public void GameOver(GameObject over)
    {
        over.SetActive(true);
        PauseManager.Instance.Pause();
    }

    /// <summary>
    /// ゲームクリアのパネルをアクティブにしてPauseする
    /// </summary>
    public void GameClear(GameObject clear)
    {
        clear.SetActive(true);
        PauseManager.Instance.Pause();
    }
}
