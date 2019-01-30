using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Bar_Graph : MonoBehaviour {

    public Image [] bar;
    public const int max_height = 6;
    public const int max_cash = 6000;

    private void Start()
    {
        foreach (Image x in bar)
            x.transform.localScale = new Vector3(x.transform.localScale.x, 0);
    }

    public void UpdateGraph(int day, float cur_money)
    {
        //days start with 1, so we gotta subtract 1.
        
        bar[day - 1].transform.localScale = new Vector3(bar[day - 1].transform.localScale.x,
            (cur_money / max_cash) * max_height);

    }
}
