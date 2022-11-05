using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClicker : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] private MenuController mc;

    Animator anim;

    bool downInButton;

    public void Start()
    {
        downInButton = false;
        anim = GetComponent<Animator>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        downInButton = true; 
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (downInButton)
        {
            mc.PerformAction(this.gameObject.name);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetBool("hovering", false);
        downInButton = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetBool("hovering", true);
    }
}
