using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public Sprite card;
    public int money;
}
