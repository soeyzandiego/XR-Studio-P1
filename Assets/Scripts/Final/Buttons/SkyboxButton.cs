using UnityEngine;

public class SkyboxButton : PokeButton
{
    [SerializeField] Material[] skyboxes;

    int index = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Press()
    {
        base.Press();
        if (index < skyboxes.Length - 1) { index++; }
        else { index = 0; }
        RenderSettings.skybox = skyboxes[index];
    }
}
