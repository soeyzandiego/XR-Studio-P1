using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] Vector3 rotAxis = Vector3.right;
    [SerializeField] float rotSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rotAxis = new Vector3(Mathf.Min(rotAxis.x, 1), Mathf.Min(rotAxis.y, 1), Mathf.Min(rotAxis.z, 1));
        transform.Rotate(rotAxis * rotSpeed * Time.deltaTime);
    }
}
