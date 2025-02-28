using UnityEngine;
using System.Collections.Generic;
using Meta;
using OVR;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour
{
    [SerializeField] GameObject graphics;
    [SerializeField] PropSet[] propSets; // will not be GameObjects
    [SerializeField] Image propIcon;
    [SerializeField] GameObject propBoxPrefab;

    int propIndex;

    public static ControlPanel instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null) { instance = this; }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { Reposition(GameObject.Find("[BuildingBlock] Camera Rig").transform); }
    }

    public void SetPanelActive(bool active, Transform player)
    {
        if (active) { graphics.SetActive(true); Reposition(player); }
        else { graphics.SetActive(false); }
    }

    void Reposition(Transform player)
    {
        transform.LookAt(-player.GetComponent<OVRCameraRig>().centerEyeAnchor.forward);
        transform.position = player.position + player.GetComponent<OVRCameraRig>().centerEyeAnchor.forward * 2.5f;
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
        propIcon.sprite = propSets[propIndex].icon;
    }
}
