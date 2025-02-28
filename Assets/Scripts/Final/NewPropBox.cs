using System.Collections.Generic;
using UnityEngine;

public class NewPropBox : MonoBehaviour
{
    public enum State { DECORATING, CLEANING_UP };
    public State state;

    int propsInBox;
    int propsTotal;

    List<GameObject> props = new List<GameObject>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitBox(PropSet set)
    {
        foreach (GameObject prop in set.props)
        {
            // spawn in box
        }
    }

    public void InitBox(State boxState)
    {
        state = boxState;
    }

    void SubtractFromBox(GameObject prop)
    {
        propsInBox--;
        props.Remove(prop);

        if (state == State.DECORATING)
        {
            if (propsInBox <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Prop") { return; }
        if (state == State.DECORATING)
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Prop") { return; }
        SubtractFromBox(other.gameObject);
    }
}
