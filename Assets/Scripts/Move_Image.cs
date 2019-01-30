using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move_Image : MonoBehaviour
{
    private Image img;
    public Vector2 endpos;
    public Vector3 endrotation;
    public Vector3 initrotation;
    public Vector2 initpos { private set; get; }
    public bool at_initpos { private set; get; }
    public bool at_initrotate { private set; get; }
    private bool moving;
    public bool selected = false;
    private bool rotate;
    public float lerp_fuzz = 0.15f;

    void Awake()
    {
        img = GetComponent<Image>();
        moving = false;
        at_initpos = true;
        initrotation = transform.rotation.eulerAngles;
        initpos = img.GetComponent<RectTransform>().anchoredPosition;
    }

    public void Refresh()
    {
        moving = false;
        at_initpos = true;
        if (selected)
            endpos.y -= 150f;
        selected = false;
        rotate = false;
        at_initrotate = false;
        transform.position = initpos;
        img.transform.eulerAngles = initrotation;
    }

    public void IsSelected(bool moveUp)
    {
        if(!selected && moveUp)
        {
            endpos.y += 150;
            selected = true;
        }
        else if(selected && !moveUp)
        {
            selected = false;
            endpos.y -= 150;
        }
        moving = true;
        at_initpos = true;
    }

    // Update is called once per frame
    void Update () {
        if(rotate)
        {
            if (!at_initrotate)
            {
                img.transform.eulerAngles =
                Vector3.Lerp(img.transform.eulerAngles,
                endrotation,
                Time.deltaTime * 1.5f);
                if (Vector3.Distance(img.transform.eulerAngles, endrotation) < 0.075f)
                {
                    rotate = false;
                    at_initrotate = true;
                    img.transform.eulerAngles = endrotation;
                }
            }
            else
            {
                img.transform.eulerAngles =
                Vector3.Lerp(img.transform.eulerAngles,
                initrotation,
                Time.deltaTime * 1.5f);
                if (Vector3.Distance(img.transform.eulerAngles, initrotation) < 0.075f)
                {
                    rotate = false;
                    at_initrotate = false;
                    img.transform.eulerAngles = initrotation;
                }
            }
        }
        if (moving)
        {
            if(at_initpos)
            { 
                img.GetComponent<RectTransform>().anchoredPosition =
                    Vector2.Lerp(img.GetComponent<RectTransform>().anchoredPosition,
                    endpos,
                    Time.deltaTime * 8.5f);
            }
            else
            {
                img.GetComponent<RectTransform>().anchoredPosition =
                    Vector2.Lerp(img.GetComponent<RectTransform>().anchoredPosition,
                    initpos,
                    Time.deltaTime * 8.5f);
            }
            if (Vector2.Distance(img.GetComponent<RectTransform>().anchoredPosition,endpos) < lerp_fuzz ||
                Vector2.Distance(img.GetComponent<RectTransform>().anchoredPosition,initpos) < lerp_fuzz)
            {
                moving = false;
                if (at_initpos)
                {
                    at_initpos = false;
                    img.GetComponent<RectTransform>().anchoredPosition = endpos;
                }
                else
                { 
                    at_initpos = true;
                    img.GetComponent<RectTransform>().anchoredPosition = initpos;
                }
                
            }
        }
    }
    
    public void MoveImg()
    {
        if (!moving)
        {
            moving = true;
            rotate = true;
        }
        else
        {
            at_initpos = !at_initpos;
            at_initrotate = !at_initrotate;
        }
    }
}
