using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Transform[] Backgruands;
    public float[] Scales;
    public Transform cam;
    float lastCamPos;
    public float smoothing = 1f; 
    void Start()
    {
        lastCamPos = cam.position.x;
        UpdateBackgrounds();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBackgrounds();
    }

    void UpdateBackgrounds()
    {
        for(int i=0;i<Backgruands.Length;i++)
        {
            float dif = (cam.position.x - lastCamPos)*Time.deltaTime*Scales[i];

            float paralaxPosition = dif + Backgruands[i].position.x;

            Vector3 targetPosition = new Vector3(paralaxPosition, Backgruands[i].position.y, Backgruands[i].position.z);


            Backgruands[i].position = Vector3.Lerp(Backgruands[i].position, targetPosition, smoothing * Time.deltaTime);

        }
        lastCamPos = cam.position.x;
    }
}
