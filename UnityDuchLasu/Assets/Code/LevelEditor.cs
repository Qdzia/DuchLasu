using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    public Texture2D map;

    public ColorToPrefab[] colorMappings;
    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.width; y++)
            {
                GenerateTile(x,y);
            }

        }
    }

    void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0)
        {
            //Pixel is transparent
            return;
        }

        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector2 pos = new Vector2(x, y);
                Instantiate(colorMapping.prefab, pos, Quaternion.identity, transform);
            }
        }

    }

}
