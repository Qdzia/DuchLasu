using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{

    public Transform tr;
    public Transform cam;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = cam.position - tr.position;
    }

    // Update is called once per frame
    void Update()
    {
        cam.position = tr.position;
        cam.position += pos;
    }
}
