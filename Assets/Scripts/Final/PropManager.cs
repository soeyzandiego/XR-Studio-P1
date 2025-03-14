using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PropManager : MonoBehaviour
{
    [SerializeField] PropSet[] sets;
    [SerializeField] Material lockMaterial;
    [SerializeField] AudioClip removeSound;

    List<Prop> propsInScene = new List<Prop>();

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

    public void AddProp(Prop newProp)
    {
        propsInScene.Add(newProp);
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
        Prop[] all = FindObjectsByType<Prop>(UnityEngine.FindObjectsSortMode.None);
        if (all.Length == 0) { return; }
        foreach (Prop prop in all)
        {
            if (prop.TryGetComponent<Rigidbody>(out var rb) && locked)
            {
                rb.constraints = RigidbodyConstraints.FreezePosition;
                prop.ChangeMaterial(lockMaterial);
            }
            else if (!locked)
            {
                rb.constraints = RigidbodyConstraints.None;
                prop.ChangeMaterial();
            }
        }
    }

    public void RemoveProps()
    {
        StartCoroutine(PropRemoval());
    }

    IEnumerator PropRemoval()
    {
        Prop[] all = FindObjectsByType<Prop>(UnityEngine.FindObjectsSortMode.None);
        if (all.Length == 0) { yield break; }
        foreach (Prop prop in all)
        {
            GameObject audio = new GameObject();
            audio.transform.position = prop.transform.position;
            AudioSource source = audio.AddComponent<AudioSource>();
            source.playOnAwake = false;
            source.clip = removeSound;
            source.Play();
            Destroy(audio, 1f);

            Destroy(prop.gameObject);
            yield return new WaitForSeconds(Random.Range(0.08f, 0.5f));
        }
    }
}
