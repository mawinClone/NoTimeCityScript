using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MiniGame : MonoBehaviour
{
    public GameObject MiniGamePanel;

    private void OnMouseDown() {

        if(!EventSystem.current.IsPointerOverGameObject())
        {
            AudioController.Instance.ClickSound();
            if(GameController.Instance.canWalk)
            {
                MiniGamePanel.SetActive(true);
            }else GameController.Instance.CantDo();
        }
        
    }

    public void WitchCardSelected(int set)
    {
        //if(money > witchcardPrice) ตัดเงินด้วย
        if(set == 0)
        {
            if(GameController.Instance.playerNow.money >= 5000)
            {
                AudioController.Instance.ShopSound();
                GameController.Instance.playerNow.money -= 5000;
                CardController.Instance.SetWitchCard(set);
                GameController.Instance.UpdateUI();
            }else AudioController.Instance.WrongSound();
        }
        else if(set == 1)
        {
            if(GameController.Instance.playerNow.money >= 8000)
            {
                AudioController.Instance.ShopSound();
                GameController.Instance.playerNow.money -= 8000;
                CardController.Instance.SetWitchCard(set);
                GameController.Instance.UpdateUI();
            }else AudioController.Instance.WrongSound();
        }
        else if(set == 2)
        {
            if(GameController.Instance.playerNow.money >= 10000)
            {
                AudioController.Instance.ShopSound();
                GameController.Instance.playerNow.money -= 10000;
                CardController.Instance.SetWitchCard(set);
                GameController.Instance.UpdateUI();
            }else AudioController.Instance.WrongSound();
        }
        
        

    }
}
