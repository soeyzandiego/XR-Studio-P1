using UnityEngine;

public class PanelKnob : MonoBehaviour
{
    [SerializeField] PanelSlider slider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vol = transform.eulerAngles.y / 360;
        slider.SetVolume(vol);
    }
}
