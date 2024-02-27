using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "New Player", menuName = "Player")]
public class Player : ScriptableObject
{

    public int money;
    
    public bool cerArt;
    public bool cerBank;
    public bool cerCamera;
    public bool cerGameCenter;

    [Space(10)]
    [Header("NFT Item")]
    public bool haveArtItem;
    public bool haveBankItem;
    public bool haveCameraItem;
    public bool haveGameItem;

    public List<ActionCard> actionCard;
    public List<WitchCard> witchCard;





    
}
