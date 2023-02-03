using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("�K�v�ȃ`�[���̐�")]
    private int _teamNum = 10;
    [SerializeField]
    private TeamObjectPool _teamPool = null;
    [SerializeField]
    private PlayercCntroller _player;

    public void Generator(Transform[] transforms)
    {
        for(int i = 0; i < _teamNum; i++)
        {
            TeamPop(transforms);
        }
    }

    /// <summary>
    /// Pool�̃I�u�W�F�N�g���ǂ��Ŏg���������߂郁�\�b�h
    /// </summary>
    private void TeamPop(Transform[] teamPos)
    {
        foreach (var n in teamPos)
        {
            if(!n.gameObject.activeSelf)
            {
                n.gameObject.SetActive(true);
                //_teamPool.PoolPop(n);
                return;
            }
        }

        Debug.LogError("����葽���g�����Ƃ��Ă��܂��B");
    }
    //private void Test(Transform trans)
    //{
    //    for (int i = 0; i < _teamNum; i++)
    //    {
    //        _teamPool.PoolPop(trans);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayercCntroller>(out PlayercCntroller playercCntroller))
        {
            //Generator(playercCntroller.TeamPos);
            //Test(playercCntroller._test);
            Test(playercCntroller.Dir);
        }
    }

    private void Test(Vector2 player)
    {
        for(int i = 0; i < _teamNum; i++)
        {
            var rand = 3 * Random.insideUnitCircle + _player.Dir;
            _teamPool.PoolPop(rand);
        }
    }
}
