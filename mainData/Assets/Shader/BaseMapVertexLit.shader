Shader "Hidden/TerrainEngine/Splatmap/VertexLit-BaseMap" {
Properties {
	_LightMap ("LightMap (RGB)", 2D) = "white" {}
	_BaseMap ("BaseMap (RGB)", 2D) = "white" {}
}
SubShader {
	Tags {
		"SplatCount" = "0"
		"Queue" = "Geometry-100"
		"RenderType" = "Opaque"
	}
	Pass {
		Tags {"LightMode" = "Always" }
		Material {
			Diffuse (1, 1, 1, 1)
			Ambient (1, 1, 1, 1)
		}
		Lighting On
		
		SetTexture [_BaseMap] { combine texture * primary DOUBLE }
	}
	UsePass "VertexLit/SHADOWCASTER"
}
}
