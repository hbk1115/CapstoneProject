using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.Arm;

public class RoomManager : MonoBehaviour
{
    static public RoomManager instance;
    [Header("Battle")]
    [SerializeField]
    private List<BattleData> firstAct1BattleData;

    private bool _isEarly = true;
    private bool isBossGoable = false;
    private int height = 1;

    private int battle1Index = 0;
    private int battle2Index = 0;
    private int unknownIndex = 0;

    private void Awake()
    {
        instance = this;
        Init();
    }
    public void Init()
    {
        battle1Index = 0;
        battle2Index = 0;
        unknownIndex = 0;

        //firstAct1BattleData.ShuffleList();
    }

    /*    private void Awake()
        {
            battle1Index = 0;
            battle2Index = 0;
            unknownIndex = 0;

            firstAct1BattleData.ShuffleList();
            secondAct1BattleData.ShuffleList();
            act1UnknownData.ShuffleList();
        }*/

    public void EnterRoom(ERoomType roomType)
    {
        switch (roomType)
        {
            case ERoomType.Elite:

                OnEnterEliteRoom();
                break;
            case ERoomType.Enemy:
                //battleManager.Player.gameObject.SetActive(true);
                //battleManager.Player.PlayerStat.IsBattle(true);
                OnEnterEnemyRoom();
                break;
            case ERoomType.Merchant:

                OnEnterMerchantRoom();
                break;
            case ERoomType.Rest:

                OnEnterRestRoom();
                break;
            case ERoomType.Treasure:

                OnEnterTreasureRoom();
                break;
            case ERoomType.Unknown:

                OnEnterUnknownRoom();
                break;
        }
    }

    // 일반 적 방에 들어갈 때
    private void OnEnterEnemyRoom()
    {
        // 초반에 쉬운 적
        if (_isEarly)
        {
            BattleManager.instance.StartBattle(firstAct1BattleData[battle1Index]);
            battle1Index++;
            if (battle1Index == firstAct1BattleData.Count)
                battle1Index = 0;
        }
    }

    // 엘리트 방에 들어갈 때
    private void OnEnterEliteRoom()
    {

    }

    // 상인 방에 들어갈 때
    private void OnEnterMerchantRoom()
    {

    }

    // 휴식 방에 들어갈 때
    private void OnEnterRestRoom()
    {

    }

    // 보물 방에 들어갈 때
    private void OnEnterTreasureRoom()
    {

    }

    // 보스 방에 들어갈 때
    public void OnEnterBossRoom()
    {

    }

    // 랜덤 방에 들어갈 때
    private void OnEnterUnknownRoom()
    {

    }

    public void NextUnknown()
    {

    }

    public void AfterUnknown()
    {

    }

    public void AfterUnknown2()
    {

    }


    public void ClearRoom()
    {

    }
}
