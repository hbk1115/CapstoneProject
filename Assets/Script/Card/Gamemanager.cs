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
        Debug.Log("Warrior ī�� �����Ͱ� ���������� �����Ǿ����ϴ�."); // ī�� ������ ���� Ȯ��

        Player.instance.CardGenerator = cardGenerator;
        Player.instance.GenerateRandomCard();
        Player.instance.GenerateRandomCard();
        Player.instance.GenerateRandomCard();
        Player.instance.GenerateRandomCard();

        // �÷��̾� ���� �� �ʱ�ȭ
        //Player player = gameObject.AddComponent<Player>();
        //player.CardGenerator = cardGenerator; // CardGenerator ����

        // ī�� ���� ����: ���� ī�� ����
        //player.GenerateRandomCard(); // ���� ���� ī�� ����
    }
}