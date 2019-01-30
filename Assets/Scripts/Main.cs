using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{

    public GameObject paper_l, paper_r, paper_c;
    public Move_Image bg;
    public Mouse_Over button;
    enum selected { swan, pea, none };
    private selected chosen_paper;
    private bool on_selection = true;
    private bool on_results = false;
    public Bar_Graph bar_g;
    public Image fade_image;
    public AudioSource stamp, paper_shuffle, paper_slide;
    public GameObject promo_swans, promo_peacocks;

    //Total amount of days in the game. Divide all stats by this.
    private const int total_days = 7;
    private int current_day = 0;
    private Newspaper_Data chosen_results;
    private List<Newspaper_Data> poss_results;
    private float cur_fade = 0;
    private Color fade_out = new Color(0, 0, 0, 255);
    private bool fading = false;

    private void Start()
    {
        paper_l.GetComponent<Move_Image>().MoveImg();
        paper_r.GetComponent<Move_Image>().MoveImg();
        chosen_paper = selected.none;
        poss_results = DATA_Newspaper.SetPapers(paper_l.GetComponent<Newspaper_Handler>(), 
            paper_r.GetComponent<Newspaper_Handler>(), current_day + 1);



    }

    private void FadeOut()
    {
        cur_fade += Time.deltaTime;
        
        Color newColor = new Color(0, 0, 0, Mathf.Lerp(0, 1, cur_fade/3));
        fade_image.color = newColor;

        if (cur_fade>3)
        {
            SceneManager.LoadScene("Ending");
        }
    }

    private void EndDay()
    {
        current_day++;
        bar_g.UpdateGraph(current_day, DATA_User.t_money);
        poss_results = DATA_Newspaper.SetPapers(paper_l.GetComponent<Newspaper_Handler>(),
            paper_r.GetComponent<Newspaper_Handler>(), current_day + 1);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        { 
        fading = true;
        fade_image.gameObject.SetActive(true);
        }
        if (fading)
        {
            FadeOut();
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!on_selection)
                {
                    if (current_day >= 7)
                    {
                        fading = true;
                        fade_image.gameObject.SetActive(true);
                    }
                    else
                    {   
                        Transition();
                    }
                }
                if (!on_results)
                {
                    if (button.mouse_over && chosen_paper != selected.none)
                    {
                        stamp.Play();
                        ShowResults();

                    }
                    else if (paper_l.GetComponent<Newspaper_Handler>().mouse_over)
                    {
                        paper_shuffle.Play();
                        paper_l.GetComponent<Move_Image>().IsSelected(true);
                        paper_r.GetComponent<Move_Image>().IsSelected(false);
                        chosen_paper = selected.swan;
                    }
                    else if (paper_r.GetComponent<Newspaper_Handler>().mouse_over)
                    {
                        paper_shuffle.Play();
                        chosen_paper = selected.pea;
                        paper_r.GetComponent<Move_Image>().IsSelected(true);
                        paper_l.GetComponent<Move_Image>().IsSelected(false);
                    }
                }
                else
                {
                    Transition();
                    EndDay();
                }
            }
        }
    }

    //Disable the other options and show the results.
    private void ShowResults()
    {
        paper_l.GetComponent<Move_Image>().MoveImg();
        paper_r.GetComponent<Move_Image>().MoveImg();
        paper_slide.Play();
        paper_c.GetComponent<Move_Image>().MoveImg();

        //ASSUMES LEFT IS ALWAYS SWANS RIGHT IS ALWAYS PEACOCKS.
        if (chosen_paper == selected.swan)
        {
            paper_c.GetComponent<Newspaper_Handler>().UpdatePaper(poss_results[0]);
        }
        else
            paper_c.GetComponent<Newspaper_Handler>().UpdatePaper(poss_results[1]);

        paper_c.GetComponent<Newspaper_Handler>().ApplyUpdateToObject();

        on_results = true;

    }

    //Transition between the bottom and top screen; if we're going from bottom -> top we add totals.
    private void Transition()
    {
        if(on_selection)
        { 
            switch (chosen_paper)
            {
                case selected.swan:
                    AddTotals(paper_l.GetComponent<Newspaper_Handler>().contents);
                    break;
                case selected.pea:
                    AddTotals(paper_r.GetComponent<Newspaper_Handler>().contents);
                    break;
                //If you didn't select any of the papers, just don't do anything for now.
                case selected.none:
                    return;
            }
            paper_c.GetComponent<Move_Image>().MoveImg();
            paper_slide.Play();
        }
        else
        {
            if (DATA_User.t_peacocks / 7 > 0.66f)
                promo_peacocks.SetActive(true);

            if (DATA_User.t_swans / 7 > 0.66f)
                promo_swans.SetActive(true);

            
            paper_c.GetComponent<Move_Image>().Refresh();
            paper_l.GetComponent<Move_Image>().Refresh();
            paper_l.GetComponent<Move_Image>().MoveImg();
            paper_r.GetComponent<Move_Image>().Refresh();
            paper_r.GetComponent<Move_Image>().MoveImg();

        }

        on_selection = !on_selection;
        on_results = false;

        chosen_paper = selected.none;
        bg.MoveImg();
    }

    //Add each of the values in the paper to the aggregates.
    private void AddTotals(Newspaper_Data data)
    {
        DATA_User.t_controversy = (DATA_User.t_controversy + data.controversy);
        DATA_User.t_money = (DATA_User.t_money + data.money);
        DATA_User.t_peacocks = (DATA_User.t_peacocks + data.peacocks_relation);
        DATA_User.t_swans = (DATA_User.t_swans + data.swans_relation);
        DATA_User.t_truthfulness = (DATA_User.t_truthfulness + data.truthfulness);
        DATA_User.t_shock = (DATA_User.t_shock + data.shock_value);
    }
}