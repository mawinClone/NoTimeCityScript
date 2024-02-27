using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Work : MonoBehaviour
{
    public int salary;
    

    private void OnMouseDown() {

        if(!EventSystem.current.IsPointerOverGameObject())
        {
            
            if(GameController.Instance.canWork && GameController.Instance.canWalk)
            {
                AudioController.Instance.ShopSound();
                GameController.Instance.playerNow.money += salary;
                GameController.Instance.UpdateUI();
                GameController.Instance.EndTurn();
                Debug.Log("ok");

            }else{
                AudioController.Instance.ClickSound();
                GameController.Instance.CantDo();
            } 
        }
        
    }
}
