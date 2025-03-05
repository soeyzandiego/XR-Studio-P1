using UnityEngine;
using System.Collections.Generic;
using Meta;
using OVR;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour
{
    [SerializeField] float panelPosDist = 1f;
    float minYPos = 3f;
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
        propIcon.sprite = propSets[propIndex].icon;
        minYPos = transform.position.y;
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
        Vector3 eulers = transform.eulerAngles;
        transform.LookAt(-player.GetComponent<OVRCameraRig>().centerEyeAnchor.forward);
        transform.eulerAngles = new Vector3(eulers.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
        Vector3 forwardOffset = player.GetComponent<OVRCameraRig>().centerEyeAnchor.forward * panelPosDist;
        Vector3 newPos = player.position + forwardOffset;
        newPos.y = Mathf.Max(minYPos, newPos.y);
        transform.position = newPos;
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
