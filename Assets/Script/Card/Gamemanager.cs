using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CardGenerator cardGenerator;

    void Start()
    {
        // ���� ���� �� ī�� ����
        for (int i = 0; i < 10; i++) // ���÷� 10���� ī�带 ����
        {
            cardGenerator.GenerateRandomCard();
        }
    }
}