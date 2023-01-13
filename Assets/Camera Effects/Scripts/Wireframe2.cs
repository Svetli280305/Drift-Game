using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Wireframe2 : MonoBehaviour
{
    public Shader ReplacementShader;
    public Color OverDrawColor;

    public Material BlurMaterial;
    public Material AddMaterial;
    [Range(0, 10)]
    private int Iterations;
    [Range(0, 4)]
    private int DownRes;
    [Range(0, 10)]
    private float Size;
    [Range(0, 3)]
    private float Intensity;

    void OnValidate()
    {
        Shader.SetGlobalColor("_OverDrawColor", OverDrawColor);

        if (BlurMaterial != null)
            BlurMaterial.SetFloat("_Size", Size);
        if (AddMaterial != null)
            AddMaterial.SetFloat("_Intensity", Intensity);
    }

    void OnEnable()
    {
        if (ReplacementShader != null)
            GetComponent<Camera>().SetReplacementShader(ReplacementShader, "");
    }

    void OnDisable()
    {
        GetComponent<Camera>().ResetReplacementShader();
    }


    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        RenderTexture composite = RenderTexture.GetTemporary(src.width, src.height);
        Graphics.Blit(src, composite);

        int width = src.width >> DownRes;
        int height = src.height >> DownRes;

        RenderTexture rt = RenderTexture.GetTemporary(width, height);
        Graphics.Blit(src, rt);

        for (int i = 0; i < Iterations; i++)
        {
            RenderTexture rt2 = RenderTexture.GetTemporary(width, height);
            Graphics.Blit(rt, rt2, BlurMaterial);
            RenderTexture.ReleaseTemporary(rt);
            rt = rt2;
        }

        AddMaterial.SetTexture("_BlendTex", rt);
        Graphics.Blit(composite, dst, AddMaterial);

        RenderTexture.ReleaseTemporary(rt);
        RenderTexture.ReleaseTemporary(composite);
    }
}