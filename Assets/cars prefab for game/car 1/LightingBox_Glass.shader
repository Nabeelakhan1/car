Shader "LightingBox/Glass" {
	Properties {
		_Color ("Color", Vector) = (1,1,1,0.584)
		_Smoothness ("Smoothness", Range(0, 1)) = 0
		_Specular ("Specular", Vector) = (0,0,0,1)
		[Header(Refraction)] _RefractionValue ("Refraction Value", Range(0, 2)) = 0
		_ChromaticAberration ("Chromatic Aberration", Range(0, 0.3)) = 0.1
		[HideInInspector] __dirty ("", Float) = 1
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = _Color.rgb;
			o.Alpha = _Color.a;
		}
		ENDCG
	}
	Fallback "Diffuse"
	//CustomEditor "ASEMaterialInspector"
}