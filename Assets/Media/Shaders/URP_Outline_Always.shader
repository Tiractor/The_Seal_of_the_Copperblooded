Shader "Custom/URP_Outline_Always"
{
    Properties
    {
        _OutlineColor ("Outline Color", Color) = (1, 0, 0, 1)
        _OutlineThickness ("Thickness", Float) = 0.03
        _PulseSpeed ("Pulse Speed", Float) = 3
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Overlay+100" }

        Pass
        {
            Name "OutlinePass"
            Tags { "LightMode" = "UniversalForward" }

            Cull Front
            ZWrite Off
            ZTest Always

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            float4 _OutlineColor;
            float _OutlineThickness;
            float _PulseSpeed;

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
            };

            Varyings vert (Attributes v)
            {
                Varyings o;

                float pulse = _OutlineThickness + 0.01 * sin(_Time.y * _PulseSpeed);
                float3 offset = v.normalOS * pulse;
                float4 worldPos = mul(unity_ObjectToWorld, v.positionOS + float4(offset, 0));
                o.positionHCS = TransformWorldToHClip(worldPos.xyz);

                return o;
            }

            half4 frag (Varyings i) : SV_Target
            {
                return _OutlineColor;
            }

            ENDHLSL
        }
    }

    FallBack "Hidden/InternalErrorShader"
}
