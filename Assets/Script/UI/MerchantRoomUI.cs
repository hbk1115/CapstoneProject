using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MerchantRoomUI : MonoBehaviour
{
    static public MerchantRoomUI instance; // 싱글턴 인스턴스, 다른 스크립트에서 쉽게 접근 가능

    [SerializeField]
    private BaseUI merchandiseUI;          // 상점 UI의 기본 UI 요소
    [SerializeField]
    private GameObject merchandiseGameObject; // 카드 상점 UI 객체
    [SerializeField]
    private GameObject merchandiseScreen;    // 상점 화면 전체를 담은 객체
    [SerializeField]
    private Transform merchandiseParent;     // 카드 상품을 표시할 부모 객체

    private Merchandise merchandise;          // 현재 표시되는 카드 상품 객체
    [SerializeField]
    private Merchandise merchandisePrefab;        // 상품으로 사용할 기본 상품 객체 프리팹
    [SerializeField]
    private Sprite merchandiseImage;     // 카드 상품에 사용할 이미지
    //[SerializeField]
    //private Sprite moneyImage; // 골드 이미지


    private void Awake()
    {
        instance = this; // 싱글턴 인스턴스 초기화
    }

    // 상점 상품 표시 함수
    public void EnterMerchantRoom()
    {
        merchandiseParent.DestroyAllChild(); // 카드 상품 초기화

        merchandiseUI.gameObject.SetActive(true); // 상점 UI 화면 활성화

        GetCard(); // 카드 상품 생성

        // 카드 상품 선택
        Merchandise merchandise = Instantiate(merchandisePrefab, merchandiseParent); // 카드 상품 객체 생성
        Button merchandiseButton = merchandise.GetComponent<Button>(); // 카드 상품 객체의 버튼 참조
        merchandise.Init("상점 나가기", merchandiseImage); // 카드 상품 초기화
       // merchandiseButton.onClick.AddListener(() => merchandiseGameObject.gameObject.SetActive(true)); // 클릭 시 카드 상품 화면 표시
        merchandiseButton.onClick.AddListener(() => merchandiseScreen.gameObject.SetActive(false)); // 상점 화면을 비활성화

    }

    // 10장의 랜덤 카드를 생성하는 함수
    private void GetCard()
    {
        BaseCard card1 = CardGenerator.instance.CreateCardFromRandom(); // 첫 번째 랜덤 카드 생성
        BaseCard card2 = CardGenerator.instance.CreateCardFromRandom(); // 두 번째 랜덤 카드 생성
        BaseCard card3 = CardGenerator.instance.CreateCardFromRandom(); // 세 번째 랜덤 카드 생성
        BaseCard card4 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card5 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card6 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card7 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card8 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card9 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card10 = CardGenerator.instance.CreateCardFromRandom();

        // 카드를 '판매 상태'로 설정
        card1.ChangeState(ECardUsage.Sell);
        card2.ChangeState(ECardUsage.Sell);
        card3.ChangeState(ECardUsage.Sell);
        card4.ChangeState(ECardUsage.Sell);
        card5.ChangeState(ECardUsage.Sell);
        card6.ChangeState(ECardUsage.Sell);
        card7.ChangeState(ECardUsage.Sell);
        card8.ChangeState(ECardUsage.Sell);
        card9.ChangeState(ECardUsage.Sell);
        card10.ChangeState(ECardUsage.Sell);

        // 각 카드의 클릭 액션 초기화 후 상품 클릭 이벤트 연결
        card1.onClickAction = null;
        card2.onClickAction = null;
        card3.onClickAction = null;
        card4.onClickAction = null;
        card5.onClickAction = null;
        card6.onClickAction = null;
        card7.onClickAction = null;
        card8.onClickAction = null;
        card9.onClickAction = null;
        card10.onClickAction = null;

        card1.onClickAction += (() => OnClickSellCard()); // 클릭 시 카드 획득 이벤트 등록
        card2.onClickAction += (() => OnClickSellCard());
        card3.onClickAction += (() => OnClickSellCard());
        card4.onClickAction += (() => OnClickSellCard());
        card5.onClickAction += (() => OnClickSellCard());
        card6.onClickAction += (() => OnClickSellCard());
        card7.onClickAction += (() => OnClickSellCard());
        card8.onClickAction += (() => OnClickSellCard());
        card9.onClickAction += (() => OnClickSellCard());
        card10.onClickAction += (() => OnClickSellCard());

        card1.transform.SetParent(merchandiseParent); // 카드 부모 객체에 배치
        card2.transform.SetParent(merchandiseParent);
        card3.transform.SetParent(merchandiseParent);
        card4.transform.SetParent(merchandiseParent);
        card5.transform.SetParent(merchandiseParent);
        card6.transform.SetParent(merchandiseParent);
        card7.transform.SetParent(merchandiseParent);
        card8.transform.SetParent(merchandiseParent);
        card9.transform.SetParent(merchandiseParent);
        card10.transform.SetParent(merchandiseParent);

        // 카드의 크기 조정
        card1.transform.localScale = Vector3.one;
        card2.transform.localScale = Vector3.one;
        card3.transform.localScale = Vector3.one;
        card4.transform.localScale = Vector3.one;
        card5.transform.localScale = Vector3.one;
        card6.transform.localScale = Vector3.one;
        card7.transform.localScale = Vector3.one;
        card8.transform.localScale = Vector3.one;
        card9.transform.localScale = Vector3.one;
        card10.transform.localScale = Vector3.one;
    }

    // 카드 획득 처리
    public void OnClickSellCard()
    {
        merchandiseGameObject.gameObject.SetActive(false); // 카드 상품 UI 비활성화
        merchandiseScreen.gameObject.SetActive(true); // 전체 상점 화면 재활성화
        Destroy(merchandise.gameObject); // 카드 상품 객체 제거
    }

}
