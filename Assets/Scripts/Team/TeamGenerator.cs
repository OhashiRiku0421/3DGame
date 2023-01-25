using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("�K�v�ȃ`�[���̐�")]
    private int _teamNum = 10;
    [SerializeField]
    private TeamObjectPool _teamPool;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayercCntroller>(out PlayercCntroller playerController))
        {
            TeamPop(playerController.TeamPos);
        }
    }

    /// <summary>
    /// pool����K�v�ȕ��g��
    /// </summary>
    private void TeamPop(List<Transform> teamPos)
    {
        for(int i = 0; i < _teamNum; i++)
        {
            int test = Random.Range(0, teamPos.Count);
            _teamPool.PoolPop(teamPos[test]);
        }
    }
}
