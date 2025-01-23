Shader "Zen/Metallic" {
	Properties {
		_DiffuseColor ("Diffuse Color", Vector) = (1,1,1,1)
		_DiffuseColorForce ("Diffuse Color Force", Range(0, 2)) = 1
		_MainTex ("Albedo (RGB) A Metallic", 2D) = "white" {}
		[Toggle(_METALLIC_ON)] _UseMetallic ("Use Metallic", Float) = 0
		_Smoothness ("Smoothness", Range(0, 1)) = 0.9
		_Metallic ("Metallic", Range(0, 1)) = 0.25
		[Toggle(_DETAIL_ON)] _UseDetail ("Use Detail", Float) = 0
		_DetailColor ("Detail Color", Vector) = (1,1,1,1)
		_DetailColorForce ("Detail Color Force", Range(-1, 1)) = 0
		_DetailTex ("Detail (RGB) A Metallic", 2D) = "white" {}
		[Toggle(_NORMAL_ON)] _UseNormal ("Use Normal", Float) = 0
		_NormalTex ("Normal", 2D) = "white" {}
		[Toggle(_DECAL_ON)] _UseDecal ("Use Decal", Float) = 0
		_DecalColor ("Decal Color", Vector) = (1,1,1,1)
		_DecalTex ("Albedo (RGB) A Alpha", 2D) = "white" {}
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Diffuse"
}