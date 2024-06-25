using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    [SerializeField]
    private Button[] _stageButtons;

    private void Start()
    {
        //セーブデータがある場合ロードする
        if (SaveLoadSystem.Instance.DataLoad() != null)
        {
            StageData.ClearStageIndexs = SaveLoadSystem.Instance.DataLoad().ToHashSet();
        }

        if (StageData.ClearStageIndexs.Count == 0)
        {
            _stageButtons[0].interactable = true;
            StageData.AddClearStageIndex(-1);
        }

        foreach(int index in StageData.ClearStageIndexs)
        {
            if(index < _stageButtons.Length - 1)
            {
                _stageButtons[index + 1].interactable = true;
            }
        }
    }

    public void OnStageSelect(int index)
    {
        StageData.CurrentStageIndex = index;
    }
}
