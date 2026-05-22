using UnityEngine;

public class WaterMngt : MonoBehaviour
{
    [SerializeField] private float waveHeight = 0.5f;
    [SerializeField] private float waveFrequency = 1f;
    [SerializeField] private float waveSpeed = 1f;


    private const int textureSize = 256;

    public GameObject waterSurface;
    Material waterMat;
    Texture2D waveScale;


    private void Start()
    {
        SetVariables();
    }
    void SetVariables()
    {
        waterMat = waterSurface.GetComponent<Renderer>().sharedMaterial;
        GetWaveScale();
    }
    Texture2D GetWaveScale()
    {
        waveScale = new Texture2D(textureSize, textureSize, TextureFormat.RGBA32, false);
        waveScale.wrapMode = TextureWrapMode.Repeat;
        for (int i = 0; i < textureSize; i++)
        {
            for (int j = 0; j < textureSize; j++)
            {
                float x = (float)i / textureSize;
                float y = (float)j / textureSize;
                float value = Mathf.PerlinNoise(x, y);
                waveScale.SetPixel(i, j, new Color(value, value, value));
            }
        }
        waveScale.Apply();
        return waveScale;
    }
    public float waterHeightAtPosition(Vector3 position)
    {
        return waterSurface.transform.position.y +
        waveScale.GetPixelBilinear(position.x * waveFrequency, position.z * waveFrequency + Time.time * waveSpeed).g
        * waveHeight * waterSurface.transform.localScale.x;
    }
    private void OnValidate()
    {
        if (!waterMat)
            SetVariables();
        UpdateMaterial();
    }
    void UpdateMaterial()
    {
        waterMat.SetFloat("_WaveHeight", waveHeight);
        waterMat.SetFloat("_WaveFrequency", waveFrequency);
        waterMat.SetFloat("_WaveSpeed", waveSpeed);
    }


}
