using UnityEngine;

public class Crank : MonoBehaviour
{
    float crankValue;
    float lastCrankValue;
    float nCrankValue;

    [SerializeField] Light light;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //nCrankValue = Mathf.Abs(crankValue / 45);
        //light.intensity = nCrankValue;
        //Debug.Log(crankValue + ", " + nCrankValue);

        crankValue = transform.eulerAngles.x;
        //crankValue = Mathf.Atan2(transform.right.y, transform.right.x);
        //crankValue += Mathf.PI;
        //crankValue /= 2f * Mathf.PI;

        float diff = crankValue - lastCrankValue;
        light.intensity += diff / 1000;

        lastCrankValue = crankValue;
    }
}
