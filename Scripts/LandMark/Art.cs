using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Art : MonoBehaviour
{
    

    private void OnMouseDown() {




        if(!EventSystem.current.IsPointerOverGameObject())
        {
            AudioController.Instance.ClickSound();
            if(GameController.Instance.canStudy && GameController.Instance.canWalk && GameController.Instance.playerNow.cerArt == false && GameController.Instance.playerNow.money >= 1000)
            {
                GameController.Instance.playerNow.money = GameController.Instance.playerNow.money - 1000;
                GameController.Instance.UpdateUI();
                QuestController.Instance.SetQuesttion(QuestController.QuestSelected.ArtQuest);
                // GameController.Instance.playerNow.cerArt = true; 
                Debug.Log("ok");
            }else GameController.Instance.CantDo();
        }
        
    }
}
