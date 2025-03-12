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

        
        float rotateAngle = transform.localEulerAngles.x;
        // Convert negative angle to positive angle
        rotateAngle = (rotateAngle > 180) ? rotateAngle - 360 : rotateAngle;
        crankValue = rotateAngle;
        transform.localEulerAngles = new Vector3(crankValue, transform.localEulerAngles.y, transform.localEulerAngles.z);
        //crankValue = Mathf.Atan2(transform.right.y, transform.right.x);
        //crankValue += Mathf.PI;
        //crankValue /= 2f * Mathf.PI;

        nCrankValue = Mathf.Abs(crankValue / 90);
        light.intensity = nCrankValue;
    }
 }
