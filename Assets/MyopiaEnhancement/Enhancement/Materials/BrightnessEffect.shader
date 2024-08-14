Shader "Hidden/Brightness Effect URP" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Brightness("Brightness", Float) = 1.0
    }

    SubShader {
        Tags { "RenderType" = "Opaque" }
        LOD 100

        Pass {
            Name "BrightnessPass"
            ZWrite On
            ZTest LEqual

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float _Brightness;

            Varyings vert(Attributes v) {
                Varyings o;
                o.positionHCS = TransformObjectToHClip(v.positionOS);
                o.uv = v.uv;
                return o;
            }

            half4 frag(Varyings i) : SV_Target {
                half4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv);
                return color * _Brightness;
            }
            ENDHLSL
        }
    }
    Fallback "Hidden/InternalErrorShader"
}
