using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageClick : MonoBehaviour, IPointerClickHandler
{
    Animator anim;
    bool isFirstClick = false;

    private void Start() 
    {
        anim = GetComponent<Animator>();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        anim.SetTrigger("TutorialClose");
    }
}