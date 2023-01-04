// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: upgraded instancing buffer 'Props' to new syntax.

Shader "Custom/GrassShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _ReflectTex("Reflection Texture", 2D) = "white" {}
        _RefractTex("Refraction Texture", 2D) = "white" {}
        _WaveStrength("Wave Strength", Range(0, 0.1)) = 0.005
        _Reflectiveness("Reflectiveness", Range(0, 1)) = 0.5
        _Refractiveness("Refractiveness", Range(0, 1)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types

        // Use vertex position for the reflection sampling
        #pragma vertex vert
        #pragma fragment frag

        // Include surface shaders functions
        #include "UnityCG.cginc"

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_ReflectTex;
            float2 uv_RefractTex;
        };

        sampler2D _MainTex;
        sampler2D _ReflectTex;
        sampler2D _RefractTex;
        float _WaveStrength;
        float _Reflectiveness;
        float _Refractiveness;

        // Add vert function for creating a world-space reflection vector
        void vert(inout appdata_full v)
        {
            v.texcoord.xy = UnityObjectToClipPos(v.vertex).xy * _WaveStrength;
        }

        // Add surf function for the water surface
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Sample the textures
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * (1 - _Reflectiveness - _Refractiveness);
            c += tex2D(_ReflectTex, IN.uv_ReflectTex) * _Reflectiveness;
            c += tex2D(_RefractTex, IN.uv_RefractTex) * _Refractiveness;

            // Assign the final surface color
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
}