using UnityEngine;

public class Lever : MonoBehaviour
{
    bool triggered = false;
    [SerializeField] GameObject[] disable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Top") 
        { 
            triggered = false;
            foreach (GameObject o in disable) { o.SetActive(true); }
        }
        if (other.tag == "Bot") 
        {
            triggered = true; 
            foreach (GameObject o in disable) { o.SetActive(false); }
        }
    }
}
