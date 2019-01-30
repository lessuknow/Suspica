using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Title : MonoBehaviour
{
    public Print_Text pt;
    public Print_Text tutorial_text;
    public Image fade_image;
    private float cur_fade = 0;
    private bool fading = false, tutorial = false;
    // Use this for initialization
    void Start()
    {
        Invoke("Intro", 0.65f);
    }

    private void Intro()
    {
        pt.SetText("Susipca");

    }

    private void FadeOut()
    {
        cur_fade += Time.deltaTime;

        Color newColor = new Color(0, 0, 0, Mathf.Lerp(0, 1, cur_fade / 3));
        fade_image.color = newColor;

        if (cur_fade > 3)
        {

            newColor = new Color(0, 0, 0, 0);
            pt.SetText("");
            tutorial_text.SetText("Make the best\nnewspaper by\npublishing the best\nstory each day.\nYou have seven days.\nGood luck.");
            fade_image.color = newColor;
            tutorial = true;
            fading = false;
        }
    }

    private void Update()
    {
        if(fading)
        {
            FadeOut();
        }
        else if(Input.GetMouseButtonDown(0))
        {
            if(tutorial)
            {
                SceneManager.LoadScene("Game");
            }
            else
            {
                fading = true;
            }
        }
    }

}

