using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoryText : MonoBehaviour
{

    public TextMeshProUGUI storyTxt;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DigitarTexto(storyTxt.text));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DigitarTexto(string texto)
    {
        storyTxt.text = "";
        int num = 0;

        foreach (char letra in texto)
        {
            storyTxt.text += letra;

            if (num <= 190)
            {
                yield return new WaitForSeconds(0.05f);
                Debug.Log("PRIMEIRO");
            }
            if (num >= 190)
            {
                yield return new WaitForSeconds(0.12f);
                Debug.Log("SEGUNDO");
            }
           
            num++;
        }
    }

}