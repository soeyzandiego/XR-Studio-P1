using UnityEngine;

public class Prop : MonoBehaviour
{
    Material originMaterial;

    Renderer rend;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMaterial(Material material)
    {
        rend.material.color = Color.red;
    }

    public void ChangeMaterial()
    {
        rend.material = originMaterial;
    }
}
