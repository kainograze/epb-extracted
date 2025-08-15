Shader "Hidden/TerrainEngine/Splatmap/Lightmap-BaseMap" {
Properties {
	_LightMap ("LightMap (RGB)", 2D) = "white" {}
	_BaseMap ("BaseMap (RGB)", 2D) = "white" {}
}

// dual texture cards
SubShader {
	Tags {
		"SplatCount" = "0"
		"Queue" = "Geometry-100"
		"RenderType" = "Opaque"
	}
	Pass {
		Tags { "LightMode" = "Always" }
		SetTexture [_BaseMap] { combine texture }
		SetTexture [_LightMap] { combine texture * previous DOUBLE }
	}
	UsePass "VertexLit/SHADOWCASTER"
}

// single texture cards, draw in two passes
SubShader {
	Tags {
		"SplatCount" = "0"
		"Queue" = "Geometry-100"
		"RenderType" = "Opaque"
	}
	Pass {
		Tags { "LightMode" = "Always" }
		SetTexture [_BaseMap] { combine texture }
	}
	Pass {
		Tags { "LightMode" = "Always" }
		Blend DstColor SrcColor
		ZWrite Off
		SetTexture [_LightMap] { combine texture }
	}
}

// single texture cards that don't support multiplicative blends - no lightmap :(
SubShader {
	Tags {
		"SplatCount" = "0"
		"Queue" = "Geometry-100"
		"RenderType" = "Opaque"
	}
	Pass {
		Tags { "LightMode" = "Always" }
		SetTexture [_BaseMap] { combine texture }
	}
}
}
