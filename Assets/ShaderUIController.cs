using UnityEngine;
using UnityEngine.Rendering;

public class ShaderUIController : MonoBehaviour
{
    public Material fullscreenStereoMaterial;

    public enum ProcessingType
    {
        CONTRAST,
        BRIGHTNESS,
        GRAYSCALE
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateShaderState(int index)
    {
        ProcessingType selected = (ProcessingType)index;
        foreach (ProcessingType type in System.Enum.GetValues(typeof(ProcessingType)))
        {
            string key = "_PROCESSINGTYPE_" + type.ToString();
            LocalKeyword keyword = new LocalKeyword(fullscreenStereoMaterial.shader, key);
            fullscreenStereoMaterial.SetKeyword(keyword, type == selected);
        }
    }

    public void UpdateShaderIntensity(float value)
    {
        fullscreenStereoMaterial.SetFloat("_ProcessingIntensity", value);
    }
}
