Shader "Hidden/TerrainEngine/Splatmap/Lightmap-AddPass" {
Properties {
	_Control ("Control (RGBA)", 2D) = "black" {}
	_LightMap ("LightMap (RGB)", 2D) = "white" {}
	_Splat3 ("Layer 3 (A)", 2D) = "white" {}
	_Splat2 ("Layer 2 (B)", 2D) = "white" {}
	_Splat1 ("Layer 1 (G)", 2D) = "white" {}
	_Splat0 ("Layer 0 (R)", 2D) = "white" {}
}

Category {
	Blend One One
	ZWrite Off
	Fog { Color (0,0,0,0) }
	
	// Fragment program, 4 splats per pass
	SubShader {
		Tags {
			"SplatCount" = "4"
			"Queue" = "Geometry-99"
			"IgnoreProjector"="True"
			"RenderType" = "Transparent"
		}
		Pass {
			Tags { "LightMode" = "Always" }
			Program "" {
// Vertex combos: 1, instructions: 11 to 11
// Fragment combos: 1, instructions: 15 to 15, texreads: 6 to 6
SubProgram "opengl " {
Keywords { }
Bind "vertex", Vertex
Bind "texcoord", TexCoord0
Local 1, [_Splat0_ST]
Local 2, [_Splat1_ST]
Local 3, [_Splat2_ST]
Local 4, [_Splat3_ST]
"!!ARBvp1.0
# 11 instructions
PARAM c[9] = { program.local[0..4],
		state.matrix.mvp };
TEMP R0;
DP4 R0.x, vertex.position, c[7];
MOV result.texcoord[0].xy, vertex.texcoord[0];
MAD result.texcoord[1].zw, vertex.texcoord[0].xyxy, c[2].xyxy, c[2];
MAD result.texcoord[1].xy, vertex.texcoord[0], c[1], c[1].zwzw;
MAD result.texcoord[2].zw, vertex.texcoord[0].xyxy, c[4].xyxy, c[4];
MAD result.texcoord[2].xy, vertex.texcoord[0], c[3], c[3].zwzw;
DP4 result.position.w, vertex.position, c[8];
MOV result.position.z, R0.x;
DP4 result.position.y, vertex.position, c[6];
DP4 result.position.x, vertex.position, c[5];
MOV result.fogcoord.x, R0;
END
# 11 instructions, 1 R-regs
"
}

SubProgram "d3d9 " {
Keywords { }
Bind "vertex", Vertex
Bind "texcoord", TexCoord0
Local 4, [_Splat0_ST]
Local 5, [_Splat1_ST]
Local 6, [_Splat2_ST]
Local 7, [_Splat3_ST]
Matrix 0, [glstate_matrix_mvp]
"vs_1_1
dcl_position v0
dcl_texcoord0 v1
dp4 r0.x, v0, c2
mov oT0.xy, v1
mad oT1.zw, v1.xyxy, c5.xyxy, c5
mad oT1.xy, v1, c4, c4.zwzw
mad oT2.zw, v1.xyxy, c7.xyxy, c7
mad oT2.xy, v1, c6, c6.zwzw
dp4 oPos.w, v0, c3
mov oPos.z, r0.x
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
mov oFog, r0.x
"
}

SubProgram "opengl " {
Keywords { }
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_LightMap] {2D}
"!!ARBfp1.0
OPTION ARB_fog_exp2;
OPTION ARB_precision_hint_fastest;
# 15 instructions, 6 texture reads
PARAM c[1] = { { 2, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R1, fragment.texcoord[1], texture[1], 2D;
TEX R2, fragment.texcoord[1].zwzw, texture[2], 2D;
TEX R5, fragment.texcoord[0], texture[5], 2D;
TEX R4, fragment.texcoord[2].zwzw, texture[4], 2D;
TEX R3, fragment.texcoord[2], texture[3], 2D;
MUL R2, R0.y, R2;
MUL R1, R0.x, R1;
ADD R1, R1, R2;
MUL R2, R0.z, R3;
MUL R0, R0.w, R4;
ADD R1, R1, R2;
ADD R0, R1, R0;
MUL R0, R0, R5;
MUL result.color, R0, c[0].xxxy;
END
# 15 instructions, 6 R-regs
"
}

SubProgram "d3d9 " {
Keywords { }
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_LightMap] {2D}
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
def c0, 2.00000000, 0.00000000, 0, 0
dcl t0.xy
dcl t1
dcl t2
texld r2, t2, s3
texld r5, t0, s0
texld r4, t1, s1
mov r0.y, t1.w
mov r0.x, t1.z
mov r3.xy, r0
mov r0.y, t2.w
mov r0.x, t2.z
mov r1.xy, r0
mul r4, r5.x, r4
mul r2, r5.z, r2
texld r0, t0, s5
texld r1, r1, s4
texld r3, r3, s2
mul r3, r5.y, r3
add_pp r3, r4, r3
add_pp r2, r3, r2
mul r1, r5.w, r1
add_pp r1, r2, r1
mul r1, r1, r0
mov r0.w, c0.y
mov r0.xyz, c0.x
mul_pp r0, r1, r0
mov_pp oC0, r0
"
}

}
#LINE 34

		}
 	}
 	
 	// ATI texture shader, 4 splats per pass
	SubShader {
		Tags {
			"SplatCount" = "4"
			"Queue" = "Geometry-99"
			"IgnoreProjector"="True"
			"RenderType" = "Transparent"
		}
		Pass {
			Tags { "LightMode" = "Always" }
			
			Program "" {
				SubProgram {
"!!ATIfs1.0
StartConstants;
	CONSTANT c0 = {0};
EndConstants;

StartOutputPass;
	SampleMap r0, t0.str;	# splat0
	SampleMap r1, t1.str;	# splat1	
	SampleMap r2, t2.str;	# splat2	
	SampleMap r3, t3.str;	# splat3	
	SampleMap r4, t4.str;	# control
	SampleMap r5, t5.str;	# lightmap

	MUL r0.rgb, r0, r4.r;
	MAD r0.rgb, r1, r4.g, r0;
	MAD r0.rgb, r2, r4.b, r0;
	MAD r0.rgb, r3, r4.a, r0;
	MUL r0.rgb, r0.2x, r5;
	MOV r0.a, c0;
EndPass;
"
#LINE 71

				}
			}
			SetTexture [_Splat0]
			SetTexture [_Splat1]
			SetTexture [_Splat2]
			SetTexture [_Splat3]
			SetTexture [_Control]
			SetTexture [_LightMap]
		}
	}
	
	// Older cards - dummy subshader. Not actually used.
	SubShader {
		Pass {
			SetTexture [_LightMap]
		}
 	}
}

}
