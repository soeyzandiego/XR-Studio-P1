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
            GameObject newProp = Instantiate(prop, transform);
            Vector3 newPos = new Vector3(Random.Range(-1, 1), Random.Range(-0.5f, 0.5f), Random.Range(-2, 2));
            newProp.transform.localPosition = newPos;
            float scale = Random.Range(0.25f, 0.55f);
            newProp.transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    public void InitBox(State boxState)
    {
        state = boxState;
    }

    void Position()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 eulers = transform.eulerAngles;
        transform.LookAt(-player.GetComponent<OVRCameraRig>().centerEyeAnchor.forward);
        transform.eulerAngles = new Vector3(eulers.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
        Vector3 forwardOffset = player.GetComponent<OVRCameraRig>().centerEyeAnchor.forward;
        Vector3 newPos = player.position + forwardOffset;
        transform.position = newPos;
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
