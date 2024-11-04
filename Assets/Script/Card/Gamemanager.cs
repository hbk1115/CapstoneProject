using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CardGenerator cardGenerator; // 카드 생성기 인스턴스
    

    void Start()
    {

        if (cardGenerator == null)
        {
            Debug.LogError("CardGenerator가 할당되지 않았습니다!");
            return; // 오류 메시지 출력 후 메서드 종료
        }

        Player.instance.CardGenerator = cardGenerator;
        Player.instance.GenerateCard("낚시대");
        Player.instance.GenerateCard("파도");
        Player.instance.GenerateCard("얼음");
        Player.instance.GenerateCard("얼음창");
        Player.instance.GenerateCard("호미");
        Player.instance.GenerateCard("호미");
        Player.instance.GenerateCard("호미");
        Player.instance.GenerateCard("호미");
        Player.instance.GenerateCard("호미");
        Player.instance.GenerateCard("호미");
        Player.instance.GenerateCard("호미");
        Player.instance.GenerateCard("호미");
        Player.instance.GenerateCard("성냥");
        Player.instance.GenerateCard("성냥");

        //CardHolder.instance.StartBattle(Player.instance.PlayerDeck);

        UIManager.instance.SetMapUI(true);
    }
}