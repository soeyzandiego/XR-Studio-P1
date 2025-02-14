using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Oculus.Interaction;

public class PropBox : MonoBehaviour
{
    [SerializeField] int propsNeeded;
    [SerializeField] TMP_Text boxText;
    [SerializeField] Color32 emptyColor;
    [SerializeField] Color32 fullColor;

    int propsInBox = 0;
    List<GameObject> props = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxText.color = emptyColor;
        boxText.text = propsInBox.ToString() + "/" + propsNeeded.ToString();
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
        if (propsInBox >= propsNeeded && EnablePassthrough.instance.passthroughOn) { return; }
        propsInBox++;
        boxText.text = propsInBox.ToString() + "/" + propsNeeded.ToString();
        if (propsInBox >= propsNeeded)
        {
            boxText.color = fullColor;
            EnablePassthrough.instance.Toggle();
            this.enabled = false;
            //foreach (GameObject prop in props)
            //{
            //    prop.GetComponent<Rigidbody>().isKinematic = false;
            //    prop.GetComponent<Rigidbody>().useGravity = true;
            //}
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Prop"))
        {
            Debug.Log("prop in box");
            AddToBox(1);
            props.Add(other.gameObject);
            other.GetComponent<Rigidbody>().isKinematic = false;
            other.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (EnablePassthrough.instance.passthroughOn) { return; }
        if (other.CompareTag("Prop") && propsInBox > 0)
        {
            SubtractFromBox(1);
            props.Remove(other.gameObject);
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
