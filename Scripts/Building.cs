using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour
{
    SpriteRenderer sp;

    private void Start() {
        sp = GetComponent<SpriteRenderer>();
    }


    void OnMouseOver()
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
        sp.enabled = true;
        }
        
    }

    void OnMouseExit()
    {
        sp.enabled = false;
    }

    
}
