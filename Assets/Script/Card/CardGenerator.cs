using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGenerator : MonoBehaviour
{
    static public CardGenerator instance;

    public BaseCard BaseCardPrefab; // 카드 프리팹
    public Transform CardParent; // 카드가 생성될 부모 오브젝트
    [SerializeField] public List<CardData> AllCardList; // 카드 데이터 리스트
    private int GenerateNumber = 1; // 카드 생성 ID 카운터

    [SerializeField] public List<Sprite> attackTypeSprite;
    [SerializeField] public List<Sprite> elementTypeSprite;
    [SerializeField] public List<Sprite> attackAreaTypeSprite;

    private void Awake()
    {
        instance = this;
    }
    // 카드 이름으로 카드 생성
    public BaseCard GenerateCard(string cardName)
    {
        Debug.Log($"Searching for card: {cardName}");
        CardData cardData = AllCardList.Find(card => card.cardName == cardName);

        if (cardData == null)
        {
            Debug.LogError($"{cardName} 카드가 덱에 존재하지 않습니다.");
            return null; // 카드가 없을 경우 null 반환
        }

        return CreateCardFromData(cardData);
    }

    // 카드 데이터를 기반으로 카드 생성
    private BaseCard CreateCardFromData(CardData cardData)
    {
        if (cardData == null)
        {
            Debug.LogError("카드 데이터가 null입니다.");
            return null;
        }

        if (BaseCardPrefab == null)
        {
            Debug.LogError("BaseCardPrefab이 null입니다. 프리팹을 할당하세요.");
            return null;
        }

        BaseCard baseCard = Instantiate(BaseCardPrefab);
        cardData.AssignId(GenerateNumber); // 카드 데이터에 ID를 할당
        baseCard.name = $"player.{cardData.cardName}"; // 카드의 이름을 "player."로 시작하게 설정
        GenerateNumber++; // 다음 카드 생성 시 ID 증가

        baseCard.Init(CardParent, cardData);
        baseCard.GetComponent<Image>().sprite = cardData.cardImage;
        baseCard.transform.localScale = Vector3.zero;
        return baseCard;
    }

    //랜덤으로 카드 내보내는 함수
    public BaseCard CreateCardFromRandom()
    {
        int randNum = Random.Range(0, AllCardList.Count);

        BaseCard baseCard = Instantiate(BaseCardPrefab);
        baseCard.Init(CardParent, AllCardList[randNum]);
        baseCard.GetComponent<Image>().sprite = AllCardList[randNum].cardImage;
        baseCard.transform.localScale = Vector3.zero;

        return baseCard;
    }
}