using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class BaseCardSellState : BaseCardState
{
    public BaseCardSellState(BaseCard baseCard, BaseCardStateFactory stateFactory) : base(baseCard, stateFactory)
    {
        cardUsage = ECardUsage.Sell;
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
    }

    public override void OnDrag(PointerEventData eventData)
    {
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.instance.SetCarInfo(_baseCard.cardData);

        // UI �̹����� ���� ��ǥ�� ��ũ�� ��ǥ�� ��ȯ
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(null, _baseCard.GetComponent<RectTransform>().position);

        // ��ũ�� ��ǥ�� ĵ���� ��ǥ�� ��ȯ
        Vector2 anchoredPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(UIManager.instance.GetComponent<RectTransform>(), screenPoint, null, out anchoredPosition);

        anchoredPosition.y += 200;

        // InformationView�� anchoredPosition�� ���� (���� ��ǥ�迡��)
        RectTransform rectTransform = UIManager.instance.CardInfo.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;

        // ����â Ȱ��ȭ

        LayoutRebuilder.ForceRebuildLayoutImmediate(UIManager.instance.CardInfo.GetComponent<RectTransform>());

        UIManager.instance.CardInfo.SetActive(true);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        UIManager.instance.CardInfo.SetActive(false);  // ����â ��Ȱ��ȭ
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        _baseCard.onClickAction?.Invoke();
        if (Player.instance.PlayerState.Money > 50)
        {
            Player.instance.PlayerState.Money -= 50; // �÷��̾�� �� ����
            Player.instance.AddCard(_baseCard);
            UIManager.instance.CardInfo.SetActive(false);
        }
    }
}
