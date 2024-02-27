using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New WitchCard", menuName = "Witch Card")]
public class WitchCard : ScriptableObject
{
    public string id;

    public Sprite card;
    
    public bool canWalk;
    public bool canStudy;
    public bool canWork;
    public bool stealMoney;
}
