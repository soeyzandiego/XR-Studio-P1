using UnityEngine;
using System.Collections.Generic;

public class ControlPanel : MonoBehaviour
{
    [SerializeField] GameObject graphics;
    [SerializeField] PropSet[] propSets; // will not be GameObjects
    [SerializeField] GameObject propBoxPrefab;

    int propIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPanelActive(bool active)
    {
        if (active) { graphics.SetActive(true); }
        else { graphics.SetActive(false); }
    }

    public void SpawnPropBox()
    {
        PropSet propSet = propSets[propIndex];
        NewPropBox newBox = Instantiate(propBoxPrefab).GetComponent<NewPropBox>();
        newBox.InitBox(propSet);
    }

    public void ChangePropIndex(int dir)
    {
        dir = Mathf.FloorToInt(Mathf.Sign(dir));
        propIndex += dir;
        if (propIndex < 0) { propIndex = propSets.Length - 1; }
        if (propIndex > propSets.Length - 1) { propIndex = 0; }
    }
}
