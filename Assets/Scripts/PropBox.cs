using UnityEngine;

public class PropBox : MonoBehaviour
{
    [SerializeField] int propsNeeded;

    int propsInBox = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToBox(int amount)
    {
        propsInBox++;
        if (propsInBox >= propsNeeded)
        {
            EnablePassthrough.instance.Toggle();
        }
    }

    public void SubtractFromBox(int amount)
    {
        propsInBox--;
        if (EnablePassthrough.instance.passthroughOn && propsInBox == 0)
        {
            EnablePassthrough.instance.Toggle();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Prop"))
        {
            AddToBox(1);
        }
    }
}
