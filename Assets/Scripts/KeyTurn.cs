using UnityEngine;

public class KeyTurn : MonoBehaviour
{
    bool locked;

    float keyRot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        keyRot = transform.eulerAngles.y;
        if (keyRot >= 90)
        {
            if (!locked)
            {
                // play sound
                PropManager.instance.SetObjectLock(true);
                locked = true;
            }
        }
        else
        {
            if (locked)
            {
                // play sound
                PropManager.instance.SetObjectLock(false);
                locked = false;
            }
        }
    }
}
