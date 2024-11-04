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

        Player.instance.CardGenerator = cardGenerator;
        Player.instance.GenerateCard("���ô�");
        Player.instance.GenerateCard("�ĵ�");
        Player.instance.GenerateCard("����");
        Player.instance.GenerateCard("����â");
        Player.instance.GenerateCard("ȣ��");
        Player.instance.GenerateCard("ȣ��");
        Player.instance.GenerateCard("ȣ��");
        Player.instance.GenerateCard("ȣ��");
        Player.instance.GenerateCard("ȣ��");
        Player.instance.GenerateCard("ȣ��");
        Player.instance.GenerateCard("ȣ��");
        Player.instance.GenerateCard("ȣ��");
        Player.instance.GenerateCard("����");
        Player.instance.GenerateCard("����");

        //CardHolder.instance.StartBattle(Player.instance.PlayerDeck);

        UIManager.instance.SetMapUI(true);
    }
}