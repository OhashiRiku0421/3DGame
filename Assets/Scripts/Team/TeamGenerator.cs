using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("必要なチームの数")]
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
    /// poolから必要な分使う
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
