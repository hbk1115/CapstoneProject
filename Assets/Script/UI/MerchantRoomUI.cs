using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MerchantRoomUI : MonoBehaviour
{
    static public MerchantRoomUI instance; // �̱��� �ν��Ͻ�, �ٸ� ��ũ��Ʈ���� ���� ���� ����

    [SerializeField]
<<<<<<< Updated upstream
    private BaseUI merchandiseUI;          // ���� UI�� �⺻ UI ���
    [SerializeField]
    private GameObject merchandiseGameObject; // ī�� ���� UI ��ü
    [SerializeField]
    private GameObject merchandiseScreen;    // ���� ȭ�� ��ü�� ���� ��ü
    [SerializeField]
    private Transform merchandiseParent;     // ī�� ��ǰ�� ǥ���� �θ� ��ü

    private Merchandise merchandise;          // ���� ǥ�õǴ� ī�� ��ǰ ��ü
    [SerializeField]
    private Merchandise merchandisePrefab;        // ��ǰ���� ����� �⺻ ��ǰ ��ü ������
    [SerializeField]
    private Sprite merchandiseImage;     // ī�� ��ǰ�� ����� �̹���
    //[SerializeField]
    //private Sprite moneyImage; // ��� �̹���
=======
    private BaseUI inMerchandiseUI;          // ���� UI�� �⺻ UI ���
    [SerializeField]
    private GameObject cardMerchandiseGameObject; // ī�� ���� UI ��ü
    [SerializeField]
    private GameObject merchandiseScreen;    // ���� ȭ�� ��ü�� ���� ��ü
    [SerializeField]
    private Transform merchandiseParent;     // �Ϲ� ��ǰ�� ǥ���� �θ� ��ü
    [SerializeField]
    private Transform cardMerchandiseParent; // ī�� ��ǰ�� ǥ���� �θ� ��ü

    private Reward cardMerchandise;          // ���� ǥ�õǴ� ī�� ��ǰ ��ü
    [SerializeField]
    private Reward merchandisePrefab;        // ��ǰ���� ����� �⺻ ��ǰ ��ü ������
    [SerializeField]
    private Sprite cardMerchandiseImage;     // ī�� ��ǰ�� ����� �̹���
>>>>>>> Stashed changes


    private void Awake()
    {
        instance = this; // �̱��� �ν��Ͻ� �ʱ�ȭ
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
            EnterMerchantRoom();//�̰� ���ø� ���� XŰ ������ UI�߰� �ѰŰŵ��
            //�׷��ϱ� EnterMerchantRoom ��ü�� UI�� ���� �����̶�� ���� �˴ϴ�.
        }//�׷��� ��ư�� ���������� �ϸ� �ȵǰ� �ϳ� �׳� ����°� �����ϴ�
    }

    // ���� ��ǰ ǥ�� �Լ�
    public void EnterMerchantRoom()
    {
        merchandiseParent.DestroyAllChild(); // ī�� ��ǰ �ʱ�ȭ

        merchandiseUI.gameObject.SetActive(true); // ���� UI ȭ�� Ȱ��ȭ

        GetCard(); // ī�� ��ǰ ����

        //��Ȯ�� merchandise�� ������ ������
        //�׷��� EnterMerchantRoom() �� �Լ� ��ü�� �����°� UI�� ���� ����ε�
        // ī�� ��ǰ ����<<�̰� ��ư�̶�� ���ΰ���? �̰� ��ư�̸� ���������� ���ϰ� �׳� ��ư ����°� ���Ұ̴ϴ�
        /*
        Merchandise merchandise = Instantiate(merchandisePrefab, merchandiseParent); // ī�� ��ǰ ��ü ����
        Button merchandiseButton = merchandise.GetComponent<Button>(); // ī�� ��ǰ ��ü�� ��ư ����
        merchandise.Init("���� ������", merchandiseImage); // ī�� ��ǰ �ʱ�ȭ
       // merchandiseButton.onClick.AddListener(() => merchandiseGameObject.gameObject.SetActive(true)); // Ŭ�� �� ī�� ��ǰ ȭ�� ǥ��
        merchandiseButton.onClick.AddListener(() => merchandiseScreen.gameObject.SetActive(false)); // ���� ȭ���� ��Ȱ��ȭ
        */
    }

    public void CloseMerchantUI()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.select_button);
        //�׳� �����ϰ� ���⿡ ���� �־ �˴ϴ�
        merchandiseScreen.gameObject.SetActive(false);
        UIManager.instance.UI_Map.gameObject.SetActive(true);
