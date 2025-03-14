using Newtonsoft.Json.Bson;
using UnityEngine;

public abstract class PokeButton : MonoBehaviour
{
    [SerializeField] AudioClip pressSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Press()
    {
        if (pressSound != null)
        {
            //AudioManager.instance.PlaySound(pressSound);
        }
        else
        {
            //AudioManager.instance.PlaySound("Button Press");
        }
    }
}
