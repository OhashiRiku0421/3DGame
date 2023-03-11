using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamView : MonoBehaviour
{

    [SerializeField, Tooltip("ミイラの残り")]
    private Text _countText;

    /// <summary>
    /// テキストに現在のカウントを代入する
    /// </summary>
    public void CountView(int count)
    {
        _countText.text = count.ToString();
    }
}
