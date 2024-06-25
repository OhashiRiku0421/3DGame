using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StageData
{
    private static HashSet<int> _clearStageIndexs = new HashSet<int>();

    private static int _currentStageIndex = 0;

    public static int CurrentStageIndex
    { get => _currentStageIndex; set => _currentStageIndex = value; }

    public static HashSet<int> ClearStageIndexs
    {
        get => _clearStageIndexs;
        set => _clearStageIndexs = value;
    }

    public static void AddClearStageIndex(int stageIndex)
    {
        _clearStageIndexs.Add(stageIndex);
        SaveLoadSystem.Instance.DataSave(_clearStageIndexs.ToList());
    }
}
