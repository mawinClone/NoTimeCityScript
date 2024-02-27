using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New ActionCard", menuName = "Action Card")]
public class ActionCard : ScriptableObject
{
    public string id;
    public Sprite questionCard;
    public Sprite resultCard;
    public int money;
    
}
