using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WitchCardUI : MonoBehaviour, IPointerClickHandler
{
    public Animator animCard;

    public void OnPointerClick(PointerEventData eventData)
    {
        animCard.SetTrigger("ClickClose");

        // call CardController.Instance
        CardController.Instance.WitchCardDone();
    }
}
