using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadStats : MonoBehaviour {

    public Text results_text;
    private string text_to_print = "";
    public Print_Text pt;


    private void Start()
    {
        text_to_print = "Suspica Star Weekly Review: \n" +
            "Controversy : " + (DATA_User.t_controversy / 7 * 100).ToString("F2") + "%\n" +
            "Shock Value : " + (DATA_User.t_shock / 7 * 100).ToString("F2") + "%\n" +
            "Honesty : " + (DATA_User.t_truthfulness / 7 * 100).ToString("F2") + "%\n" +
            "Leaning - Swans : " + (DATA_User.t_swans / 7 * 100).ToString("F2") + "%\n" +
            "Leaning - Peacocks : " + (DATA_User.t_peacocks / 7 * 100).ToString("F2") + "%\n" +
            "Money : " + DATA_User.t_money + " out of " + Bar_Graph.max_cash+" possible dollars\n" +
            "Good job.";
        pt.SetText(text_to_print);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && pt.IsTextComplete())
            SceneManager.LoadScene("Title");
    }

}
