using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerClickHandler
{
    public static CardController Instance;

    public List<Card> cardList; 
    public List<NormalEvent> eventList;
    public List<ActionCard> actionCardList;
    public List<WitchCard> witchCardList;
    public TextMeshProUGUI moneyText;

    [Header("Normal Card")]
    Image imgCard;
    public Animator animCard;
    // int cardOrder = 0 ;
    
    //Witch Card
    [Header("Witch Card")]
    public Image imgWitchCard;
    public Animator animWitchCard;
    
    //Action Card
    [Header("Action Card")]
    public Image imgActionCard;
    public Animator animActionCard;
    public ActionCardUI actionCardUI;

    //Action Card in Inventory
    [Header("Action Card Inventory")]
    public Image imgActionCardInventory;
    public Animator animActionCardInventory;
    public ActionCardUI actionCardUIInventory;

    
    bool isSkip = false;
    public ActionCard currentActionCard;
    public WitchCard currentWitchCard;
    public bool haveWitchCard;


    private void Awake() {
        Instance = this;
    }
    
    void Start()
    {
        imgCard = GetComponent<Image>();
        // animCard = GetComponent<Animator>();
        moneyText.text = "0";
    }

    
    void Update()
    {
        if(Input.GetKeyDown("g"))
        {
            Debug.Log("test");
        }
    }



    public void RandomNFT()
    {
        int _order = 0;
        int cerCount = 0;
        if(GameController.Instance.playerNow.cerArt)
            cerCount++;
        if(GameController.Instance.playerNow.cerBank)
            cerCount++;
        if(GameController.Instance.playerNow.cerCamera)
            cerCount++;
        if(GameController.Instance.playerNow.cerGameCenter)
            cerCount++;
        

        if(cardList.Count > 0 )
        {
            _order = Random.Range(0, cardList.Count);
        }

        imgCard.sprite = cardList[_order].card;
        // moneyText.text = int.Parse(moneyText.text) + cardList[_order].money + "";

        GameController.Instance.playerNow.money = GameController.Instance.playerNow.money - 1000;

        if(cardList[_order].money>= 0)
            GameController.Instance.playerNow.money += (cardList[_order].money * cerCount);
        else GameController.Instance.playerNow.money += (cardList[_order].money );

        ShowCard();

        GameController.Instance.UpdateUI();
        isSkip = true;
        // GameController.Instance.Skip();

    }

    public void RandomNormalEvent()
    {
        int _order = 0;

        if(eventList.Count > 0 )
        {
            _order = Random.Range(0, eventList.Count);
        }

        // _order = 0;


        imgCard.sprite = eventList[_order].card;
        // moneyText.text = int.Parse(moneyText.text) + eventList[_order].money + "";

        GameController.Instance.playerNow.money += eventList[_order].money;
        GameController.Instance.canWalk = eventList[_order].canWalk;
        GameController.Instance.canStudy = eventList[_order].canStudy;
        GameController.Instance.canWork = eventList[_order].canWork;

        ShowCard();

        GameController.Instance.UpdateUI();

        if(eventList[_order].canWalk == false)
        {
            // GameController.Instance.Skip();
            isSkip = true;
        }
    }

    public void FinalCalCard()
    {
        GameController.Instance.isNormal = false;
        if(isSkip)
        {
            GameController.Instance.Skip();
            isSkip = false;
        }
    }

    public void ShowCard()
    {

        animCard.SetTrigger("CardShow");

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int _random;

        animCard.SetTrigger("ClickClose");
        if(haveWitchCard)
            StartCoroutine(OpenWitchCard());
        else if(GameController.Instance.playerNow.haveArtItem || GameController.Instance.playerNow.haveBankItem || GameController.Instance.playerNow.haveCameraItem || GameController.Instance.playerNow.haveGameItem)
        {
            
            _random = Random.Range(0, 100);
            if(_random > 0) // for test
            {
                RandomActionCard();
            }
        }else{
            FinalCalCard();
        }
        
    }

    public void CheckWitchCard()
    {
        int _random;
        if(haveWitchCard)
            StartCoroutine(OpenWitchCard());
        else{
            if(GameController.Instance.round % 2 == 0 && GameController.Instance.round < GameController.Instance.roundPerGame)
            {
                _random = Random.Range(0, 100);
                if(_random > 0) // for test
                {
                    if(GameController.Instance.isNormal == false)
                    {
                        if(GameController.Instance.playerNow.haveArtItem || GameController.Instance.playerNow.haveBankItem || GameController.Instance.playerNow.haveCameraItem || GameController.Instance.playerNow.haveGameItem)
                            CardController.Instance.RandomActionCard();
                    }
                    
                }
            }

            FinalCalCard();
        }
    }

    public void SetWitchCard(int set)
    {
        currentWitchCard = witchCardList[set];
        haveWitchCard = true;
    }
    public void WitchCardSelected(WitchCard setWitchCard)
    {
        haveWitchCard = true;
        currentWitchCard = setWitchCard;
    }

    IEnumerator OpenWitchCard() // set data witch card and clear witch card
    {
        
        
        yield return new WaitForSeconds(1f);

        imgWitchCard.sprite = currentWitchCard.card;

        GameController.Instance.canWalk = currentWitchCard.canWalk;
        GameController.Instance.canStudy = currentWitchCard.canStudy;
        GameController.Instance.canWork = currentWitchCard.canWork;

        if(currentWitchCard.canWalk == false)
        {
            isSkip = true;
        }

        if(currentWitchCard.stealMoney == true)
        {
            //steal money;
            int sum;
            int _randomMoney = Random.Range(7000, 13000);

            if(GameController.Instance.isPlayerOne)
            {
                
                
                if(GameController.Instance.playerNow.money<= _randomMoney)
                {
                    GameController.Instance.playerTwo.money += GameController.Instance.playerNow.money;
                }else{
                    GameController.Instance.playerTwo.money += _randomMoney;
                }
                
                if(GameController.Instance.playerTwo.money <= 0)
                {
                    GameController.Instance.playerTwo.money = 0;
                }

                GameController.Instance.playerNow.money -= _randomMoney;
            }else{
                
                if(GameController.Instance.playerNow.money<= _randomMoney)
                {
                    GameController.Instance.playerOne.money += GameController.Instance.playerNow.money;
                }else{
                    GameController.Instance.playerOne.money += _randomMoney;
                }

                if(GameController.Instance.playerOne.money <= 0)
                {
                    GameController.Instance.playerOne.money = 0;
                }
                GameController.Instance.playerNow.money -= _randomMoney;
            }

            if(GameController.Instance.playerNow.money <= 0)
            {
                GameController.Instance.playerNow.money = 0;
            }
        }
        

        animWitchCard.SetTrigger("CardShow");
        currentWitchCard = null;
        haveWitchCard = false;

        GameController.Instance.UpdateUI();
        
    }

    public void WitchCardDone()
    {
        int _random;
        if(GameController.Instance.round % 2 == 0 && GameController.Instance.round < GameController.Instance.roundPerGame)
        {
            if(GameController.Instance.playerNow.haveArtItem || GameController.Instance.playerNow.haveBankItem || GameController.Instance.playerNow.haveCameraItem || GameController.Instance.playerNow.haveGameItem)
            {
            
                _random = Random.Range(0, 100);
                if(_random > 0) // for test
                {
                    RandomActionCard();
            }
            }else{
                FinalCalCard();
            }
        }
        else
        {
            FinalCalCard();
        }

        
    }

    
    public void RandomActionCard()
    {
        StartCoroutine(RandomActionCardCouroutine());
    }

    IEnumerator RandomActionCardCouroutine()
    {
        
        yield return new WaitForSeconds(1f);
        
        int _order = 0;
        actionCardUI.isResult = false;
        if(actionCardList.Count > 0 )
        {
            _order = Random.Range(0, actionCardList.Count);


            // GameController.Instance.playerNow.actionCard.Add(actionCardList[_order]);
            currentActionCard = actionCardList[_order];
            imgActionCard.sprite = actionCardList[_order].questionCard;
            animActionCard.SetTrigger("CardShow");

            actionCardUI.ShowButton();

        }

        

    }


    public void SelectActionCard(ActionCard setActionCard)
    {
        actionCardUI.isResult = false; 
        currentActionCard = setActionCard;
        imgActionCard.sprite = currentActionCard.questionCard;

        animActionCard.SetTrigger("CardShow");

    }
    public void UseActionCard()
    {
        actionCardUI.isResult = true; 
        imgActionCard.sprite = currentActionCard.resultCard;
        GameController.Instance.playerNow.money += currentActionCard.money; 
        
        
        
        int i = 0;
        foreach(ActionCard _card in GameController.Instance.playerNow.actionCard) //delete from inventory 
        {
            if(_card.id == currentActionCard.id)
            {
                GameController.Instance.playerNow.actionCard.RemoveAt(i);
                break;
            }
            i++;
        }

        if(GameController.Instance.playerNow.haveArtItem)
        {
            GameController.Instance.playerNow.haveArtItem = false;
            GameController.Instance.playerNow.money += GameController.Instance.itemPrice.artLowPrice; 
        }
        else if(GameController.Instance.playerNow.haveBankItem)
        {
            GameController.Instance.playerNow.haveBankItem = false;
            GameController.Instance.playerNow.money += GameController.Instance.itemPrice.bankLowPrice; 
        }
        else if(GameController.Instance.playerNow.haveCameraItem)
        {
            GameController.Instance.playerNow.haveCameraItem = false;
            GameController.Instance.playerNow.money += GameController.Instance.itemPrice.cameraLowPrice; 
        }
        else if(GameController.Instance.playerNow.haveGameItem)
        {
            GameController.Instance.playerNow.haveGameItem = false;
            GameController.Instance.playerNow.money += GameController.Instance.itemPrice.gameLowPrice; 
        }
        

        if(GameController.Instance.playerNow.money <=0)
        {
            GameController.Instance.playerNow.money = 0;
        }
        GameController.Instance.UpdateUI();
    }



    //ActionCardInventory
    public void SelectActionCardInvenroty(ActionCard setActionCard)
    {
        actionCardUIInventory.isResult = false; 
        actionCardUIInventory.ShowButton();
        currentActionCard = setActionCard;
        imgActionCardInventory.sprite = currentActionCard.questionCard;

        animActionCardInventory.SetTrigger("CardShow");

    }
    public void UseActionCardInventory()
    {
        actionCardUIInventory.isResult = true; 
        imgActionCardInventory.sprite = currentActionCard.resultCard;
        GameController.Instance.playerNow.money += currentActionCard.money; 
        
        
        
        int i = 0;
        foreach(ActionCard _card in GameController.Instance.playerNow.actionCard) //delete from inventory 
        {
            if(_card.id == currentActionCard.id)
            {
                GameController.Instance.playerNow.actionCard.RemoveAt(i);
                break;
            }
            i++;
        }

        if(GameController.Instance.playerNow.haveArtItem)
        {
            GameController.Instance.playerNow.haveArtItem = false;
            GameController.Instance.playerNow.money += GameController.Instance.itemPrice.artLowPrice; 
        }
        else if(GameController.Instance.playerNow.haveBankItem)
        {
            GameController.Instance.playerNow.haveBankItem = false;
            GameController.Instance.playerNow.money += GameController.Instance.itemPrice.bankLowPrice; 
        }
        else if(GameController.Instance.playerNow.haveCameraItem)
        {
            GameController.Instance.playerNow.haveCameraItem = false;
            GameController.Instance.playerNow.money += GameController.Instance.itemPrice.cameraLowPrice; 
        }
        else if(GameController.Instance.playerNow.haveGameItem)
        {
            GameController.Instance.playerNow.haveGameItem = false;
            GameController.Instance.playerNow.money += GameController.Instance.itemPrice.gameLowPrice; 
        }
        
        if(GameController.Instance.playerNow.money <=0)
        {
            GameController.Instance.playerNow.money = 0;
        }

        GameController.Instance.UpdateUI();
    }

    
    


}
