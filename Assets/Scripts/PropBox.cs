using UnityEngine;
using TMPro;

public class PropBox : MonoBehaviour
{
    [SerializeField] int propsNeeded;
    [SerializeField] TMP_Text boxText;
    [SerializeField] Color32 emptyColor;
    [SerializeField] Color32 fullColor;

    int propsInBox = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxText.color = emptyColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (EnablePassthrough.instance.passthroughOn) { SubtractFromBox(1); }
            else { AddToBox(1); } 
        }
    }

    public void AddToBox(int amount)
    {
        propsInBox++;
        boxText.text = propsInBox.ToString() + "/" + propsNeeded.ToString();
        if (propsInBox >= propsNeeded)
        {
            boxText.color = fullColor;
            EnablePassthrough.instance.Toggle();
        }
    }

    public void SubtractFromBox(int amount)
    {
        propsInBox--;
        boxText.text = propsInBox.ToString() + "/" + propsNeeded.ToString();
        if (propsInBox <= propsNeeded) { boxText.color = emptyColor; }
        if (EnablePassthrough.instance.passthroughOn && propsInBox == 0)
        {
            EnablePassthrough.instance.Toggle();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Prop"))
        {
            if (collision.gameObject.name == "Asteroid") { collision.gameObject.GetComponentInChildren<ParticleSystem>().Stop(); }
            AddToBox(1);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Asteroid") { collision.gameObject.GetComponentInChildren<ParticleSystem>().Play(); }
        SubtractFromBox(1);
    }
}
