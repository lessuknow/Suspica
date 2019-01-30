using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper_Data {

    public float controversy { get; private set; }
    public float truthfulness { get; private set; }
    public float shock_value { get; private set; }
    public float money { get; private set; }
    
    public float swans_relation { get; private set; }
    public float peacocks_relation { get; private set; }
    public List<string> notes { get; private set; }

    public string image;
    public string headline { get; private set; }

    public Newspaper_Data()
    {
        notes = new List<string>();
    }

    public void SetContents(Newspaper_Data d)
    {
        controversy = d.controversy;
        truthfulness = d.truthfulness;
        shock_value = d.shock_value;
        money = d.money;
        swans_relation = d.swans_relation;
        peacocks_relation = d.peacocks_relation;
        headline = d.headline;
        image = d.image;

    }

    //Sets the new paper data to these contents.
    public void SetContents(string _headline,
        float contro, float truth, float shock, float mon,
        float swans, float peacocks, string img)
    {
        controversy = contro;
        truthfulness = truth;
        shock_value = shock;
        money = mon;
        swans_relation = swans;
        peacocks_relation = peacocks;
        headline = _headline;
        image = img;
    }

    public void SetNotes(List<string> nt)
    {
        notes = nt;
    }


}
