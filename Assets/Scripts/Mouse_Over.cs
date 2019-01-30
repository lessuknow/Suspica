using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Simple class that checks if the mouse is over this current object.
public class Mouse_Over : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public bool mouse_over { private set; get; }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
    }
}
