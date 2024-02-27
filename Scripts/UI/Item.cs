using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    public Image itemImg;
    public TextMeshProUGUI itemName;

    public void SetItem(Sprite setSprite, string setText)
    {
        itemImg.sprite = setSprite;
        itemName.text = setText;
    }
}
