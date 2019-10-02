using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{

    public Transform tr;
    public Vector3 offSet;
    // Start is called before the first frame update
    void Start()
    {
        offSet = transform.position - tr.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = tr.position;
        transform.position += offSet;
    }
}
