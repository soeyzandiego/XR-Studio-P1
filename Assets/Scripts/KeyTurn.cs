using UnityEngine;

public class KeyTurn : MonoBehaviour
{
    [SerializeField] AudioClip lockSound;
    [SerializeField] AudioClip unlockSound;

    bool locked = false;
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
            if (locked)
            {
                GetComponent<AudioSource>().PlayOneShot(unlockSound);
                PropManager.instance.SetObjectLock(true);
                locked = false;
                Debug.Log("locked");
            }
        }
        else
        {
            if (!locked)
            {
                GetComponent<AudioSource>().PlayOneShot(lockSound);
                PropManager.instance.SetObjectLock(false);
                locked = true;
                Debug.Log("unlocked");
            }
        }
    }
}
