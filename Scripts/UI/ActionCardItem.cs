using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionCardItem : MonoBehaviour
{
    public Image itemImg;
    public TextMeshProUGUI itemName;
    public ActionCard actionCardData;

    public void SetItem(Sprite setSprite, string setText,ActionCard setData)
    {
        itemImg.sprite = setSprite;
        itemName.text = setText;
        actionCardData = setData;
    }

    public void CardOnClick()
    {
        CardController.Instance.SelectActionCardInvenroty(actionCardData);
    }
}
