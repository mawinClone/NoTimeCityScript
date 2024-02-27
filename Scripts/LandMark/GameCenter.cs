using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameCenter : MonoBehaviour
{
    

    private void OnMouseDown() {

        if(!EventSystem.current.IsPointerOverGameObject())
        {
            AudioController.Instance.ClickSound();
            if(GameController.Instance.canStudy && GameController.Instance.canWalk && GameController.Instance.playerNow.cerGameCenter == false && GameController.Instance.playerNow.money >= 1000)
            {
                GameController.Instance.playerNow.money = GameController.Instance.playerNow.money - 1000;
                GameController.Instance.UpdateUI();
                QuestController.Instance.SetQuesttion(QuestController.QuestSelected.GameQuest);
                // GameController.Instance.playerNow.cerGameCenter = true; 
                Debug.Log("ok");
            }else GameController.Instance.CantDo();
        }
        
    }
}
