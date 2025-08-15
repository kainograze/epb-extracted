Shader "Hidden/TerrainEngine/Splatmap/Vertexlit-FirstPass" {
Properties {
	_Control ("Control (RGBA)", 2D) = "red" {}
	_LightMap ("LightMap (RGB)", 2D) = "white" {}
	_Splat3 ("Layer 3 (A)", 2D) = "white" {}
	_Splat2 ("Layer 2 (B)", 2D) = "white" {}
	_Splat1 ("Layer 1 (G)", 2D) = "white" {}
	_Splat0 ("Layer 0 (R)", 2D) = "white" {}
	_BaseMap ("BaseMap (RGB)", 2D) = "white" {}
}
	
Category {
	// Fragment program, 4 splats per pass
	SubShader {		
		Tags {
			"SplatCount" = "4"
			"Queue" = "Geometry-100"
			"RenderType" = "Opaque"
		}
		Pass {
			Tags { "LightMode" = "Always" }
			
			Program "" {
// Vertex combos: 1, instructions: 62 to 62
// Fragment combos: 1, instructions: 14 to 14, texreads: 5 to 5
SubProgram "opengl " {
Keywords { }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 1, [_Splat0_ST]
Local 2, [_Splat1_ST]
Local 3, [_Splat2_ST]
Local 4, [_Splat3_ST]
"!!ARBvp1.0
# 62 instructions
PARAM c[30] = { { 1, 0 },
		program.local[1..4],
		state.light[0].diffuse,
		state.light[0].position,
		state.light[0].attenuation,
		state.light[1].diffuse,
		state.light[1].position,
		state.light[1].attenuation,
		state.light[2].diffuse,
		state.light[2].position,
		state.light[2].attenuation,
		state.light[3].diffuse,
		state.light[3].position,
		state.light[3].attenuation,
		state.lightmodel.ambient,
		state.matrix.modelview[0],
		state.matrix.mvp,
		state.matrix.modelview[0].transpose };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MUL R2.xyz, vertex.normal.y, c[27];
MAD R2.xyz, vertex.normal.x, c[26], R2;
DP4 R0.z, vertex.position, c[20];
DP4 R0.x, vertex.position, c[18];
DP4 R0.y, vertex.position, c[19];
MAD R1.xyz, -R0, c[9].w, c[9];
DP3 R0.w, R1, R1;
RSQ R1.w, R0.w;
MUL R0.w, R0, c[10].z;
ADD R0.w, R0, c[0].x;
MAD R2.xyz, vertex.normal.z, c[28], R2;
MUL R1.xyz, R1.w, R1;
DP3 R1.w, R2, R1;
MAD R1.xyz, -R0, c[6].w, c[6];
MAD R3.xyz, -R0, c[12].w, c[12];
RCP R0.w, R0.w;
MUL R0.w, R1, R0;
DP3 R2.w, R1, R1;
MUL R1.w, R2, c[7].z;
RSQ R2.w, R2.w;
MUL R1.xyz, R2.w, R1;
ADD R1.w, R1, c[0].x;
DP3 R1.x, R2, R1;
RCP R1.w, R1.w;
MUL R1.x, R1, R1.w;
MAX R3.w, R0, c[0].y;
MAX R0.w, R1.x, c[0].y;
MUL R1, R0.w, c[5];
DP3 R0.w, R3, R3;
RSQ R2.w, R0.w;
MUL R3.xyz, R2.w, R3;
MUL R2.w, R0, c[13].z;
ADD R1, R1, c[17];
ADD R2.w, R2, c[0].x;
DP3 R0.w, R2, R3;
MAD R0.xyz, -R0, c[15].w, c[15];
RCP R2.w, R2.w;
DP3 R3.x, R0, R0;
MUL R2.w, R0, R2;
MUL R0.w, R3.x, c[16].z;
RSQ R3.x, R3.x;
MUL R0.xyz, R3.x, R0;
DP3 R0.x, R2, R0;
ADD R0.w, R0, c[0].x;
RCP R0.w, R0.w;
MUL R0.x, R0, R0.w;
MAX R0.x, R0, c[0].y;
MAD R1, R3.w, c[8], R1;
MAX R0.y, R2.w, c[0];
MAD R1, R0.y, c[11], R1;
MAD result.color, R0.x, c[14], R1;
DP4 R0.x, vertex.position, c[24];
MOV result.texcoord[0].xy, vertex.texcoord[0];
MAD result.texcoord[1].zw, vertex.texcoord[0].xyxy, c[2].xyxy, c[2];
MAD result.texcoord[1].xy, vertex.texcoord[0], c[1], c[1].zwzw;
MAD result.texcoord[2].zw, vertex.texcoord[0].xyxy, c[4].xyxy, c[4];
MAD result.texcoord[2].xy, vertex.texcoord[0], c[3], c[3].zwzw;
DP4 result.position.w, vertex.position, c[25];
MOV result.position.z, R0.x;
DP4 result.position.y, vertex.position, c[23];
DP4 result.position.x, vertex.position, c[22];
MOV result.fogcoord.x, R0;
END
# 62 instructions, 4 R-regs
"
}

SubProgram "d3d9 " {
Keywords { }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 12, [_Splat0_ST]
Local 13, [_Splat1_ST]
Local 14, [_Splat2_ST]
Local 15, [_Splat3_ST]
Local 16, [glstate_light0_diffuse]
Local 17, [glstate_light0_position]
Local 18, [glstate_light0_attenuation]
Local 19, [glstate_light1_diffuse]
Local 20, [glstate_light1_position]
Local 21, [glstate_light1_attenuation]
Local 22, [glstate_light2_diffuse]
Local 23, [glstate_light2_position]
Local 24, [glstate_light2_attenuation]
Local 25, [glstate_light3_diffuse]
Local 26, [glstate_light3_position]
Local 27, [glstate_light3_attenuation]
Local 28, [glstate_lightmodel_ambient]
Matrix 0, [glstate_matrix_modelview0]
Matrix 4, [glstate_matrix_mvp]
Matrix 8, [glstate_matrix_transpose_modelview0]
"vs_1_1
def c29, 1.00000000, 0.00000000, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord0 v2
mul r2.xyz, v1.y, c9
mad r2.xyz, v1.x, c8, r2
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mad r1.xyz, -r0, c20.w, c20
dp3 r0.w, r1, r1
rsq r1.w, r0.w
mul r0.w, r0, c21.z
add r0.w, r0, c29.x
mad r2.xyz, v1.z, c10, r2
mul r1.xyz, r1.w, r1
dp3 r1.w, r2, r1
mad r1.xyz, -r0, c17.w, c17
mad r3.xyz, -r0, c23.w, c23
rcp r0.w, r0.w
mul r0.w, r1, r0
dp3 r2.w, r1, r1
mul r1.w, r2, c18.z
rsq r2.w, r2.w
mul r1.xyz, r2.w, r1
add r1.w, r1, c29.x
dp3 r1.x, r2, r1
rcp r1.w, r1.w
mul r1.x, r1, r1.w
max r3.w, r0, c29.y
max r0.w, r1.x, c29.y
mul r1, r0.w, c16
dp3 r0.w, r3, r3
rsq r2.w, r0.w
mul r3.xyz, r2.w, r3
mul r2.w, r0, c24.z
add r1, r1, c28
add r2.w, r2, c29.x
dp3 r0.w, r2, r3
mad r0.xyz, -r0, c26.w, c26
rcp r2.w, r2.w
dp3 r3.x, r0, r0
mul r2.w, r0, r2
mul r0.w, r3.x, c27.z
rsq r3.x, r3.x
mul r0.xyz, r3.x, r0
dp3 r0.x, r2, r0
add r0.w, r0, c29.x
rcp r0.w, r0.w
mul r0.x, r0, r0.w
max r0.x, r0, c29.y
mad r1, r3.w, c19, r1
max r0.y, r2.w, c29
mad r1, r0.y, c22, r1
mad oD0, r0.x, c25, r1
dp4 r0.x, v0, c6
mov oT0.xy, v2
mad oT1.zw, v2.xyxy, c13.xyxy, c13
mad oT1.xy, v2, c12, c12.zwzw
mad oT2.zw, v2.xyxy, c15.xyxy, c15
mad oT2.xy, v2, c14, c14.zwzw
dp4 oPos.w, v0, c7
mov oPos.z, r0.x
dp4 oPos.y, v0, c5
dp4 oPos.x, v0, c4
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
"!!ARBfp1.0
OPTION ARB_fog_exp2;
OPTION ARB_precision_hint_fastest;
# 14 instructions, 5 texture reads
PARAM c[1] = { { 2, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R1, fragment.texcoord[1], texture[1], 2D;
TEX R2, fragment.texcoord[1].zwzw, texture[2], 2D;
TEX R4, fragment.texcoord[2].zwzw, texture[4], 2D;
TEX R3, fragment.texcoord[2], texture[3], 2D;
MUL R2, R0.y, R2;
MUL R1, R0.x, R1;
ADD R1, R1, R2;
MUL R2, R0.z, R3;
MUL R0, R0.w, R4;
ADD R1, R1, R2;
ADD R0, R1, R0;
MUL R0, R0, fragment.color.primary;
MUL result.color, R0, c[0].xxxy;
END
# 14 instructions, 5 R-regs
"
}

SubProgram "d3d9 " {
Keywords { }
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
def c0, 2.00000000, 0.00000000, 0, 0
dcl t0.xy
dcl t1
dcl t2
dcl v0
texld r4, t0, s0
texld r3, t1, s1
mov r1.y, t1.w
mov r1.x, t1.z
mov r2.xy, r1
mov r0.y, t2.w
mov r0.x, t2.z
mul r3, r4.x, r3
texld r0, r0, s4
texld r1, t2, s3
texld r2, r2, s2
mul r2, r4.y, r2
add_pp r2, r3, r2
mul r1, r4.z, r1
add_pp r1, r2, r1
mul r0, r4.w, r0
add_pp r0, r1, r0
mul r1, r0, v0
mov r0.w, c0.y
mov r0.xyz, c0.x
mul_pp r0, r1, r0
mov_pp oC0, r0
"
}

}
#LINE 30

		}
 	}
 	
 	// ATI texture shader, 4 splats per pass
	SubShader {		
		Tags {
			"SplatCount" = "4"
			"Queue" = "Geometry-100"
			"RenderType" = "Opaque"
		}
		Pass {
			Tags { "LightMode" = "Always" }
			Material {
				Diffuse (1, 1, 1, 1)
				Ambient (1, 1, 1, 1)
			}
			Lighting On
			
			Program "" {
				SubProgram {
"!!ATIfs1.0
StartConstants;
	CONSTANT c0 = {0};
EndConstants;

StartOutputPass;
	SampleMap r0, t0.str;	# splat0
	SampleMap r1, t1.str;	# splat0	
	SampleMap r2, t2.str;	# splat0	
	SampleMap r3, t3.str;	# splat0	
	SampleMap r4, t4.str;	# control

	MUL r0.rgb, r0, r4.r;
	MAD r0.rgb, r1, r4.g, r0;
	MAD r0.rgb, r2, r4.b, r0;
	MAD r0.rgb, r3, r4.a, r0;
	MUL r0.rgb, r0.2x, color0;
	MOV r0.a, c0;
EndPass; 
"
#LINE 70

				}
			}
			SetTexture [_Splat0] 
			SetTexture [_Splat1] 
			SetTexture [_Splat2] 
			SetTexture [_Splat3] 
			SetTexture [_Control]
		}
 	}
}

// Fallback to base map	
Fallback "Hidden/TerrainEngine/Splatmap/VertexLit-BaseMap"
}
