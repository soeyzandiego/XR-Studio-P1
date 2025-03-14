using UnityEngine;

public class PanelSlider : MonoBehaviour
{
    public enum SliderType { RADIO, COLOR };

    [SerializeField] SliderType type;
    [SerializeField] float slideLimit = 0.7f;
    [SerializeField] AudioSource[] sources;
    [SerializeField] float[] sourceThresholds;
    [SerializeField] Color startColor;
    [SerializeField] Color endColor;
    [SerializeField] Renderer targetRenderer;

    int sourceIndex = 0;
    float sliderPos;

    float volume;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (type == SliderType.COLOR) { sliderPos = transform.localPosition.x + slideLimit; }
        else { sliderPos = transform.localPosition.x; }
        //for (int i = sourceThresholds.Length - 1; i > 1; i--)
        //{
        //    Debug.Log(sliderPos > sourceThresholds[i - 1]);
        //    if (sliderPos > sourceThresholds[i-1]) { sourceIndex = i; break; }
        //}

        if (type == SliderType.RADIO)
        {
            if (sliderPos < sourceThresholds[0]) { sourceIndex = 0; }
            else if (sliderPos < sourceThresholds[1] && sliderPos > sourceThresholds[0]) { sourceIndex = 1; }
            else if (sliderPos < sourceThresholds[2] && sliderPos > sourceThresholds[1]) { sourceIndex = 2; }

            for (int i = 0; i < sources.Length; i++)
            {
                if (i == sourceIndex) { sources[i].volume = volume; }
                else { sources[i].volume = 0; }
            }
        }
        else if (type == SliderType.COLOR)
        {
            float nSliderPos = sliderPos / (slideLimit * 2);
            Color color = Color.Lerp(startColor, endColor, nSliderPos);
            targetRenderer.material.color = color;
        }

    }

    public void SetVolume(float _vol)
    {
        volume = _vol;
    }
}
