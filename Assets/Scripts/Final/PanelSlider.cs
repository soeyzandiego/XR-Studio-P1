using UnityEngine;

public class PanelSlider : MonoBehaviour
{
    [SerializeField] AudioSource[] sources;

    int sourceIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < sources.Length - 1; i++)
        {
            if (i == sourceIndex) { sources[i].volume = 1; }
            else { sources[i].volume = 0; }
        }
    }
}
