using UnityEngine;
using System.Collections;
using TMPro;

public class IntroScene : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float typeSpeed = 0.2f;

    [SerializeField] TMP_Text textObject;
    string cutText;
    string cleanText = "Alright, let's clean the set.";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Cut());
        cutText = textObject.text;
        textObject.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Cut()
    {
        yield return new WaitForSecondsRealtime(5);
        for (int i = 0; i < cutText.Length; i++)
        {
            textObject.text += cutText[i];
            yield return new WaitForSeconds(typeSpeed);
        }
        yield return new WaitForSecondsRealtime(1);

        textObject.text = "";
        cam.clearFlags = CameraClearFlags.Color;

        yield return new WaitForSecondsRealtime(1);
        for (int i = 0; i < cleanText.Length; i++)
        {
            textObject.text += cleanText[i];
            yield return new WaitForSeconds(typeSpeed);
        }
        yield return new WaitForSecondsRealtime(1);
        textObject.text = "";
    }

}
