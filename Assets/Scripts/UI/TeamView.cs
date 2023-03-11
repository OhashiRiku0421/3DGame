using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamView : MonoBehaviour
{

    [SerializeField, Tooltip("�~�C���̎c��")]
    private Text _countText;

    /// <summary>
    /// �e�L�X�g�Ɍ��݂̃J�E���g��������
    /// </summary>
    public void CountView(int count)
    {
        _countText.text = count.ToString();
    }
}
