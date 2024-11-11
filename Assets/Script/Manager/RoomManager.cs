using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.Arm;

public class RoomManager : MonoBehaviour
{
    static public RoomManager instance;
    [Header("Battle")]
    [SerializeField]
    private List<BattleData> BattleData_Stage_1;
    [SerializeField]
    private List<BattleData> BattleData_Stage_2;
    [SerializeField]
    private List<BattleData> BattleData_Stage_3;
    [SerializeField]
    private List<BattleData> BattleData_Boss_Stage_1;
    [SerializeField]
    private List<BattleData> BattleData_Boss_Stage_2;
    [SerializeField]
    private List<BattleData> BattleData_Boss_Stage_3;

    private bool _isEarly = true;
    private bool isBossGoable = false;
    private int height = 1;

    private int battle1Index = 0;
    private int battle2Index = 0;
    private int battle3Index = 0;
    private int unknownIndex = 0;

    private int nowStage = 1;//스테이지 넘어가는거 체크용

    private void Awake()
    {
        instance = this;
        Init();
    }
    public void Init()
    {
        battle1Index = 0;
        battle2Index = 0;
        battle3Index = 0;
        unknownIndex = 0;

        BattleData_Stage_1.ShuffleList();
        BattleData_Stage_2.ShuffleList();
        BattleData_Stage_3.ShuffleList();

        BattleData_Boss_Stage_1.ShuffleList();
        BattleData_Boss_Stage_2.ShuffleList();
        BattleData_Boss_Stage_3.ShuffleList();
    }

    public void EnterRoom(ERoomType roomType, int stageNum)
    {
        switch (roomType)
        {
            case ERoomType.Elite:

                StartCoroutine(OnEnterEliteRoom(stageNum));
                break;
            case ERoomType.Enemy:
                //battleManager.Player.gameObject.SetActive(true);
                //battleManager.Player.PlayerStat.IsBattle(true);
                StartCoroutine(OnEnterEnemyRoom(stageNum));
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
    private IEnumerator OnEnterEnemyRoom(int stageNum)
    {
        // 초반에 쉬운 적
        if (_isEarly)
        {
            yield return UIManager.instance.OpenDoor();
            if(stageNum == 1)
            {
                BattleManager.instance.StartBattle(BattleData_Stage_1[battle1Index]);
                battle1Index++;
                if (battle1Index == BattleData_Stage_1.Count)
                    battle1Index = 0;
            }
            else if(stageNum == 2)
            {
                BattleManager.instance.StartBattle(BattleData_Stage_2[battle2Index]);
                battle2Index++;
                if (battle2Index == BattleData_Stage_2.Count)
                    battle2Index = 0;
            }
            else
            {
                BattleManager.instance.StartBattle(BattleData_Stage_3[battle3Index]);
                battle3Index++;
                if (battle3Index == BattleData_Stage_3.Count)
                    battle3Index = 0;
            }

            yield return UIManager.instance.CloseDoor();
        }

        if (nowStage != BattleManager.instance.stage)//만약 스테이지가 바뀐거면 보스가 잡힌거임. 브금 바꿔줌
        {
            AudioManager.instance.PlayNewBgm(AudioManager.Bgm.inBattle);
            nowStage = BattleManager.instance.stage;
        }
        else
        {
            nowStage = BattleManager.instance.stage;
        }
    }

    // 엘리트 방에 들어갈 때
    private IEnumerator OnEnterEliteRoom(int stageNum)
    {
        yield return UIManager.instance.OpenDoor();

        int num = Random.Range(0, 3);

        if (stageNum == 1)
        {
            BattleManager.instance.StartBattle(BattleData_Boss_Stage_1[num]);
        }
        else if (stageNum == 2)
        {
            BattleManager.instance.StartBattle(BattleData_Boss_Stage_2[num]);
        }
        else
        {
            BattleManager.instance.StartBattle(BattleData_Boss_Stage_3[num]);
        }
        //BattleManager.instance.StartBattle(BattleData_Boss_Stage_1[0]);
        yield return UIManager.instance.CloseDoor();

        AudioManager.instance.PlayNewBgm(AudioManager.Bgm.inBossBattle);
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
