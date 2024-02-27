using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionCardUI : MonoBehaviour, IPointerClickHandler
{
    public Animator animActionCard;
    public bool isResult;

    public GameObject YesBtn;
    public GameObject NoBtn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void OnPointerClick(PointerEventData eventData)
    {
        if(isResult)
            animActionCard.SetTrigger("ClickClose");

        // call CardController.Instance
        CardController.Instance.FinalCalCard();
        GameController.Instance.UpdateUI();
    }
    public void VoteNo()
    {
        animActionCard.SetTrigger("ClickClose");

        YesBtn.SetActive(false);
        NoBtn.SetActive(false);
        CardController.Instance.FinalCalCard();
        GameController.Instance.UpdateUI();
    }
    public void VoteYes()
    {
        if(GameController.Instance.playerNow.haveArtItem || GameController.Instance.playerNow.haveBankItem || GameController.Instance.playerNow.haveCameraItem || GameController.Instance.playerNow.haveGameItem)
        {
            CardController.Instance.UseActionCard();
            isResult = true;

            YesBtn.SetActive(false);
            NoBtn.SetActive(false);  
        }
        
    }
    public void VoteYesFromInventory()
    {
        if(GameController.Instance.playerNow.haveArtItem || GameController.Instance.playerNow.haveBankItem || GameController.Instance.playerNow.haveCameraItem || GameController.Instance.playerNow.haveGameItem)
        {
            CardController.Instance.UseActionCardInventory();
            isResult = true;

            YesBtn.SetActive(false);
            NoBtn.SetActive(false);
        }
    }
    public void VoteNoFromInventory()
    {
        animActionCard.SetTrigger("ClickClose");

        YesBtn.SetActive(false);
        NoBtn.SetActive(false);
        GameController.Instance.UpdateUI();
    }

    public void ShowButton()
    {
        YesBtn.SetActive(true);
        NoBtn.SetActive(true);
    }
}
