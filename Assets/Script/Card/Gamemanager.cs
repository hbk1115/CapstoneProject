using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CardGenerator cardGenerator; // ī�� ������ �ν��Ͻ�

    void Start()
    {
        if (cardGenerator == null)
        {
            Debug.LogError("CardGenerator�� �Ҵ���� �ʾҽ��ϴ�!");
            return; // ���� �޽��� ��� �� �޼��� ����
        }

        // ī�� ������ ����Ʈ �ʱ�ȭ
        //cardGenerator.AllCardList = new List<CardData>();

        // ī�� �����͸� ����Ʈ�� �߰�
       // cardGenerator.AllCardList.Add(warriorCard);

        Player.instance.CardGenerator = cardGenerator;
        Player.instance.GenerateRandomCard();
        Player.instance.GenerateRandomCard();
        Player.instance.GenerateRandomCard();
        Player.instance.GenerateRandomCard();
        Player.instance.GenerateRandomCard();
        Player.instance.GenerateRandomCard();
        Player.instance.GenerateRandomCard();

        //CardHolder.instance.StartBattle(Player.instance.PlayerDeck);

        UIManager.instance.SetMapUI(true);
    }
}