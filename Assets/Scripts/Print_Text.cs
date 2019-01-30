using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Print_Text : MonoBehaviour
{

    public Text textbox;
    public AudioSource single_key;
    public AudioSource new_line;
    bool text_complete = true;
    private string leftover_text = "";

    public bool IsTextComplete()
    {
        return text_complete;
    }

    private IEnumerator writeText()
    {
        char tmp = leftover_text[0];
        textbox.text += leftover_text[0];
        leftover_text = leftover_text.Substring(1);

        if(tmp == '\n')
        {
            new_line.Play();
            yield return new WaitForSeconds(0.6525f);
        }
        else
        {
            single_key.Play();
            yield return new WaitForSeconds(0.1225f);
        }
        if (leftover_text.Length > 0)
        {
            yield return writeText();
        }
        else
        {
            text_complete = true;
        }
    }

    public void SetText(string txt)
    {
        if (txt == "")
        { 
            textbox.text = "";
            return;
        }
        if (!text_complete)
        {
            StopCoroutine("writeText");
            textbox.text += leftover_text;
            leftover_text = "";
            text_complete = true;
        }
        else
        {
            leftover_text = txt;
            textbox.text = "";
            text_complete = false;
            StartCoroutine("writeText");
        }
    }

}
