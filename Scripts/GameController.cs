using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public Player playerNow;
    public Player playerOne;
    public Player playerTwo;

    public StoreItem itemPrice;

    [Space(50)]
    [Header("Inventory")]
    public Transform inventoryPanelPos;
    public List<GameObject> inventoryList;
    public GameObject itemPrefab;
    public GameObject actionCardPrefab;

    public bool canWalk;
    public bool canStudy;
    public bool canWork;

    public bool isPlayerOne = true;

    public int round = 1;
    public int roundPerGame;
    [Space(50)]
    [Header("Color")]
    public Camera cam;
    public Color colorPlayer1;
    public Color colorPlayer2;

    public Image playerTurnImg;
    public Sprite playerturn01sprite;
    public Sprite playerturn02sprite;

    [Space(50)]
    public TextMeshProUGUI playerTurnText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI roundText;

    [Space(50)]
    public Animator endTurnAnim;
    public Animator cantAnim;
    public GameObject endGamePanel;
    public TextMeshProUGUI endGameText;

    [Space(50)]
    [Header("StoreItemText")]
    public TextMeshProUGUI cameraMaxPriceText;
    public TextMeshProUGUI cameraLowPriceText;

    public TextMeshProUGUI artMaxPriceText;
    public TextMeshProUGUI artLowPriceText;

    public TextMeshProUGUI bankMaxPriceText;
    public TextMeshProUGUI bankLowPriceText;

    public TextMeshProUGUI gameMaxPriceText;
    public TextMeshProUGUI gameLowPriceText;

    public bool isNormal;
    




    private void Awake() {
        Instance = this;
    }

    void Start()
    {
        ResetPlayerSave();
        ResetNormalEvent();
        playerNow = playerOne;
        UpdateUI();
        RandomStoreItemPrice();
    }

    private void Update() {
        // if (Input.GetKeyDown(KeyCode.Return))
        // {
        //     EndTurn();
        // }
    }

    public void NextRound()
    {            
        int _random;
        isPlayerOne = !isPlayerOne;

        if(isPlayerOne)
        {
            round++;
            if(round > roundPerGame)
            {
                //end game
                EndGame();
                return ;
            }
                
        }

        if(isPlayerOne)
        {
            playerNow = playerOne;
        }else playerNow = playerTwo;

        UpdateUI();

        ResetNormalEvent();

        if(round % 2 == 0 && round < roundPerGame)
        {
            //random min max store item;
            RandomStoreItemPrice();
            _random = Random.Range(0, 100);
            Debug.Log("Random = " + _random);
            isNormal = true;
            if( _random > 50)
            {
                
                CardController.Instance.RandomNormalEvent();
            }
            else
            {
                CardController.Instance.CheckWitchCard();
            }
        }
        if(isNormal == false)
        CardController.Instance.CheckWitchCard();

        UpdateUI();
        
    }

    public void ActionCardPhase()
    {

    }

    public void WitchCardPhase() // if have from enemy
    {

    }

    public void RandomStoreItemPrice()
    {
        int _randomPrice;
        _randomPrice = Random.Range(1000, 15000);
        itemPrice.cameraMaxPrice = _randomPrice;
        itemPrice.cameraLowPrice = Random.Range(1000, (itemPrice.cameraMaxPrice - 1));

        _randomPrice = Random.Range(1000, 15000);
        itemPrice.artMaxPrice = _randomPrice;
        itemPrice.artLowPrice = Random.Range(1000, (itemPrice.artMaxPrice - 1));

        _randomPrice = Random.Range(1000, 15000);
        itemPrice.bankMaxPrice = _randomPrice;
        itemPrice.bankLowPrice = Random.Range(1000, (itemPrice.bankMaxPrice - 1));

        _randomPrice = Random.Range(1000, 15000);
        itemPrice.gameMaxPrice = _randomPrice;
        itemPrice.gameLowPrice = Random.Range(1000, (itemPrice.gameMaxPrice - 1));
        
        UpdateUI();

    }

    public void ResetPlayerSave()
    {
        playerOne.money = 0;
        playerOne.cerArt = false;
        playerOne.cerBank = false;
        playerOne.cerCamera = false;
        playerOne.cerGameCenter = false;

        playerOne.haveArtItem = false;
        playerOne.haveBankItem = false;
        playerOne.haveGameItem = false;
        playerOne.haveCameraItem = false;

        playerOne.actionCard.Clear();
        playerOne.witchCard.Clear();

        playerTwo.money = 0;
        playerTwo.cerArt = false;
        playerTwo.cerBank = false;
        playerTwo.cerCamera = false;
        playerTwo.cerGameCenter = false;

        playerTwo.haveArtItem = false;
        playerTwo.haveBankItem = false;
        playerTwo.haveGameItem = false;
        playerTwo.haveCameraItem = false;

        playerTwo.actionCard.Clear();
        playerTwo.witchCard.Clear();


    }
    public void ResetNormalEvent()
    {
        canWalk = true;
        canStudy = true;
        canWork = true;
    }

    public void SetNormalEvent(NormalEvent setEvent)
    {
        this.canWalk = setEvent.canWalk;
        this.canStudy = setEvent.canStudy;
        this.canWork = setEvent.canWork;

        // if(this.canWalk == false)
        // {
        //     StartCoroutine(SkipTurn());
        // }
    }

    public void Skip()
    {
        StartCoroutine(SkipTurn());
    }

    public IEnumerator SkipTurn()
    {
        //animation endturn
        
        yield return new WaitForSeconds(1f);
        endTurnAnim.SetTrigger("EndTurn");
        yield return new WaitForSeconds(1.5f);
        NextRound();
    }

    
    public void EndTurn()
    {
        StartCoroutine(WaitEndTurn());
    }

    public IEnumerator WaitEndTurn()
    {
        //animation endturn
        endTurnAnim.SetTrigger("EndTurn");
        yield return new WaitForSeconds(1.5f);
        NextRound();
    }

    public void CantDo()
    {
        cantAnim.SetTrigger("EndTurn");
    }


    public void UpdateUI()
    {
        roundText.text = "Round : " + round;
        moneyText.text = ""+ playerNow.money;
        if(isPlayerOne)
        {
            playerTurnText.text = "Player 1";
            cam.backgroundColor = colorPlayer1;
            playerTurnImg.sprite = playerturn01sprite;
            
        }
        else{
            playerTurnText.text = "Player 2";
            cam.backgroundColor = colorPlayer2;
            playerTurnImg.sprite = playerturn02sprite;
        } 


        //StoreItem
        cameraMaxPriceText.text = itemPrice.cameraMaxPrice +"";
        cameraLowPriceText.text = itemPrice.cameraLowPrice +"";

        artMaxPriceText.text = itemPrice.artMaxPrice +"";
        artLowPriceText.text = itemPrice.artLowPrice +"";

        bankMaxPriceText.text = itemPrice.bankMaxPrice +"";
        bankLowPriceText.text = itemPrice.bankLowPrice +"";

        gameMaxPriceText.text = itemPrice.gameMaxPrice +"";
        gameLowPriceText.text = itemPrice.gameLowPrice +"";
        InitInventory();
    }
    public void InitInventory()
    {
        ClearInventory();

        if(playerNow.cerArt)
            CreateItem(Resources.Load<Sprite>("UI/Certificate"),"ArtCertificate");
        if(playerNow.cerBank)
            CreateItem(Resources.Load<Sprite>("UI/Certificate"),"BankCertificate");
        if(playerNow.cerCamera)
            CreateItem(Resources.Load<Sprite>("UI/Certificate"),"CameraCertificate");
        if(playerNow.cerGameCenter)
            CreateItem(Resources.Load<Sprite>("UI/Certificate"),"GameCertificate");
        if(playerNow.haveArtItem)
            CreateItem(Resources.Load<Sprite>("UI/CryptoPunks"),"CryptoPunks");
        if(playerNow.haveBankItem)
            CreateItem(Resources.Load<Sprite>("UI/Unji Coin"),"Unji Coin");
        if(playerNow.haveCameraItem)
            CreateItem(Resources.Load<Sprite>("UI/Always Coca Cola"),"Always Coca Cola");
        if(playerNow.haveGameItem)
            CreateItem(Resources.Load<Sprite>("UI/Axie"),"Axie");

        for(int i = 0 ; i < playerNow.actionCard.Count ; i++)
        {
            CreateActionCard(playerNow.actionCard[i]);
        }
        

    }

    public void CreateItem(Sprite setSprite, string setText)
    {
        Item _item = itemPrefab.GetComponent<Item>();
        _item.SetItem(setSprite, setText);
        GameObject _itemObj = Instantiate(itemPrefab,inventoryPanelPos);
        inventoryList.Add(_itemObj);
    }

    public void CreateActionCard(ActionCard setCard)
    {
        ActionCardItem _item = actionCardPrefab.GetComponent<ActionCardItem>();
        _item.SetItem(setCard.questionCard, setCard.id, setCard);
        GameObject _itemObj = Instantiate(actionCardPrefab,inventoryPanelPos);
        inventoryList.Add(_itemObj);
    }


    public void ClearInventory()
    {
        foreach(GameObject _item in inventoryList)
        {
            Destroy(_item);
        }
        inventoryList.Clear();
    }

    public void EndGame()
    {
        if(playerOne.money > playerTwo.money)
        {
            endGameText.text = "Player1 WIN";
        } 
        else if(playerOne.money < playerTwo.money)
        {
            endGameText.text = "Player2 WIN";
        }
        else
        {
            endGameText.text = "DRAW";
        }

        endGamePanel.SetActive(true);
            
        
    }

}
