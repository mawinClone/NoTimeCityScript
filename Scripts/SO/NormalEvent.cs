using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Event", menuName = "Normal Event")]
public class NormalEvent : ScriptableObject
{
    public Sprite card;

    public int money;
    
    public bool canWalk;
    public bool canStudy;
    public bool canWork;
    
    
}
