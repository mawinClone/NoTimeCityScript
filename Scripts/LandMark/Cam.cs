using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cam : MonoBehaviour
{
    

    private void OnMouseDown() {

        if(!EventSystem.current.IsPointerOverGameObject())
        {
            AudioController.Instance.ClickSound();
            if(GameController.Instance.canStudy && GameController.Instance.canWalk && GameController.Instance.playerNow.cerCamera == false && GameController.Instance.playerNow.money >= 1000)
            {
                GameController.Instance.playerNow.money = GameController.Instance.playerNow.money - 1000;
                GameController.Instance.UpdateUI();
                QuestController.Instance.SetQuesttion(QuestController.QuestSelected.CamQuest);
                // GameController.Instance.playerNow.cerCamera = true; 
                Debug.Log("ok");
            }else GameController.Instance.CantDo();

        }
        
    }
}
