using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    static public BattleManager instance;

    private BattleData currentBattleData;
    private List<Enemy> enemyList;
    [SerializeField] GameObject EnemyTrans;

    private void Awake()
    {
        instance = this;
    }
    public void StartBattle(BattleData battleData)
    {
        // ��Ʋ������ ����
        currentBattleData = battleData;

        for(int i = 0; i < EnemyTrans.transform.childCount; i++)
        {
            Destroy(EnemyTrans.transform.GetChild(i).gameObject);
        }

        // �� ����
        enemyList = new List<Enemy>();
        for (int i = 0; i < battleData.Enemies.Count; i++)
        {
            Enemy enemy = Object.Instantiate(battleData.Enemies[i], battleData.SpawnPos[i], Quaternion.identity, EnemyTrans.transform);
            enemyList.Add(enemy);
        }
    }

}
