using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NFTCity : MonoBehaviour
{

    public GameObject StorePanel;

    private void OnMouseDown() {
        // CardController.Instance.ShowCard();
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            AudioController.Instance.ClickSound();
            if(GameController.Instance.canWalk)
            {
                // if(GameController.Instance.playerNow.money >= 1000)
                // {
                    if(GameController.Instance.playerNow.cerArt || GameController.Instance.playerNow.cerBank ||GameController.Instance.playerNow.cerCamera ||GameController.Instance.playerNow.cerGameCenter)
                    {
                        Debug.Log("ok");
                        // CardController.Instance.RandomNFT();
                        StorePanel.SetActive(true);
                    }else{
                        GameController.Instance.CantDo();
                    }
                // }
                // else{
                //         GameController.Instance.CantDo();
                // }
                
            }else GameController.Instance.CantDo();
        }
    }

    public void BuyCamera()
    {
        if(GameController.Instance.playerNow.cerCamera)
        {
            if(!GameController.Instance.playerNow.haveCameraItem)
            {
                if(GameController.Instance.playerNow.money > GameController.Instance.itemPrice.cameraMaxPrice)
                {
                    AudioController.Instance.ShopSound();
                    GameController.Instance.playerNow.haveCameraItem = true;
                    GameController.Instance.playerNow.money -= GameController.Instance.itemPrice.cameraMaxPrice;
                }else AudioController.Instance.WrongSound();
            }else AudioController.Instance.WrongSound();
        }else AudioController.Instance.WrongSound();
        GameController.Instance.UpdateUI();
    }
    public void SoldCamera()
    {
        if(GameController.Instance.playerNow.cerCamera)
        {
            if(GameController.Instance.playerNow.haveCameraItem)
            {
                AudioController.Instance.ShopSound();
                GameController.Instance.playerNow.haveCameraItem = false;
                GameController.Instance.playerNow.money += GameController.Instance.itemPrice.cameraLowPrice;
            }else AudioController.Instance.WrongSound();
        }else AudioController.Instance.WrongSound();

        GameController.Instance.UpdateUI();
        
    }

    public void BuyBank()
    {
        if(GameController.Instance.playerNow.cerBank)
        {
            if(!GameController.Instance.playerNow.haveBankItem)
            {
                if(GameController.Instance.playerNow.money > GameController.Instance.itemPrice.bankMaxPrice)
                {
                    AudioController.Instance.ShopSound();
                    GameController.Instance.playerNow.haveBankItem = true;
                    GameController.Instance.playerNow.money -= GameController.Instance.itemPrice.bankMaxPrice;
                }else AudioController.Instance.WrongSound();
            }else AudioController.Instance.WrongSound();
        }else AudioController.Instance.WrongSound();
        GameController.Instance.UpdateUI();
    }
    public void SoldBank()
    {
        if(GameController.Instance.playerNow.cerBank)
        {
            if(GameController.Instance.playerNow.haveBankItem)
            {
                AudioController.Instance.ShopSound();
                GameController.Instance.playerNow.haveBankItem = false;
                GameController.Instance.playerNow.money += GameController.Instance.itemPrice.bankLowPrice;
            }else AudioController.Instance.WrongSound();
        }else AudioController.Instance.WrongSound();
        GameController.Instance.UpdateUI();
    }

    public void BuyArt()
    {
        if(GameController.Instance.playerNow.cerArt)
        {
            if(!GameController.Instance.playerNow.haveArtItem)
            {
                if(GameController.Instance.playerNow.money > GameController.Instance.itemPrice.artMaxPrice)
                {
                    AudioController.Instance.ShopSound();
                    GameController.Instance.playerNow.haveArtItem = true;
                    GameController.Instance.playerNow.money -= GameController.Instance.itemPrice.artMaxPrice;
                }else AudioController.Instance.WrongSound();
            }else AudioController.Instance.WrongSound();
        }else AudioController.Instance.WrongSound();
        GameController.Instance.UpdateUI();

    }
    public void SoldArt()
    {
        if(GameController.Instance.playerNow.cerArt)
        {
            if(GameController.Instance.playerNow.haveArtItem)
            {
                AudioController.Instance.ShopSound();
                GameController.Instance.playerNow.haveArtItem = false;
                GameController.Instance.playerNow.money += GameController.Instance.itemPrice.artLowPrice;
            }else AudioController.Instance.WrongSound();
        }else AudioController.Instance.WrongSound();

        GameController.Instance.UpdateUI();
    }

    public void BuyGame()
    {
        if(GameController.Instance.playerNow.cerGameCenter)
        {
            if(!GameController.Instance.playerNow.haveGameItem)
            {
                if(GameController.Instance.playerNow.money > GameController.Instance.itemPrice.gameMaxPrice)
                {
                    AudioController.Instance.ShopSound();
                    GameController.Instance.playerNow.haveGameItem = true;
                    GameController.Instance.playerNow.money -= GameController.Instance.itemPrice.gameMaxPrice;
                }else AudioController.Instance.WrongSound();
            }else AudioController.Instance.WrongSound();
        }else AudioController.Instance.WrongSound();

        GameController.Instance.UpdateUI();
    }
    public void SoldGame()
    {
        if(GameController.Instance.playerNow.cerGameCenter)
        {
            if(GameController.Instance.playerNow.haveGameItem)
            {
                AudioController.Instance.ShopSound();
                GameController.Instance.playerNow.haveGameItem = false;
                GameController.Instance.playerNow.money += GameController.Instance.itemPrice.gameLowPrice;
            }else AudioController.Instance.WrongSound();
        }else AudioController.Instance.WrongSound();

        GameController.Instance.UpdateUI();

    }


}