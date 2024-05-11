Shader "Unlit/ShaderExample"
{
    Properties // custom defined input data other than unity's automatically supplied mesh/lighting data etc
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM // shader code starts here
            #pragma vertex vert
            #pragma fragment frag 
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata // (per-vertex mesh data)
            {
                float4 vertex : POSITION; // vertex position

                // float3 normals : NORMAL; // can be accessed along with tangent, vertex color

                float2 uv : TEXCOORD0; // UV coordinates, can have multiple UV channels. for example normal map displacement vs lightmap
            };

            struct v2f // data passed from vertext shader to fragment shader
            {
                // float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION; // clip space position
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;



            v2f vert (appdata v) 
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                // o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return float4( 1, 0, 0, 1 ); // red, RGBA, XYZW
            }
            ENDCG
        }
    }
}
