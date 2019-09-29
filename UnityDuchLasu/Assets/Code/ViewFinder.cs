using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewFinder : MonoBehaviour
{

    public Transform trPlayer;
    public Transform trViewFinder;
    public BoxCollider2D col;
    public float ViewFinderWidth;

    public float tangent = 0;
    public float a = 0;
    public float b = 0;
    public float c = 0;
    public float delta = 0;
    public float x1 = 0;
    float y1 = 0;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        //ViewFinderWidth = (float)col.bounds.size.x/2;
        ViewFinderWidth = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        tangent = (Input.mousePosition.y - trPlayer.position.y)/(Input.mousePosition.x - trPlayer.position.x);

        a = 1 + tangent * tangent;
        //b = 2 * trPlayer.position.x + 2 * tangent * trPlayer.position.x - 2 * tangent * trPlayer.position.y;
        //c = 2 * trPlayer.position.x * trPlayer.position.x + trPlayer.position.y * trPlayer.position.y +
        //    2 * trPlayer.position.x * trPlayer.position.y - ViewFinderWidth * ViewFinderWidth;
        b = Input.mousePosition.x;
        c = Input.mousePosition.y;

    delta = b * b - 4 * a * c;

        //x1 = (-b - Mathf.Sqrt(delta) / 2 * a);
        if (Input.mousePosition.x > 0) x1 = Mathf.Sqrt(ViewFinderWidth * ViewFinderWidth / a);
        else x1 = -Mathf.Sqrt(ViewFinderWidth * ViewFinderWidth / a);
        
        y1 = Mathf.Sqrt(ViewFinderWidth * ViewFinderWidth * x1 * x1);

        trViewFinder.position = new Vector2(x1, y1);
        
    }
}
