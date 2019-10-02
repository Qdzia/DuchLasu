using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewFinder : MonoBehaviour
{

    public Transform trPlayer;
    public BoxCollider2D col;
    public Camera cam;
    public float ViewFinderWidth;

    public float tangent = 0;
    public float a = 0;
    public float b = 0;
    public float c = 0;
    public float delta = 0;
    public float angle = 0;
    
    public float x1 = 0;
    public float y1 = 0;
    Vector3 pos;
    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        ViewFinderWidth = 2f;
        //ViewFinderWidth = (float)col.bounds.size.x/2;
        transform.position = trPlayer.position + new Vector3(0f, ViewFinderWidth, 0f);
        //transform.Translate(0f, ViewFinderWidth,0f);
        pos = trPlayer.position;
        
    }

    private void FixedUpdate()
    {
        delta = Mathf.Atan2(mousePos.y - Input.mousePosition.y, mousePos.x - Input.mousePosition.x) * Mathf.Rad2Deg;
        if (delta != 0) angle = -delta;

        mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        x1 = ViewFinderWidth * Mathf.Cos(angle) + trPlayer.position.x;
        y1 = ViewFinderWidth * Mathf.Sin(angle) + trPlayer.position.y;

        transform.position = new Vector2(x1, y1);
    }
    // Update is called once per frame
    void Update()
    {
        //pos = trPlayer.position - pos;
        //transform.position += pos ;
        //pos = trPlayer.position;

        

        

        
        //pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //pos = cam.ScreenToWorldPoint(pos);

        //tangent = (pos.y - trPlayer.position.y)/(pos.x - trPlayer.position.x);

        //a = 1 + tangent * tangent;
        ////b = 2 * trPlayer.position.x + 2 * tangent * trPlayer.position.x - 2 * tangent * trPlayer.position.y;
        ////c = 2 * trPlayer.position.x * trPlayer.position.x + trPlayer.position.y * trPlayer.position.y +
        ////    2 * trPlayer.position.x * trPlayer.position.y - ViewFinderWidth * ViewFinderWidth;
        b = pos.x;
        c = pos.y;

        //delta = b * b - 4 * a * c;

        ////x1 = (-b - Mathf.Sqrt(delta) / 2 * a);


        //if (pos.x >0 && pos.y >0)
        //{
        //    x1 = Mathf.Sqrt(ViewFinderWidth * ViewFinderWidth / a);
        //    y1 = Mathf.Sqrt(ViewFinderWidth * ViewFinderWidth + x1 * x1);
        //}
        //else if (pos.x > 0 && pos.y < 0)
        //{
        //    x1 = Mathf.Sqrt(ViewFinderWidth * ViewFinderWidth / a);
        //    y1 = -Mathf.Sqrt(ViewFinderWidth * ViewFinderWidth + x1 * x1);
        //}
        //else if (pos.x < 0 && pos.y > 0)
        //{
        //    x1 = -Mathf.Sqrt(ViewFinderWidth * ViewFinderWidth / a);
        //    y1 = Mathf.Sqrt(ViewFinderWidth * ViewFinderWidth + x1 * x1);
        //}
        //else
        //{
        //    x1 = -Mathf.Sqrt(ViewFinderWidth * ViewFinderWidth / a);
        //    y1 = -Mathf.Sqrt(ViewFinderWidth * ViewFinderWidth + x1 * x1);
        //}

        //    if (offSet.x > 0) x1 = Mathf.Sqrt(ViewFinderWidth * ViewFinderWidth / a);
        //else x1 = -Mathf.Sqrt(ViewFinderWidth * ViewFinderWidth / a);

        //if (offSet.y > 0) y1 = Mathf.Sqrt(ViewFinderWidth * ViewFinderWidth + x1 * x1);
        //else y1 = -Mathf.Sqrt(ViewFinderWidth * ViewFinderWidth + x1 * x1);




    }
}
