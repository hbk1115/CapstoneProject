using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MerchantRoomUI : MonoBehaviour
{
    static public MerchantRoomUI instance; // 싱글턴 인스턴스, 다른 스크립트에서 쉽게 접근 가능

    [SerializeField]
<<<<<<< Updated upstream
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
=======
    private BaseUI inMerchandiseUI;          // 상점 UI의 기본 UI 요소
    [SerializeField]
    private GameObject cardMerchandiseGameObject; // 카드 상점 UI 객체
    [SerializeField]
    private GameObject merchandiseScreen;    // 상점 화면 전체를 담은 객체
    [SerializeField]
    private Transform merchandiseParent;     // 일반 상품을 표시할 부모 객체
    [SerializeField]
    private Transform cardMerchandiseParent; // 카드 상품을 표시할 부모 객체

    private Reward cardMerchandise;          // 현재 표시되는 카드 상품 객체
    [SerializeField]
    private Reward merchandisePrefab;        // 상품으로 사용할 기본 상품 객체 프리팹
    [SerializeField]
    private Sprite cardMerchandiseImage;     // 카드 상품에 사용할 이미지
>>>>>>> Stashed changes


    private void Awake()
    {
        instance = this; // 싱글턴 인스턴스 초기화
    }

<<<<<<< Updated upstream
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Player.instance.PlayerState.Money += 100;
        }//
        if (Input.GetKeyDown(KeyCode.X))
        {
            EnterMerchantRoom();//이거 보시면 제가 X키 누르면 UI뜨게 한거거든요
            //그러니까 EnterMerchantRoom 자체가 UI를 띄우는 역할이라고 보면 됩니다.
        }//그러면 버튼을 프리팹으로 하면 안되고 하나 그냥 만드는게 좋습니다
    }

    // 상점 상품 표시 함수
    public void EnterMerchantRoom()
    {
        merchandiseParent.DestroyAllChild(); // 카드 상품 초기화

        merchandiseUI.gameObject.SetActive(true); // 상점 UI 화면 활성화

        GetCard(); // 카드 상품 생성

        //정확히 merchandise의 역할이 뭔가요
        //그러면 EnterMerchantRoom() 이 함수 자체를 누르는게 UI를 띄우는 방법인데
        // 카드 상품 선택<<이게 버튼이라는 것인가요? 이게 버튼이면 프리팹으로 안하고 그냥 버튼 만드는게 편할겁니다
        /*
        Merchandise merchandise = Instantiate(merchandisePrefab, merchandiseParent); // 카드 상품 객체 생성
        Button merchandiseButton = merchandise.GetComponent<Button>(); // 카드 상품 객체의 버튼 참조
        merchandise.Init("상점 나가기", merchandiseImage); // 카드 상품 초기화
       // merchandiseButton.onClick.AddListener(() => merchandiseGameObject.gameObject.SetActive(true)); // 클릭 시 카드 상품 화면 표시
        merchandiseButton.onClick.AddListener(() => merchandiseScreen.gameObject.SetActive(false)); // 상점 화면을 비활성화
        */
    }

    public void CloseMerchantUI()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.select_button);
        //그냥 간단하게 여기에 직접 넣어도 됩니다
        merchandiseScreen.gameObject.SetActive(false);
        UIManager.instance.UI_Map.gameObject.SetActive(true);
=======
    // 상점 상품 표시 함수
    public void EnterMerchantRoom()
    {
        cardMerchandiseParent.DestroyAllChild(); // 카드 상품 초기화

        inMerchandiseUI.gameObject.SetActive(true); // 상점 UI 화면 활성화

        GetCard(); // 카드 상품 생성

        // 카드 상품 선택
        cardMerchandise = Instantiate(merchandisePrefab, merchandiseParent); // 카드 상품 객체 생성
        Button cardMerchandiseButton = cardMerchandise.GetComponent<Button>(); // 카드 상품 객체의 버튼 참조
        cardMerchandise.Init("상점 나가기", cardMerchandiseImage); // 카드 상품 초기화
        cardMerchandiseButton.onClick.AddListener(() => cardMerchandiseGameObject.gameObject.SetActive(true)); // 클릭 시 카드 상품 화면 표시
        cardMerchandiseButton.onClick.AddListener(() => merchandiseScreen.gameObject.SetActive(false)); // 상점 화면을 비활성화

>>>>>>> Stashed changes
    }

    // 10장의 랜덤 카드를 생성하는 함수
    private void GetCard()
<<<<<<< Updated upstream
    {
=======
    {          
>>>>>>> Stashed changes
        BaseCard card1 = CardGenerator.instance.CreateCardFromRandom(); // 첫 번째 랜덤 카드 생성
        BaseCard card2 = CardGenerator.instance.CreateCardFromRandom(); // 두 번째 랜덤 카드 생성
        BaseCard card3 = CardGenerator.instance.CreateCardFromRandom(); // 세 번째 랜덤 카드 생성
        BaseCard card4 = CardGenerator.instance.CreateCardFromRandom();
<<<<<<< Updated upstream
        BaseCard card5 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card6 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card7 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card8 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card9 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card10 = CardGenerator.instance.CreateCardFromRandom();

        // 카드를 '판매 상태'로 설정
=======
        BaseCard card5 = CardGenerator.instance.CreateCardFromRandom(); 
        BaseCard card6 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card7 = CardGenerator.instance.CreateCardFromRandom(); 
        BaseCard card8 = CardGenerator.instance.CreateCardFromRandom(); 
        BaseCard card9 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card10 = CardGenerator.instance.CreateCardFromRandom(); 

        // 카드를 '획득 상태'로 설정
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
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
=======
        card9.onClickAction += (() => OnClickSellCard()); 
        card10.onClickAction += (() => OnClickSellCard()); 

        card1.transform.SetParent(cardMerchandiseParent); // 카드 부모 객체에 배치
        card2.transform.SetParent(cardMerchandiseParent);
        card3.transform.SetParent(cardMerchandiseParent);
        card4.transform.SetParent(cardMerchandiseParent); 
        card5.transform.SetParent(cardMerchandiseParent);
        card6.transform.SetParent(cardMerchandiseParent);
        card7.transform.SetParent(cardMerchandiseParent); 
        card8.transform.SetParent(cardMerchandiseParent);
        card9.transform.SetParent(cardMerchandiseParent);
        card10.transform.SetParent(cardMerchandiseParent); 
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
        merchandiseGameObject.gameObject.SetActive(false); // 카드 상품 UI 비활성화
        merchandiseScreen.gameObject.SetActive(true); // 전체 상점 화면 재활성화
        //Destroy(merchandise.gameObject); // 카드 상품 객체 제거//이거 없어도 될 것 같은데
        //애초에 잘못된걸 삭제하고 있어서, 카드 오브젝트가 아닌 다른걸 삭제하고 있어서 안되는 것 같습니다.
    }
=======
        cardMerchandiseGameObject.gameObject.SetActive(false); // 카드 상품 UI 비활성화
        merchandiseScreen.gameObject.SetActive(true); // 전체 상점 화면 재활성화
        Destroy(cardMerchandise.gameObject); // 카드 상품 객체 제거
    }

>>>>>>> Stashed changes
}
