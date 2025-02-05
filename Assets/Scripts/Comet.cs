using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : MonoBehaviour
{
    [SerializeField] Vector3 dir;
    [SerializeField] float speed = 8f;

    GameObject child;

    // Start is called before the first frame update
    void Start()
    {
        child = GetComponentInChildren<TrailRenderer>().gameObject;
        dir += DirOffset();
        speed += Random.Range(-1.75f, 1.75f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir.normalized * speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (dir.normalized * 25));
    }

    Vector3 DirOffset()
    {
        return new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    CometTrashcan trashcan;
    //    if (other.TryGetComponent<CometTrashcan>(out trashcan))
    //    {
    //        child.SetActive(false);
    //        transform.position = trashcan.restartPoint.position + trashcan.Offset();
    //        //child.SetActive(true);
    //    }
    //}
}
