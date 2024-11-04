using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class BaseCardDiscardState : BaseCardState
{
    public BaseCardDiscardState(BaseCard baseCard, BaseCardStateFactory stateFactory) : base(baseCard, stateFactory)
    {
        cardUsage = ECardUsage.DisCard;
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

        // UI 이미지의 월드 좌표를 스크린 좌표로 변환
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(null, _baseCard.GetComponent<RectTransform>().position);

        // 스크린 좌표를 캔버스 좌표로 변환
        Vector2 anchoredPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(UIManager.instance.GetComponent<RectTransform>(), screenPoint, null, out anchoredPosition);

        anchoredPosition.y += 200;

        // InformationView의 anchoredPosition을 설정 (로컬 좌표계에서)
        RectTransform rectTransform = UIManager.instance.CardInfo.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;

        // 정보창 활성화

        LayoutRebuilder.ForceRebuildLayoutImmediate(UIManager.instance.CardInfo.GetComponent<RectTransform>());

        UIManager.instance.CardInfo.SetActive(true);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        UIManager.instance.CardInfo.SetActive(false);  // 정보창 비활성화
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        
        //AudioManager.instance.PlaySfx(AudioManager.Sfx.buy_item);
        
        if(Player.instance.PlayerDeck.Count > 10)
        {
            _baseCard.onClickAction?.Invoke();
            Player.instance.RemoveCard(_baseCard);
            UIManager.instance.CardInfo.SetActive(false);
            _baseCard.CardDisappear();
        }
    }
}
