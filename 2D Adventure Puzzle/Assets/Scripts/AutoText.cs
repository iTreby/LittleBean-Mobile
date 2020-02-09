using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoText : MonoBehaviour {

    // Text output and display
    [Header("Text Input and Output")]
    public Text displayedText;
    public Text inputText;
    // Adjust text speed.
    [Header("Text Speed Adjustment")]
    public float textSpeed;

    // Text Gen Manager
    private string outputText = null;
    private int i = -1;
    internal bool finished;

 
 // Awake Function
    void Awake () {
      StartCoroutine("autoRepeat");
    }

    // Typing Gen circuit
    private string Textgen(string text)
    {
        // Typing Text function (Repeat)
        i++;
        char[] characters = text.ToCharArray();
        outputText = outputText + characters[i].ToString();

        // Checking for when text is finished.
        if (i == (characters.Length - 1))
        {
            finished = true;
        }

        return outputText;
    }
    // Text speed adjust
    IEnumerator autoRepeat()
    {
        while (true)
        {
            yield return new WaitForSeconds(textSpeed);

            if (!finished)
            {
                displayedText.text = Textgen(inputText.text);
            }
        }
        
    }

    void Update() {
      if (finished) {
        if(Input.GetKeyDown(KeyCode.C) || Input.GetKeyUp(KeyCode.JoystickButton1) || Input.touchCount > 0) {
          gameObject.SetActive(false);
        }
      }
    }
}﻿