using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GimmickView : MonoBehaviour
{
    [SerializeField]
    private Text _gimmickCountText;

    public void GimmickCountText(int count)
    {
        _gimmickCountText.text = count.ToString();
    }
}