=======
    // ���� ��ǰ ǥ�� �Լ�
    public void EnterMerchantRoom()
    {
        cardMerchandiseParent.DestroyAllChild(); // ī�� ��ǰ �ʱ�ȭ

        inMerchandiseUI.gameObject.SetActive(true); // ���� UI ȭ�� Ȱ��ȭ

        GetCard(); // ī�� ��ǰ ����

        // ī�� ��ǰ ����
        cardMerchandise = Instantiate(merchandisePrefab, merchandiseParent); // ī�� ��ǰ ��ü ����
        Button cardMerchandiseButton = cardMerchandise.GetComponent<Button>(); // ī�� ��ǰ ��ü�� ��ư ����
        cardMerchandise.Init("���� ������", cardMerchandiseImage); // ī�� ��ǰ �ʱ�ȭ
        cardMerchandiseButton.onClick.AddListener(() => cardMerchandiseGameObject.gameObject.SetActive(true)); // Ŭ�� �� ī�� ��ǰ ȭ�� ǥ��
        cardMerchandiseButton.onClick.AddListener(() => merchandiseScreen.gameObject.SetActive(false)); // ���� ȭ���� ��Ȱ��ȭ

>>>>>>> Stashed changes
    }

    // 10���� ���� ī�带 �����ϴ� �Լ�
    private void GetCard()
<<<<<<< Updated upstream
    {
=======
    {          
>>>>>>> Stashed changes
        BaseCard card1 = CardGenerator.instance.CreateCardFromRandom(); // ù ��° ���� ī�� ����
        BaseCard card2 = CardGenerator.instance.CreateCardFromRandom(); // �� ��° ���� ī�� ����
        BaseCard card3 = CardGenerator.instance.CreateCardFromRandom(); // �� ��° ���� ī�� ����
        BaseCard card4 = CardGenerator.instance.CreateCardFromRandom();
<<<<<<< Updated upstream
        BaseCard card5 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card6 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card7 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card8 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card9 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card10 = CardGenerator.instance.CreateCardFromRandom();

        // ī�带 '�Ǹ� ����'�� ����
=======
        BaseCard card5 = CardGenerator.instance.CreateCardFromRandom(); 
        BaseCard card6 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card7 = CardGenerator.instance.CreateCardFromRandom(); 
        BaseCard card8 = CardGenerator.instance.CreateCardFromRandom(); 
        BaseCard card9 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card10 = CardGenerator.instance.CreateCardFromRandom(); 

        // ī�带 'ȹ�� ����'�� ����
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

        // �� ī���� Ŭ�� �׼� �ʱ�ȭ �� ��ǰ Ŭ�� �̺�Ʈ ����
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

        card1.onClickAction += (() => OnClickSellCard()); // Ŭ�� �� ī�� ȹ�� �̺�Ʈ ���
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

        card1.transform.SetParent(merchandiseParent); // ī�� �θ� ��ü�� ��ġ
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

        card1.transform.SetParent(cardMerchandiseParent); // ī�� �θ� ��ü�� ��ġ
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

        // ī���� ũ�� ����
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

    // ī�� ȹ�� ó��
    public void OnClickSellCard()
    {
<<<<<<< Updated upstream
        merchandiseGameObject.gameObject.SetActive(false); // ī�� ��ǰ UI ��Ȱ��ȭ
        merchandiseScreen.gameObject.SetActive(true); // ��ü ���� ȭ�� ��Ȱ��ȭ
        //Destroy(merchandise.gameObject); // ī�� ��ǰ ��ü ����//�̰� ��� �� �� ������
        //���ʿ� �߸��Ȱ� �����ϰ� �־, ī�� ������Ʈ�� �ƴ� �ٸ��� �����ϰ� �־ �ȵǴ� �� �����ϴ�.
    }
=======
        cardMerchandiseGameObject.gameObject.SetActive(false); // ī�� ��ǰ UI ��Ȱ��ȭ
        merchandiseScreen.gameObject.SetActive(true); // ��ü ���� ȭ�� ��Ȱ��ȭ
        Destroy(cardMerchandise.gameObject); // ī�� ��ǰ ��ü ����
    }

>>>>>>> Stashed changes
}
