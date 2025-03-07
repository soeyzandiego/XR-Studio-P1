using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PropManager : MonoBehaviour
{
    [SerializeField] PropSet[] sets;

    List<GameObject> propsInScene = new List<GameObject>();

    public static PropManager instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null) { instance = this; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearAllProps()
    {

    }

    public GameObject RandomProp()
    {
        List<GameObject> allProps = new List<GameObject>();
        foreach (PropSet set in sets)
        {
            foreach (GameObject prop in set.props)
            {
                allProps.Add(prop);
            }
        }

        return allProps[Random.Range(0, allProps.Count)];
    }

    public void SetObjectLock(bool locked)
    {
        foreach (GameObject prop in propsInScene)
        {
            if (prop.TryGetComponent<Rigidbody>(out var rb))
            {
                rb.constraints = RigidbodyConstraints.FreezePosition;
            }
        }
    }
}
