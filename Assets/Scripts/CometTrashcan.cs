using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometTrashcan : MonoBehaviour
{
    [SerializeField] public Transform restartPoint;
    [SerializeField] Vector3 offsetRange = new Vector3(10, 3, 10);
    [SerializeField] GameObject cometPrefab;

    public Vector3 Offset()
    {
        return new Vector3(Random.Range(-offsetRange.x, offsetRange.x), Random.Range(-offsetRange.y, offsetRange.y), Random.Range(-offsetRange.z, offsetRange.z));
    }

    private void OnTriggerEnter(Collider other)
    {
        //Comet comet;
        //if (other.TryGetComponent<Comet>(out comet))
        //{
        //    //comet.gameObject.SetActive(false);
        //    //comet.transform.position = restartPoint.position + Offset();
        //    //comet.gameObject.SetActive(true);
        //}
        Destroy(other.gameObject);
        Instantiate(cometPrefab, restartPoint.position + Offset(), Quaternion.identity);
    }
}
