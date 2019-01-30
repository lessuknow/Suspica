using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Newspaper_Handler : Mouse_Over
{
    public Newspaper_Data contents;
    public Image img;
    public Text headline;
    public Text notes;
    public Sprite cobra, protester, army, birdhouse, gallery, migrate, seedkitchen;

    //Update the newspaper's contents, and then it's shown values.
    public void UpdatePaper(string _headline,
        float contro, float truth, float shock, float mon,
        float swans, float peacocks, string img, List<string> notes)
    {
        if(contents == null)
            contents = new Newspaper_Data();
        contents.SetContents(_headline,
            contro, truth, shock, mon,
            swans, peacocks, img);
        contents.SetNotes(notes);
    }

    public void UpdatePaper(Newspaper_Data d)
    {
        if (contents == null)
            contents = new Newspaper_Data();
        contents.SetContents(d);
    }

    public void ApplyUpdateToObject()
    {
        headline.text = contents.headline;

        switch (contents.image)
        {
            case "cobra":
                img.sprite = cobra;
                break;
            case "protestor":
                img.sprite = protester;
                break;
            case "army":
                img.sprite = army;
                break;
            case "birdhouse":
                img.sprite = birdhouse;
                break;
            case "gallery":
                img.sprite = gallery;
                break;
            case "migrate":
                img.sprite = migrate;
                break;

            case "seedkitchen":
                img.sprite = seedkitchen;
                break;


            default:
                print("ERROR HELP ME PLEASE");
                break;
        }
        notes.text = "";
        for(int i = 0;i < contents.notes.Count;i++)
        {
            notes.text += contents.notes[i];
            notes.text += "\n";
        }

    }

    
}
