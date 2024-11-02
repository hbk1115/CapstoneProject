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

        BattleData_Stage_1.ShuffleList();
        BattleData_Stage_2.ShuffleList();
        BattleData_Stage_3.ShuffleList();

        BattleData_Boss_Stage_1.ShuffleList();
        BattleData_Boss_Stage_2.ShuffleList();
        BattleData_Boss_Stage_3.ShuffleList();
    }

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
                StartCoroutine(OnEnterEnemyRoom());
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

    // �Ϲ� �� �濡 �� ��
    private IEnumerator OnEnterEnemyRoom()
    {
        // �ʹݿ� ���� ��
        if (_isEarly)
        {
            yield return UIManager.instance.OpenDoor();
            BattleManager.instance.StartBattle(BattleData_Stage_1[battle1Index]);
            battle1Index++;
            if (battle1Index == BattleData_Stage_1.Count)
                battle1Index = 0;

            yield return UIManager.instance.CloseDoor();
        }
    }

    // ����Ʈ �濡 �� ��
    private void OnEnterEliteRoom()
    {
        BattleManager.instance.StartBattle(BattleData_Boss_Stage_1[0]);
    }

    // ���� �濡 �� ��
    private void OnEnterMerchantRoom()
    {

    }

    // �޽� �濡 �� ��
    private void OnEnterRestRoom()
    {

    }

    // ���� �濡 �� ��
    private void OnEnterTreasureRoom()
    {
        
    }

    // ���� �濡 �� ��
    public void OnEnterBossRoom()
    {

    }

    // ���� �濡 �� ��
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
