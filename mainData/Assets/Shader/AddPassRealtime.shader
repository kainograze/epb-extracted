Shader "Hidden/TerrainEngine/Splatmap/Realtime-AddPass" {
Properties {
	_Control ("Control (RGBA)", 2D) = "black" {}
	_LightMap ("LightMap (RGB)", 2D) = "white" {}
	_Splat3 ("Layer 3 (A)", 2D) = "white" {}
	_Splat2 ("Layer 2 (B)", 2D) = "white" {}
	_Splat1 ("Layer 1 (G)", 2D) = "white" {}
	_Splat0 ("Layer 0 (R)", 2D) = "white" {}
}
	
SubShader {		
	Tags {
		"SplatCount" = "4"
		"Queue" = "Geometry-99"
		"IgnoreProjector"="True"
		"RenderType" = "Transparent"
	}
	
	Blend One One
	ZWrite Off
	Fog { Color (0,0,0,0) }
	
	// Ambient pass
	Pass {
		Tags { "LightMode" = "PixelOrNone" }
		
		Program "" {
// Vertex combos: 1, instructions: 12 to 12
// Fragment combos: 1, instructions: 18 to 18, texreads: 6 to 6
SubProgram "opengl " {
Keywords { }
Bind "vertex", Vertex
Bind "texcoord", TexCoord0
Local 1, [_Splat0_ST]
Local 2, [_Splat1_ST]
Local 3, [_Splat2_ST]
Local 4, [_Splat3_ST]
Local 5, [_RealtimeFade]
"!!ARBvp1.0
# 12 instructions
PARAM c[10] = { program.local[0..5],
		state.matrix.mvp };
TEMP R0;
DP4 R0.x, vertex.position, c[8];
MOV result.texcoord[0].xy, vertex.texcoord[0];
MAD result.texcoord[1].zw, vertex.texcoord[0].xyxy, c[2].xyxy, c[2];
MAD result.texcoord[1].xy, vertex.texcoord[0], c[1], c[1].zwzw;
MAD result.texcoord[2].zw, vertex.texcoord[0].xyxy, c[4].xyxy, c[4];
MAD result.texcoord[2].xy, vertex.texcoord[0], c[3], c[3].zwzw;
DP4 result.position.w, vertex.position, c[9];
MOV result.position.z, R0.x;
DP4 result.position.y, vertex.position, c[7];
DP4 result.position.x, vertex.position, c[6];
MOV result.fogcoord.x, R0;
MAD result.texcoord[3].x, R0, c[5].z, c[5].w;
END
# 12 instructions, 1 R-regs
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
Local 8, [_RealtimeFade]
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
mad oT3.x, r0, c8.z, c8.w
"
}

SubProgram "opengl " {
Keywords { }
Local 0, [_PPLAmbient]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_LightMap] {2D}
"!!ARBfp1.0
OPTION ARB_fog_exp2;
OPTION ARB_precision_hint_fastest;
# 18 instructions, 6 texture reads
PARAM c[2] = { program.local[0],
		{ 2, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R1, fragment.texcoord[1], texture[1], 2D;
TEX R2, fragment.texcoord[1].zwzw, texture[2], 2D;
TEX R3, fragment.texcoord[2], texture[3], 2D;
TEX R5, fragment.texcoord[0], texture[5], 2D;
TEX R4, fragment.texcoord[2].zwzw, texture[4], 2D;
MUL R3, R0.z, R3;
MUL R2, R0.y, R2;
MUL R1, R0.x, R1;
ADD R1, R1, R2;
ADD R1, R1, R3;
MUL R0, R0.w, R4;
ADD R2, R5, -c[0];
MOV_SAT R3.x, fragment.texcoord[3];
MAD R2, R3.x, R2, c[0];
ADD R0, R1, R0;
MUL R0, R0, R2;
MUL result.color, R0, c[1].xxxy;
END
# 18 instructions, 6 R-regs
"
}

SubProgram "d3d9 " {
Keywords { }
Local 0, [_PPLAmbient]
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
def c1, 2.00000000, 0.00000000, 0, 0
dcl t0.xy
dcl t1
dcl t2
dcl t3.x
texld r4, t1, s1
texld r5, t0, s0
mov r0.y, t1.w
mov r0.x, t1.z
mov r2.xy, r0
mov r0.y, t2.w
mov r0.x, t2.z
mov r1.xy, r0
mul r4, r5.x, r4
texld r3, r2, s2
texld r0, t0, s5
texld r1, r1, s4
texld r2, t2, s3
mul r3, r5.y, r3
add_pp r3, r4, r3
mul r2, r5.z, r2
add_pp r2, r3, r2
mul r1, r5.w, r1
add r0, r0, -c0
mov_sat r3.x, t3
mad r0, r3.x, r0, c0
add_pp r1, r2, r1
mul_pp r1, r1, r0
mov r0.w, c1.y
mov r0.xyz, c1.x
mul_pp r0, r1, r0
mov_pp oC0, r0
"
}

}
#LINE 35

	}
	// Vertex lights
	Pass {
		Tags { "LightMode" = "Vertex" }
		
		Program "" {
// Vertex combos: 1, instructions: 64 to 64
// Fragment combos: 1, instructions: 18 to 18, texreads: 6 to 6
SubProgram "opengl " {
Keywords { }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 1, [_Splat0_ST]
Local 2, [_Splat1_ST]
Local 3, [_Splat2_ST]
Local 4, [_Splat3_ST]
Local 5, [_RealtimeFade]
"!!ARBvp1.0
# 64 instructions
PARAM c[31] = { { 1, 0 },
		program.local[1..5],
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
MUL R2.xyz, vertex.normal.y, c[28];
MAD R2.xyz, vertex.normal.x, c[27], R2;
DP4 R0.z, vertex.position, c[21];
DP4 R0.x, vertex.position, c[19];
DP4 R0.y, vertex.position, c[20];
MAD R1.xyz, -R0, c[10].w, c[10];
DP3 R0.w, R1, R1;
RSQ R1.w, R0.w;
MUL R0.w, R0, c[11].z;
ADD R0.w, R0, c[0].x;
MAD R2.xyz, vertex.normal.z, c[29], R2;
MUL R1.xyz, R1.w, R1;
DP3 R1.w, R2, R1;
MAD R1.xyz, -R0, c[7].w, c[7];
MAD R3.xyz, -R0, c[13].w, c[13];
RCP R0.w, R0.w;
MUL R0.w, R1, R0;
DP3 R2.w, R1, R1;
MUL R1.w, R2, c[8].z;
RSQ R2.w, R2.w;
MUL R1.xyz, R2.w, R1;
ADD R1.w, R1, c[0].x;
DP3 R1.x, R2, R1;
RCP R1.w, R1.w;
MUL R1.x, R1, R1.w;
MAX R3.w, R0, c[0].y;
MAX R0.w, R1.x, c[0].y;
MUL R1, R0.w, c[6];
DP3 R0.w, R3, R3;
RSQ R2.w, R0.w;
MUL R3.xyz, R2.w, R3;
MUL R2.w, R0, c[14].z;
ADD R1, R1, c[18];
ADD R2.w, R2, c[0].x;
DP3 R0.w, R2, R3;
MAD R0.xyz, -R0, c[16].w, c[16];
RCP R2.w, R2.w;
DP3 R3.x, R0, R0;
MUL R2.w, R0, R2;
MUL R0.w, R3.x, c[17].z;
RSQ R3.x, R3.x;
MUL R0.xyz, R3.x, R0;
DP3 R0.x, R2, R0;
ADD R0.w, R0, c[0].x;
RCP R0.w, R0.w;
MUL R0.x, R0, R0.w;
MAX R0.y, R2.w, c[0];
MAD R1, R3.w, c[9], R1;
MAD R1, R0.y, c[12], R1;
MAX R0.x, R0, c[0].y;
MAD result.color, R0.x, c[15], R1;
DP4 R0.x, vertex.position, c[25];
MAD R0.y, R0.x, c[5].z, c[5].w;
MOV result.texcoord[0].xy, vertex.texcoord[0];
MAD result.texcoord[1].zw, vertex.texcoord[0].xyxy, c[2].xyxy, c[2];
MAD result.texcoord[1].xy, vertex.texcoord[0], c[1], c[1].zwzw;
MAD result.texcoord[2].zw, vertex.texcoord[0].xyxy, c[4].xyxy, c[4];
MAD result.texcoord[2].xy, vertex.texcoord[0], c[3], c[3].zwzw;
DP4 result.position.w, vertex.position, c[26];
MOV result.position.z, R0.x;
DP4 result.position.y, vertex.position, c[24];
DP4 result.position.x, vertex.position, c[23];
MOV result.fogcoord.x, R0;
ADD result.texcoord[3].x, -R0.y, c[0];
END
# 64 instructions, 4 R-regs
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
Local 16, [_RealtimeFade]
Local 17, [glstate_light0_diffuse]
Local 18, [glstate_light0_position]
Local 19, [glstate_light0_attenuation]
Local 20, [glstate_light1_diffuse]
Local 21, [glstate_light1_position]
Local 22, [glstate_light1_attenuation]
Local 23, [glstate_light2_diffuse]
Local 24, [glstate_light2_position]
Local 25, [glstate_light2_attenuation]
Local 26, [glstate_light3_diffuse]
Local 27, [glstate_light3_position]
Local 28, [glstate_light3_attenuation]
Local 29, [glstate_lightmodel_ambient]
Matrix 0, [glstate_matrix_modelview0]
Matrix 4, [glstate_matrix_mvp]
Matrix 8, [glstate_matrix_transpose_modelview0]
"vs_1_1
def c30, 1.00000000, 0.00000000, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord0 v2
mul r2.xyz, v1.y, c9
mad r2.xyz, v1.x, c8, r2
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mad r1.xyz, -r0, c21.w, c21
dp3 r0.w, r1, r1
rsq r1.w, r0.w
mul r0.w, r0, c22.z
add r0.w, r0, c30.x
mad r2.xyz, v1.z, c10, r2
mul r1.xyz, r1.w, r1
dp3 r1.w, r2, r1
mad r1.xyz, -r0, c18.w, c18
mad r3.xyz, -r0, c24.w, c24
rcp r0.w, r0.w
mul r0.w, r1, r0
dp3 r2.w, r1, r1
mul r1.w, r2, c19.z
rsq r2.w, r2.w
mul r1.xyz, r2.w, r1
add r1.w, r1, c30.x
dp3 r1.x, r2, r1
rcp r1.w, r1.w
mul r1.x, r1, r1.w
max r3.w, r0, c30.y
max r0.w, r1.x, c30.y
mul r1, r0.w, c17
dp3 r0.w, r3, r3
rsq r2.w, r0.w
mul r3.xyz, r2.w, r3
mul r2.w, r0, c25.z
add r1, r1, c29
add r2.w, r2, c30.x
dp3 r0.w, r2, r3
mad r0.xyz, -r0, c27.w, c27
rcp r2.w, r2.w
dp3 r3.x, r0, r0
mul r2.w, r0, r2
mul r0.w, r3.x, c28.z
rsq r3.x, r3.x
mul r0.xyz, r3.x, r0
dp3 r0.x, r2, r0
add r0.w, r0, c30.x
rcp r0.w, r0.w
mul r0.x, r0, r0.w
max r0.y, r2.w, c30
mad r1, r3.w, c20, r1
mad r1, r0.y, c23, r1
max r0.x, r0, c30.y
mad oD0, r0.x, c26, r1
dp4 r0.x, v0, c6
mad r0.y, r0.x, c16.z, c16.w
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
add oT3.x, -r0.y, c30
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
# 18 instructions, 6 texture reads
PARAM c[1] = { { 2, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
TEX R5, fragment.texcoord[0], texture[5], 2D;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R1, fragment.texcoord[1], texture[1], 2D;
TEX R2, fragment.texcoord[1].zwzw, texture[2], 2D;
TEX R4, fragment.texcoord[2].zwzw, texture[4], 2D;
TEX R3, fragment.texcoord[2], texture[3], 2D;
MUL R2, R0.y, R2;
MUL R1, R0.x, R1;
ADD R1, R1, R2;
MUL R2, R0.z, R3;
ADD R6, fragment.color.primary, -R5;
MOV_SAT R7.x, fragment.texcoord[3];
MAD R5, R7.x, R6, R5;
MUL R0, R0.w, R4;
ADD R1, R1, R2;
ADD R0, R1, R0;
MUL R0, R0, R5;
MUL result.color, R0, c[0].xxxy;
END
# 18 instructions, 8 R-regs
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
dcl v0
dcl t3.x
texld r4, t0, s0
texld r5, t0, s5
texld r3, t1, s1
mov r1.y, t1.w
mov r1.x, t1.z
mov r2.xy, r1
mov r0.y, t2.w
mov r0.x, t2.z
add_pp r6, v0, -r5
mov_sat r7.x, t3
mad_pp r5, r7.x, r6, r5
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
mul r1, r0, r5
mov r0.w, c0.y
mov r0.xyz, c0.x
mul_pp r0, r1, r0
mov_pp oC0, r0
"
}

}
#LINE 49

	}
	// Pixel lights
	Pass {
		Tags { "LightMode" = "Pixel" }
		
		Program "" {
// Vertex combos: 17, instructions: 15 to 30
// Fragment combos: 17, instructions: 20 to 46, texreads: 5 to 11
SubProgram "opengl " {
Keywords { "POINT" "SHADOWS_OFF" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 5, [_ObjectSpaceLightPos0]
Matrix 1, [_SpotlightProjectionMatrix0]
Local 6, [_Splat0_ST]
Local 7, [_Splat1_ST]
Local 8, [_Splat2_ST]
Local 9, [_Splat3_ST]
Local 10, [_RealtimeFade]
"!!ARBvp1.0
# 18 instructions
PARAM c[15] = { { 1 },
		program.local[1..10],
		state.matrix.mvp };
TEMP R0;
DP4 R0.x, vertex.position, c[13];
MOV result.position.z, R0.x;
MOV result.fogcoord.x, R0;
MAD R0.x, R0, c[10].z, c[10].w;
MOV result.texcoord[1].xyz, vertex.normal;
ADD result.texcoord[2].xyz, -vertex.position, c[5];
MOV result.texcoord[3].xy, vertex.texcoord[0];
MAD result.texcoord[4].zw, vertex.texcoord[0].xyxy, c[7].xyxy, c[7];
MAD result.texcoord[4].xy, vertex.texcoord[0], c[6], c[6].zwzw;
MAD result.texcoord[5].zw, vertex.texcoord[0].xyxy, c[9].xyxy, c[9];
MAD result.texcoord[5].xy, vertex.texcoord[0], c[8], c[8].zwzw;
DP4 result.position.w, vertex.position, c[14];
DP4 result.position.y, vertex.position, c[12];
DP4 result.position.x, vertex.position, c[11];
DP4 result.texcoord[0].z, vertex.position, c[3];
DP4 result.texcoord[0].y, vertex.position, c[2];
DP4 result.texcoord[0].x, vertex.position, c[1];
ADD result.texcoord[2].w, -R0.x, c[0].x;
END
# 18 instructions, 1 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "POINT" "SHADOWS_OFF" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 8, [_ObjectSpaceLightPos0]
Matrix 0, [_SpotlightProjectionMatrix0]
Local 9, [_Splat0_ST]
Local 10, [_Splat1_ST]
Local 11, [_Splat2_ST]
Local 12, [_Splat3_ST]
Local 13, [_RealtimeFade]
Matrix 4, [glstate_matrix_mvp]
"vs_1_1
def c14, 1.00000000, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord0 v2
dp4 r0.x, v0, c6
mov oPos.z, r0.x
mov oFog, r0.x
mad r0.x, r0, c13.z, c13.w
mov oT1.xyz, v1
add oT2.xyz, -v0, c8
mov oT3.xy, v2
mad oT4.zw, v2.xyxy, c10.xyxy, c10
mad oT4.xy, v2, c9, c9.zwzw
mad oT5.zw, v2.xyxy, c12.xyxy, c12
mad oT5.xy, v2, c11, c11.zwzw
dp4 oPos.w, v0, c7
dp4 oPos.y, v0, c5
dp4 oPos.x, v0, c4
dp4 oT0.z, v0, c2
dp4 oT0.y, v0, c1
dp4 oT0.x, v0, c0
add oT2.w, -r0.x, c14.x
"
}

SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 1, [_ObjectSpaceLightPos0]
Local 2, [_Splat0_ST]
Local 3, [_Splat1_ST]
Local 4, [_Splat2_ST]
Local 5, [_Splat3_ST]
Local 6, [_RealtimeFade]
"!!ARBvp1.0
# 15 instructions
PARAM c[11] = { { 1 },
		program.local[1..6],
		state.matrix.mvp };
TEMP R0;
DP4 R0.x, vertex.position, c[9];
MAD R0.y, R0.x, c[6].z, c[6].w;
MOV result.texcoord[0].xyz, vertex.normal;
MOV result.texcoord[1].xyz, c[1];
MOV result.texcoord[2].xy, vertex.texcoord[0];
MAD result.texcoord[3].zw, vertex.texcoord[0].xyxy, c[3].xyxy, c[3];
MAD result.texcoord[3].xy, vertex.texcoord[0], c[2], c[2].zwzw;
MAD result.texcoord[4].zw, vertex.texcoord[0].xyxy, c[5].xyxy, c[5];
MAD result.texcoord[4].xy, vertex.texcoord[0], c[4], c[4].zwzw;
DP4 result.position.w, vertex.position, c[10];
MOV result.position.z, R0.x;
DP4 result.position.y, vertex.position, c[8];
DP4 result.position.x, vertex.position, c[7];
MOV result.fogcoord.x, R0;
ADD result.texcoord[1].w, -R0.y, c[0].x;
END
# 15 instructions, 1 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 4, [_ObjectSpaceLightPos0]
Local 5, [_Splat0_ST]
Local 6, [_Splat1_ST]
Local 7, [_Splat2_ST]
Local 8, [_Splat3_ST]
Local 9, [_RealtimeFade]
Matrix 0, [glstate_matrix_mvp]
"vs_1_1
def c10, 1.00000000, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord0 v2
dp4 r0.x, v0, c2
mad r0.y, r0.x, c9.z, c9.w
mov oT0.xyz, v1
mov oT1.xyz, c4
mov oT2.xy, v2
mad oT3.zw, v2.xyxy, c6.xyxy, c6
mad oT3.xy, v2, c5, c5.zwzw
mad oT4.zw, v2.xyxy, c8.xyxy, c8
mad oT4.xy, v2, c7, c7.zwzw
dp4 oPos.w, v0, c3
mov oPos.z, r0.x
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
mov oFog, r0.x
add oT1.w, -r0.y, c10.x
"
}

SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_OFF" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 9, [_ObjectSpaceLightPos0]
Matrix 1, [_SpotlightProjectionMatrix0]
Matrix 5, [_SpotlightProjectionMatrixB0]
Local 10, [_Splat0_ST]
Local 11, [_Splat1_ST]
Local 12, [_Splat2_ST]
Local 13, [_Splat3_ST]
Local 14, [_RealtimeFade]
"!!ARBvp1.0
# 20 instructions
PARAM c[19] = { { 1 },
		program.local[1..14],
		state.matrix.mvp };
TEMP R0;
DP4 R0.x, vertex.position, c[1];
DP4 R0.z, vertex.position, c[4];
DP4 R0.y, vertex.position, c[2];
MOV result.texcoord[0].xyz, R0;
DP4 R0.x, vertex.position, c[17];
MOV result.position.z, R0.x;
MOV result.fogcoord.x, R0;
MAD R0.x, R0, c[14].z, c[14].w;
MOV result.texcoord[1].xyz, vertex.normal;
ADD result.texcoord[2].xyz, -vertex.position, c[9];
MOV result.texcoord[3].xy, vertex.texcoord[0];
MAD result.texcoord[4].zw, vertex.texcoord[0].xyxy, c[11].xyxy, c[11];
MAD result.texcoord[4].xy, vertex.texcoord[0], c[10], c[10].zwzw;
MAD result.texcoord[5].zw, vertex.texcoord[0].xyxy, c[13].xyxy, c[13];
MAD result.texcoord[5].xy, vertex.texcoord[0], c[12], c[12].zwzw;
DP4 result.position.w, vertex.position, c[18];
DP4 result.position.y, vertex.position, c[16];
DP4 result.position.x, vertex.position, c[15];
DP4 result.texcoord[0].w, vertex.position, c[7];
ADD result.texcoord[2].w, -R0.x, c[0].x;
END
# 20 instructions, 1 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_OFF" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 12, [_ObjectSpaceLightPos0]
Matrix 0, [_SpotlightProjectionMatrix0]
Matrix 4, [_SpotlightProjectionMatrixB0]
Local 13, [_Splat0_ST]
Local 14, [_Splat1_ST]
Local 15, [_Splat2_ST]
Local 16, [_Splat3_ST]
Local 17, [_RealtimeFade]
Matrix 8, [glstate_matrix_mvp]
"vs_1_1
def c18, 1.00000000, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord0 v2
dp4 r0.x, v0, c0
dp4 r0.z, v0, c3
dp4 r0.y, v0, c1
mov oT0.xyz, r0
dp4 r0.x, v0, c10
mov oPos.z, r0.x
mov oFog, r0.x
mad r0.x, r0, c17.z, c17.w
mov oT1.xyz, v1
add oT2.xyz, -v0, c12
mov oT3.xy, v2
mad oT4.zw, v2.xyxy, c14.xyxy, c14
mad oT4.xy, v2, c13, c13.zwzw
mad oT5.zw, v2.xyxy, c16.xyxy, c16
mad oT5.xy, v2, c15, c15.zwzw
dp4 oPos.w, v0, c11
dp4 oPos.y, v0, c9
dp4 oPos.x, v0, c8
dp4 oT0.w, v0, c6
add oT2.w, -r0.x, c18.x
"
}

SubProgram "opengl " {
Keywords { "POINT_COOKIE" "SHADOWS_OFF" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 5, [_ObjectSpaceLightPos0]
Matrix 1, [_SpotlightProjectionMatrix0]
Local 6, [_Splat0_ST]
Local 7, [_Splat1_ST]
Local 8, [_Splat2_ST]
Local 9, [_Splat3_ST]
Local 10, [_RealtimeFade]
"!!ARBvp1.0
# 18 instructions
PARAM c[15] = { { 1 },
		program.local[1..10],
		state.matrix.mvp };
TEMP R0;
DP4 R0.x, vertex.position, c[13];
MOV result.position.z, R0.x;
MOV result.fogcoord.x, R0;
MAD R0.x, R0, c[10].z, c[10].w;
MOV result.texcoord[1].xyz, vertex.normal;
ADD result.texcoord[2].xyz, -vertex.position, c[5];
MOV result.texcoord[3].xy, vertex.texcoord[0];
MAD result.texcoord[4].zw, vertex.texcoord[0].xyxy, c[7].xyxy, c[7];
MAD result.texcoord[4].xy, vertex.texcoord[0], c[6], c[6].zwzw;
MAD result.texcoord[5].zw, vertex.texcoord[0].xyxy, c[9].xyxy, c[9];
MAD result.texcoord[5].xy, vertex.texcoord[0], c[8], c[8].zwzw;
DP4 result.position.w, vertex.position, c[14];
DP4 result.position.y, vertex.position, c[12];
DP4 result.position.x, vertex.position, c[11];
DP4 result.texcoord[0].z, vertex.position, c[3];
DP4 result.texcoord[0].y, vertex.position, c[2];
DP4 result.texcoord[0].x, vertex.position, c[1];
ADD result.texcoord[2].w, -R0.x, c[0].x;
END
# 18 instructions, 1 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" "SHADOWS_OFF" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 8, [_ObjectSpaceLightPos0]
Matrix 0, [_SpotlightProjectionMatrix0]
Local 9, [_Splat0_ST]
Local 10, [_Splat1_ST]
Local 11, [_Splat2_ST]
Local 12, [_Splat3_ST]
Local 13, [_RealtimeFade]
Matrix 4, [glstate_matrix_mvp]
"vs_1_1
def c14, 1.00000000, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord0 v2
dp4 r0.x, v0, c6
mov oPos.z, r0.x
mov oFog, r0.x
mad r0.x, r0, c13.z, c13.w
mov oT1.xyz, v1
add oT2.xyz, -v0, c8
mov oT3.xy, v2
mad oT4.zw, v2.xyxy, c10.xyxy, c10
mad oT4.xy, v2, c9, c9.zwzw
mad oT5.zw, v2.xyxy, c12.xyxy, c12
mad oT5.xy, v2, c11, c11.zwzw
dp4 oPos.w, v0, c7
dp4 oPos.y, v0, c5
dp4 oPos.x, v0, c4
dp4 oT0.z, v0, c2
dp4 oT0.y, v0, c1
dp4 oT0.x, v0, c0
add oT2.w, -r0.x, c14.x
"
}

SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_OFF" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 5, [_ObjectSpaceLightPos0]
Matrix 1, [_SpotlightProjectionMatrix0]
Local 6, [_Splat0_ST]
Local 7, [_Splat1_ST]
Local 8, [_Splat2_ST]
Local 9, [_Splat3_ST]
Local 10, [_RealtimeFade]
"!!ARBvp1.0
# 17 instructions
PARAM c[15] = { { 1 },
		program.local[1..10],
		state.matrix.mvp };
TEMP R0;
DP4 R0.x, vertex.position, c[13];
MOV result.position.z, R0.x;
MOV result.fogcoord.x, R0;
MAD R0.x, R0, c[10].z, c[10].w;
MOV result.texcoord[1].xyz, vertex.normal;
MOV result.texcoord[2].xyz, c[5];
MOV result.texcoord[3].xy, vertex.texcoord[0];
MAD result.texcoord[4].zw, vertex.texcoord[0].xyxy, c[7].xyxy, c[7];
MAD result.texcoord[4].xy, vertex.texcoord[0], c[6], c[6].zwzw;
MAD result.texcoord[5].zw, vertex.texcoord[0].xyxy, c[9].xyxy, c[9];
MAD result.texcoord[5].xy, vertex.texcoord[0], c[8], c[8].zwzw;
DP4 result.position.w, vertex.position, c[14];
DP4 result.position.y, vertex.position, c[12];
DP4 result.position.x, vertex.position, c[11];
DP4 result.texcoord[0].y, vertex.position, c[2];
DP4 result.texcoord[0].x, vertex.position, c[1];
ADD result.texcoord[2].w, -R0.x, c[0].x;
END
# 17 instructions, 1 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_OFF" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 8, [_ObjectSpaceLightPos0]
Matrix 0, [_SpotlightProjectionMatrix0]
Local 9, [_Splat0_ST]
Local 10, [_Splat1_ST]
Local 11, [_Splat2_ST]
Local 12, [_Splat3_ST]
Local 13, [_RealtimeFade]
Matrix 4, [glstate_matrix_mvp]
"vs_1_1
def c14, 1.00000000, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord0 v2
dp4 r0.x, v0, c6
mov oPos.z, r0.x
mov oFog, r0.x
mad r0.x, r0, c13.z, c13.w
mov oT1.xyz, v1
mov oT2.xyz, c8
mov oT3.xy, v2
mad oT4.zw, v2.xyxy, c10.xyxy, c10
mad oT4.xy, v2, c9, c9.zwzw
mad oT5.zw, v2.xyxy, c12.xyxy, c12
mad oT5.xy, v2, c11, c11.zwzw
dp4 oPos.w, v0, c7
dp4 oPos.y, v0, c5
dp4 oPos.x, v0, c4
dp4 oT0.y, v0, c1
dp4 oT0.x, v0, c0
add oT2.w, -r0.x, c14.x
"
}

SubProgram "opengl " {
Keywords { "POINT_NOATT" "SHADOWS_OFF" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 1, [_ObjectSpaceLightPos0]
Local 2, [_Splat0_ST]
Local 3, [_Splat1_ST]
Local 4, [_Splat2_ST]
Local 5, [_Splat3_ST]
Local 6, [_RealtimeFade]
"!!ARBvp1.0
# 15 instructions
PARAM c[11] = { { 1 },
		program.local[1..6],
		state.matrix.mvp };
TEMP R0;
DP4 R0.x, vertex.position, c[9];
MAD R0.y, R0.x, c[6].z, c[6].w;
MOV result.texcoord[0].xyz, vertex.normal;
ADD result.texcoord[1].xyz, -vertex.position, c[1];
MOV result.texcoord[2].xy, vertex.texcoord[0];
MAD result.texcoord[3].zw, vertex.texcoord[0].xyxy, c[3].xyxy, c[3];
MAD result.texcoord[3].xy, vertex.texcoord[0], c[2], c[2].zwzw;
MAD result.texcoord[4].zw, vertex.texcoord[0].xyxy, c[5].xyxy, c[5];
MAD result.texcoord[4].xy, vertex.texcoord[0], c[4], c[4].zwzw;
DP4 result.position.w, vertex.position, c[10];
MOV result.position.z, R0.x;
DP4 result.position.y, vertex.position, c[8];
DP4 result.position.x, vertex.position, c[7];
MOV result.fogcoord.x, R0;
ADD result.texcoord[1].w, -R0.y, c[0].x;
END
# 15 instructions, 1 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "POINT_NOATT" "SHADOWS_OFF" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 4, [_ObjectSpaceLightPos0]
Local 5, [_Splat0_ST]
Local 6, [_Splat1_ST]
Local 7, [_Splat2_ST]
Local 8, [_Splat3_ST]
Local 9, [_RealtimeFade]
Matrix 0, [glstate_matrix_mvp]
"vs_1_1
def c10, 1.00000000, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord0 v2
dp4 r0.x, v0, c2
mad r0.y, r0.x, c9.z, c9.w
mov oT0.xyz, v1
add oT1.xyz, -v0, c4
mov oT2.xy, v2
mad oT3.zw, v2.xyxy, c6.xyxy, c6
mad oT3.xy, v2, c5, c5.zwzw
mad oT4.zw, v2.xyxy, c8.xyxy, c8
mad oT4.xy, v2, c7, c7.zwzw
dp4 oPos.w, v0, c3
mov oPos.z, r0.x
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
mov oFog, r0.x
add oT1.w, -r0.y, c10.x
"
}

SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_NATIVE" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 9, [_ObjectSpaceLightPos0]
Matrix 1, [_Object2World]
Matrix 5, [_World2Shadow]
Local 10, [_LightShadowData]
Local 11, [_Splat0_ST]
Local 12, [_Splat1_ST]
Local 13, [_Splat2_ST]
Local 14, [_Splat3_ST]
Local 15, [_RealtimeFade]
"!!ARBvp1.0
# 25 instructions
PARAM c[24] = { { 1 },
		program.local[1..15],
		state.matrix.modelview[0],
		state.matrix.mvp };
TEMP R0;
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 result.texcoord[0].w, R0, c[8];
DP4 result.texcoord[0].z, R0, c[7];
DP4 result.texcoord[0].y, R0, c[6];
DP4 result.texcoord[0].x, R0, c[5];
DP4 R0.x, vertex.position, c[22];
DP4 R0.y, vertex.position, c[18];
MOV result.position.z, R0.x;
MOV result.fogcoord.x, R0;
MAD R0.x, R0, c[15].z, c[15].w;
MOV result.texcoord[2].xyz, vertex.normal;
MOV result.texcoord[3].xyz, c[9];
MOV result.texcoord[4].xy, vertex.texcoord[0];
MAD result.texcoord[5].zw, vertex.texcoord[0].xyxy, c[12].xyxy, c[12];
MAD result.texcoord[5].xy, vertex.texcoord[0], c[11], c[11].zwzw;
MAD result.texcoord[6].zw, vertex.texcoord[0].xyxy, c[14].xyxy, c[14];
MAD result.texcoord[6].xy, vertex.texcoord[0], c[13], c[13].zwzw;
DP4 result.position.w, vertex.position, c[23];
DP4 result.position.y, vertex.position, c[21];
DP4 result.position.x, vertex.position, c[20];
MAD result.texcoord[1].x, -R0.y, c[10].z, c[10].w;
ADD result.texcoord[3].w, -R0.x, c[0].x;
END
# 25 instructions, 1 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_NATIVE" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 16, [_ObjectSpaceLightPos0]
Matrix 0, [_Object2World]
Matrix 4, [_World2Shadow]
Local 17, [_LightShadowData]
Local 18, [_Splat0_ST]
Local 19, [_Splat1_ST]
Local 20, [_Splat2_ST]
Local 21, [_Splat3_ST]
Local 22, [_RealtimeFade]
Matrix 8, [glstate_matrix_modelview0]
Matrix 12, [glstate_matrix_mvp]
"vs_1_1
def c23, 1.00000000, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord0 v2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 oT0.w, r0, c7
dp4 oT0.z, r0, c6
dp4 oT0.y, r0, c5
dp4 oT0.x, r0, c4
dp4 r0.x, v0, c14
dp4 r0.y, v0, c10
mov oPos.z, r0.x
mov oFog, r0.x
mad r0.x, r0, c22.z, c22.w
mov oT2.xyz, v1
mov oT3.xyz, c16
mov oT4.xy, v2
mad oT5.zw, v2.xyxy, c19.xyxy, c19
mad oT5.xy, v2, c18, c18.zwzw
mad oT6.zw, v2.xyxy, c21.xyxy, c21
mad oT6.xy, v2, c20, c20.zwzw
dp4 oPos.w, v0, c15
dp4 oPos.y, v0, c13
dp4 oPos.x, v0, c12
mad oT1.x, r0.y, c17.z, c17.w
add oT3.w, -r0.x, c23.x
"
}

SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_NATIVE" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 17, [_ObjectSpaceLightPos0]
Matrix 1, [_Object2World]
Matrix 5, [_World2Shadow]
Local 18, [_LightShadowData]
Matrix 9, [_SpotlightProjectionMatrix0]
Matrix 13, [_SpotlightProjectionMatrixB0]
Local 19, [_Splat0_ST]
Local 20, [_Splat1_ST]
Local 21, [_Splat2_ST]
Local 22, [_Splat3_ST]
Local 23, [_RealtimeFade]
"!!ARBvp1.0
# 30 instructions
PARAM c[32] = { { 1 },
		program.local[1..23],
		state.matrix.modelview[0],
		state.matrix.mvp };
TEMP R0;
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
DP4 R0.w, vertex.position, c[4];
DP4 result.texcoord[1].w, R0, c[8];
DP4 result.texcoord[1].z, R0, c[7];
DP4 result.texcoord[1].y, R0, c[6];
DP4 result.texcoord[1].x, R0, c[5];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
DP4 R0.z, vertex.position, c[12];
MOV result.texcoord[0].xyz, R0;
DP4 R0.x, vertex.position, c[30];
DP4 R0.y, vertex.position, c[26];
MOV result.position.z, R0.x;
MOV result.fogcoord.x, R0;
MAD R0.x, R0, c[23].z, c[23].w;
MOV result.texcoord[3].xyz, vertex.normal;
ADD result.texcoord[4].xyz, -vertex.position, c[17];
MOV result.texcoord[5].xy, vertex.texcoord[0];
MAD result.texcoord[6].zw, vertex.texcoord[0].xyxy, c[20].xyxy, c[20];
MAD result.texcoord[6].xy, vertex.texcoord[0], c[19], c[19].zwzw;
MAD result.texcoord[7].zw, vertex.texcoord[0].xyxy, c[22].xyxy, c[22];
MAD result.texcoord[7].xy, vertex.texcoord[0], c[21], c[21].zwzw;
DP4 result.position.w, vertex.position, c[31];
DP4 result.position.y, vertex.position, c[29];
DP4 result.position.x, vertex.position, c[28];
DP4 result.texcoord[0].w, vertex.position, c[15];
MAD result.texcoord[2].x, -R0.y, c[18].z, c[18].w;
ADD result.texcoord[4].w, -R0.x, c[0].x;
END
# 30 instructions, 1 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_NATIVE" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 24, [_ObjectSpaceLightPos0]
Matrix 0, [_Object2World]
Matrix 4, [_World2Shadow]
Local 25, [_LightShadowData]
Matrix 8, [_SpotlightProjectionMatrix0]
Matrix 12, [_SpotlightProjectionMatrixB0]
Local 26, [_Splat0_ST]
Local 27, [_Splat1_ST]
Local 28, [_Splat2_ST]
Local 29, [_Splat3_ST]
Local 30, [_RealtimeFade]
Matrix 16, [glstate_matrix_modelview0]
Matrix 20, [glstate_matrix_mvp]
"vs_1_1
def c31, 1.00000000, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord0 v2
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
dp4 r0.w, v0, c3
dp4 oT1.w, r0, c7
dp4 oT1.z, r0, c6
dp4 oT1.y, r0, c5
dp4 oT1.x, r0, c4
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
dp4 r0.z, v0, c11
mov oT0.xyz, r0
dp4 r0.x, v0, c22
dp4 r0.y, v0, c18
mov oPos.z, r0.x
mov oFog, r0.x
mad r0.x, r0, c30.z, c30.w
mov oT3.xyz, v1
add oT4.xyz, -v0, c24
mov oT5.xy, v2
mad oT6.zw, v2.xyxy, c27.xyxy, c27
mad oT6.xy, v2, c26, c26.zwzw
mad oT7.zw, v2.xyxy, c29.xyxy, c29
mad oT7.xy, v2, c28, c28.zwzw
dp4 oPos.w, v0, c23
dp4 oPos.y, v0, c21
dp4 oPos.x, v0, c20
dp4 oT0.w, v0, c14
mad oT2.x, r0.y, c25.z, c25.w
add oT4.w, -r0.x, c31.x
"
}

SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_NATIVE" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 13, [_ObjectSpaceLightPos0]
Matrix 1, [_Object2World]
Matrix 5, [_World2Shadow]
Local 14, [_LightShadowData]
Matrix 9, [_SpotlightProjectionMatrix0]
Local 15, [_Splat0_ST]
Local 16, [_Splat1_ST]
Local 17, [_Splat2_ST]
Local 18, [_Splat3_ST]
Local 19, [_RealtimeFade]
"!!ARBvp1.0
# 27 instructions
PARAM c[28] = { { 1 },
		program.local[1..19],
		state.matrix.modelview[0],
		state.matrix.mvp };
TEMP R0;
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 result.texcoord[1].w, R0, c[8];
DP4 result.texcoord[1].z, R0, c[7];
DP4 result.texcoord[1].y, R0, c[6];
DP4 result.texcoord[1].x, R0, c[5];
DP4 R0.x, vertex.position, c[26];
DP4 R0.y, vertex.position, c[22];
MOV result.position.z, R0.x;
MOV result.fogcoord.x, R0;
MAD R0.x, R0, c[19].z, c[19].w;
MOV result.texcoord[3].xyz, vertex.normal;
MOV result.texcoord[4].xyz, c[13];
MOV result.texcoord[5].xy, vertex.texcoord[0];
MAD result.texcoord[6].zw, vertex.texcoord[0].xyxy, c[16].xyxy, c[16];
MAD result.texcoord[6].xy, vertex.texcoord[0], c[15], c[15].zwzw;
MAD result.texcoord[7].zw, vertex.texcoord[0].xyxy, c[18].xyxy, c[18];
MAD result.texcoord[7].xy, vertex.texcoord[0], c[17], c[17].zwzw;
DP4 result.position.w, vertex.position, c[27];
DP4 result.position.y, vertex.position, c[25];
DP4 result.position.x, vertex.position, c[24];
DP4 result.texcoord[0].y, vertex.position, c[10];
DP4 result.texcoord[0].x, vertex.position, c[9];
MAD result.texcoord[2].x, -R0.y, c[14].z, c[14].w;
ADD result.texcoord[4].w, -R0.x, c[0].x;
END
# 27 instructions, 1 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_NATIVE" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 20, [_ObjectSpaceLightPos0]
Matrix 0, [_Object2World]
Matrix 4, [_World2Shadow]
Local 21, [_LightShadowData]
Matrix 8, [_SpotlightProjectionMatrix0]
Local 22, [_Splat0_ST]
Local 23, [_Splat1_ST]
Local 24, [_Splat2_ST]
Local 25, [_Splat3_ST]
Local 26, [_RealtimeFade]
Matrix 12, [glstate_matrix_modelview0]
Matrix 16, [glstate_matrix_mvp]
"vs_1_1
def c27, 1.00000000, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord0 v2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 oT1.w, r0, c7
dp4 oT1.z, r0, c6
dp4 oT1.y, r0, c5
dp4 oT1.x, r0, c4
dp4 r0.x, v0, c18
dp4 r0.y, v0, c14
mov oPos.z, r0.x
mov oFog, r0.x
mad r0.x, r0, c26.z, c26.w
mov oT3.xyz, v1
mov oT4.xyz, c20
mov oT5.xy, v2
mad oT6.zw, v2.xyxy, c23.xyxy, c23
mad oT6.xy, v2, c22, c22.zwzw
mad oT7.zw, v2.xyxy, c25.xyxy, c25
mad oT7.xy, v2, c24, c24.zwzw
dp4 oPos.w, v0, c19
dp4 oPos.y, v0, c17
dp4 oPos.x, v0, c16
dp4 oT0.y, v0, c9
dp4 oT0.x, v0, c8
mad oT2.x, r0.y, c21.z, c21.w
add oT4.w, -r0.x, c27.x
"
}

SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 1, [_ProjectionParams]
Local 2, [_ObjectSpaceLightPos0]
Local 3, [_ShadowOffsets3]
Local 4, [_Splat0_ST]
Local 5, [_Splat1_ST]
Local 6, [_Splat2_ST]
Local 7, [_Splat3_ST]
Local 8, [_RealtimeFade]
"!!ARBvp1.0
# 27 instructions
PARAM c[13] = { { 0, 0.5, 1 },
		program.local[1..8],
		state.matrix.mvp };
TEMP R0;
TEMP R1;
TEMP R2;
DP4 R2.y, vertex.position, c[11];
DP4 R2.x, vertex.position, c[12];
MOV R0.y, c[0];
MOV R0.xzw, c[0].xyxy;
MOV R1.w, R2.x;
MOV R1.z, R2.y;
DP4 R1.y, vertex.position, c[10];
DP4 R1.x, vertex.position, c[9];
MUL R0.y, R0, c[1].x;
DP4 R0.w, R1, R0;
DP4 R0.z, R1, c[0].yxxy;
RCP R0.x, c[3].x;
RCP R0.y, c[3].y;
MUL R0.xy, R0, R0.zwzw;
MUL result.texcoord[0].xy, R0, c[0].y;
MAD R0.x, R2.y, c[8].z, c[8].w;
MOV result.position, R1;
MOV result.texcoord[1].xyz, vertex.normal;
MOV result.texcoord[2].xyz, c[2];
MOV result.texcoord[3].xy, vertex.texcoord[0];
MAD result.texcoord[4].zw, vertex.texcoord[0].xyxy, c[5].xyxy, c[5];
MAD result.texcoord[4].xy, vertex.texcoord[0], c[4], c[4].zwzw;
MAD result.texcoord[5].zw, vertex.texcoord[0].xyxy, c[7].xyxy, c[7];
MAD result.texcoord[5].xy, vertex.texcoord[0], c[6], c[6].zwzw;
MOV result.fogcoord.x, R2.y;
MOV result.texcoord[0].z, R2.x;
ADD result.texcoord[2].w, -R0.x, c[0].z;
END
# 27 instructions, 3 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 4, [_ProjectionParams]
Local 5, [_ObjectSpaceLightPos0]
Local 6, [_Splat0_ST]
Local 7, [_Splat1_ST]
Local 8, [_Splat2_ST]
Local 9, [_Splat3_ST]
Local 10, [_RealtimeFade]
Matrix 0, [glstate_matrix_mvp]
"vs_1_1
def c11, 1.00000000, 0.50000000, 0.00000000, 0
dcl_position v0
dcl_normal v1
dcl_texcoord0 v2
dp4 r2.y, v0, c2
dp4 r2.x, v0, c3
mov r0.y, c4.x
mov r1.w, r2.x
mov r1.z, r2.y
dp4 r1.y, v0, c1
dp4 r1.x, v0, c0
mov r0.xzw, c11.zyzy
mul r0.y, c11, r0
dp4 oT0.y, r1, r0
mad r0.x, r2.y, c10.z, c10.w
mov oPos, r1
dp4 oT0.x, r1, c11.yzzy
mov oT1.xyz, v1
mov oT2.xyz, c5
mov oT3.xy, v2
mad oT4.zw, v2.xyxy, c7.xyxy, c7
mad oT4.xy, v2, c6, c6.zwzw
mad oT5.zw, v2.xyxy, c9.xyxy, c9
mad oT5.xy, v2, c8, c8.zwzw
mov oFog, r2.y
mov oT0.z, r2.x
add oT2.w, -r0.x, c11.x
"
}

SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_SCREEN" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 5, [_ProjectionParams]
Local 6, [_ObjectSpaceLightPos0]
Local 7, [_ShadowOffsets3]
Matrix 1, [_SpotlightProjectionMatrix0]
Local 8, [_Splat0_ST]
Local 9, [_Splat1_ST]
Local 10, [_Splat2_ST]
Local 11, [_Splat3_ST]
Local 12, [_RealtimeFade]
"!!ARBvp1.0
# 29 instructions
PARAM c[17] = { { 0, 0.5, 1 },
		program.local[1..12],
		state.matrix.mvp };
TEMP R0;
TEMP R1;
TEMP R2;
DP4 R2.y, vertex.position, c[15];
DP4 R2.x, vertex.position, c[16];
MOV R0.y, c[0];
MOV R0.xzw, c[0].xyxy;
MOV R1.w, R2.x;
MOV R1.z, R2.y;
DP4 R1.y, vertex.position, c[14];
DP4 R1.x, vertex.position, c[13];
MUL R0.y, R0, c[5].x;
DP4 R0.w, R1, R0;
DP4 R0.z, R1, c[0].yxxy;
RCP R0.x, c[7].x;
RCP R0.y, c[7].y;
MUL R0.xy, R0, R0.zwzw;
MUL result.texcoord[1].xy, R0, c[0].y;
MAD R0.x, R2.y, c[12].z, c[12].w;
MOV result.position, R1;
MOV result.texcoord[2].xyz, vertex.normal;
MOV result.texcoord[3].xyz, c[6];
MOV result.texcoord[4].xy, vertex.texcoord[0];
MAD result.texcoord[5].zw, vertex.texcoord[0].xyxy, c[9].xyxy, c[9];
MAD result.texcoord[5].xy, vertex.texcoord[0], c[8], c[8].zwzw;
MAD result.texcoord[6].zw, vertex.texcoord[0].xyxy, c[11].xyxy, c[11];
MAD result.texcoord[6].xy, vertex.texcoord[0], c[10], c[10].zwzw;
MOV result.fogcoord.x, R2.y;
DP4 result.texcoord[0].y, vertex.position, c[2];
DP4 result.texcoord[0].x, vertex.position, c[1];
MOV result.texcoord[1].z, R2.x;
ADD result.texcoord[3].w, -R0.x, c[0].z;
END
# 29 instructions, 3 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_SCREEN" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 8, [_ProjectionParams]
Local 9, [_ObjectSpaceLightPos0]
Matrix 0, [_SpotlightProjectionMatrix0]
Local 10, [_Splat0_ST]
Local 11, [_Splat1_ST]
Local 12, [_Splat2_ST]
Local 13, [_Splat3_ST]
Local 14, [_RealtimeFade]
Matrix 4, [glstate_matrix_mvp]
"vs_1_1
def c15, 1.00000000, 0.50000000, 0.00000000, 0
dcl_position v0
dcl_normal v1
dcl_texcoord0 v2
dp4 r2.y, v0, c6
dp4 r2.x, v0, c7
mov r0.y, c8.x
mov r1.w, r2.x
mov r1.z, r2.y
dp4 r1.y, v0, c5
dp4 r1.x, v0, c4
mov r0.xzw, c15.zyzy
mul r0.y, c15, r0
dp4 oT1.y, r1, r0
mad r0.x, r2.y, c14.z, c14.w
mov oPos, r1
dp4 oT1.x, r1, c15.yzzy
mov oT2.xyz, v1
mov oT3.xyz, c9
mov oT4.xy, v2
mad oT5.zw, v2.xyxy, c11.xyxy, c11
mad oT5.xy, v2, c10, c10.zwzw
mad oT6.zw, v2.xyxy, c13.xyxy, c13
mad oT6.xy, v2, c12, c12.zwzw
mov oFog, r2.y
dp4 oT0.y, v0, c1
dp4 oT0.x, v0, c0
mov oT1.z, r2.x
add oT3.w, -r0.x, c15.x
"
}

SubProgram "opengl " {
Keywords { "POINT" "SHADOWS_CUBE" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 9, [_ObjectSpaceLightPos0]
Matrix 1, [_Object2World]
Local 10, [_LightPositionRange]
Matrix 5, [_SpotlightProjectionMatrix0]
Local 11, [_Splat0_ST]
Local 12, [_Splat1_ST]
Local 13, [_Splat2_ST]
Local 14, [_Splat3_ST]
Local 15, [_RealtimeFade]
"!!ARBvp1.0
# 22 instructions
PARAM c[20] = { { 1 },
		program.local[1..15],
		state.matrix.mvp };
TEMP R0;
DP4 R0.x, vertex.position, c[1];
DP4 R0.z, vertex.position, c[3];
DP4 R0.y, vertex.position, c[2];
ADD result.texcoord[1].xyz, R0, -c[10];
DP4 R0.x, vertex.position, c[18];
MOV result.position.z, R0.x;
MOV result.fogcoord.x, R0;
MAD R0.x, R0, c[15].z, c[15].w;
MOV result.texcoord[2].xyz, vertex.normal;
ADD result.texcoord[3].xyz, -vertex.position, c[9];
MOV result.texcoord[4].xy, vertex.texcoord[0];
MAD result.texcoord[5].zw, vertex.texcoord[0].xyxy, c[12].xyxy, c[12];
MAD result.texcoord[5].xy, vertex.texcoord[0], c[11], c[11].zwzw;
MAD result.texcoord[6].zw, vertex.texcoord[0].xyxy, c[14].xyxy, c[14];
MAD result.texcoord[6].xy, vertex.texcoord[0], c[13], c[13].zwzw;
DP4 result.position.w, vertex.position, c[19];
DP4 result.position.y, vertex.position, c[17];
DP4 result.position.x, vertex.position, c[16];
DP4 result.texcoord[0].z, vertex.position, c[7];
DP4 result.texcoord[0].y, vertex.position, c[6];
DP4 result.texcoord[0].x, vertex.position, c[5];
ADD result.texcoord[3].w, -R0.x, c[0].x;
END
# 22 instructions, 1 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "POINT" "SHADOWS_CUBE" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 12, [_ObjectSpaceLightPos0]
Matrix 0, [_Object2World]
Local 13, [_LightPositionRange]
Matrix 4, [_SpotlightProjectionMatrix0]
Local 14, [_Splat0_ST]
Local 15, [_Splat1_ST]
Local 16, [_Splat2_ST]
Local 17, [_Splat3_ST]
Local 18, [_RealtimeFade]
Matrix 8, [glstate_matrix_mvp]
"vs_1_1
def c19, 1.00000000, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord0 v2
dp4 r0.x, v0, c0
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
add oT1.xyz, r0, -c13
dp4 r0.x, v0, c10
mov oPos.z, r0.x
mov oFog, r0.x
mad r0.x, r0, c18.z, c18.w
mov oT2.xyz, v1
add oT3.xyz, -v0, c12
mov oT4.xy, v2
mad oT5.zw, v2.xyxy, c15.xyxy, c15
mad oT5.xy, v2, c14, c14.zwzw
mad oT6.zw, v2.xyxy, c17.xyxy, c17
mad oT6.xy, v2, c16, c16.zwzw
dp4 oPos.w, v0, c11
dp4 oPos.y, v0, c9
dp4 oPos.x, v0, c8
dp4 oT0.z, v0, c6
dp4 oT0.y, v0, c5
dp4 oT0.x, v0, c4
add oT3.w, -r0.x, c19.x
"
}

SubProgram "opengl " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 9, [_ObjectSpaceLightPos0]
Matrix 1, [_Object2World]
Local 10, [_LightPositionRange]
Matrix 5, [_SpotlightProjectionMatrix0]
Local 11, [_Splat0_ST]
Local 12, [_Splat1_ST]
Local 13, [_Splat2_ST]
Local 14, [_Splat3_ST]
Local 15, [_RealtimeFade]
"!!ARBvp1.0
# 22 instructions
PARAM c[20] = { { 1 },
		program.local[1..15],
		state.matrix.mvp };
TEMP R0;
DP4 R0.x, vertex.position, c[1];
DP4 R0.z, vertex.position, c[3];
DP4 R0.y, vertex.position, c[2];
ADD result.texcoord[1].xyz, R0, -c[10];
DP4 R0.x, vertex.position, c[18];
MOV result.position.z, R0.x;
MOV result.fogcoord.x, R0;
MAD R0.x, R0, c[15].z, c[15].w;
MOV result.texcoord[2].xyz, vertex.normal;
ADD result.texcoord[3].xyz, -vertex.position, c[9];
MOV result.texcoord[4].xy, vertex.texcoord[0];
MAD result.texcoord[5].zw, vertex.texcoord[0].xyxy, c[12].xyxy, c[12];
MAD result.texcoord[5].xy, vertex.texcoord[0], c[11], c[11].zwzw;
MAD result.texcoord[6].zw, vertex.texcoord[0].xyxy, c[14].xyxy, c[14];
MAD result.texcoord[6].xy, vertex.texcoord[0], c[13], c[13].zwzw;
DP4 result.position.w, vertex.position, c[19];
DP4 result.position.y, vertex.position, c[17];
DP4 result.position.x, vertex.position, c[16];
DP4 result.texcoord[0].z, vertex.position, c[7];
DP4 result.texcoord[0].y, vertex.position, c[6];
DP4 result.texcoord[0].x, vertex.position, c[5];
ADD result.texcoord[3].w, -R0.x, c[0].x;
END
# 22 instructions, 1 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 12, [_ObjectSpaceLightPos0]
Matrix 0, [_Object2World]
Local 13, [_LightPositionRange]
Matrix 4, [_SpotlightProjectionMatrix0]
Local 14, [_Splat0_ST]
Local 15, [_Splat1_ST]
Local 16, [_Splat2_ST]
Local 17, [_Splat3_ST]
Local 18, [_RealtimeFade]
Matrix 8, [glstate_matrix_mvp]
"vs_1_1
def c19, 1.00000000, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord0 v2
dp4 r0.x, v0, c0
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
add oT1.xyz, r0, -c13
dp4 r0.x, v0, c10
mov oPos.z, r0.x
mov oFog, r0.x
mad r0.x, r0, c18.z, c18.w
mov oT2.xyz, v1
add oT3.xyz, -v0, c12
mov oT4.xy, v2
mad oT5.zw, v2.xyxy, c15.xyxy, c15
mad oT5.xy, v2, c14, c14.zwzw
mad oT6.zw, v2.xyxy, c17.xyxy, c17
mad oT6.xy, v2, c16, c16.zwzw
dp4 oPos.w, v0, c11
dp4 oPos.y, v0, c9
dp4 oPos.x, v0, c8
dp4 oT0.z, v0, c6
dp4 oT0.y, v0, c5
dp4 oT0.x, v0, c4
add oT3.w, -r0.x, c19.x
"
}

SubProgram "opengl " {
Keywords { "POINT_NOATT" "SHADOWS_CUBE" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 5, [_ObjectSpaceLightPos0]
Matrix 1, [_Object2World]
Local 6, [_LightPositionRange]
Local 7, [_Splat0_ST]
Local 8, [_Splat1_ST]
Local 9, [_Splat2_ST]
Local 10, [_Splat3_ST]
Local 11, [_RealtimeFade]
"!!ARBvp1.0
# 19 instructions
PARAM c[16] = { { 1 },
		program.local[1..11],
		state.matrix.mvp };
TEMP R0;
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
DP4 R0.z, vertex.position, c[3];
ADD result.texcoord[0].xyz, R0, -c[6];
DP4 R0.x, vertex.position, c[14];
MAD R0.y, R0.x, c[11].z, c[11].w;
MOV result.texcoord[1].xyz, vertex.normal;
ADD result.texcoord[2].xyz, -vertex.position, c[5];
MOV result.texcoord[3].xy, vertex.texcoord[0];
MAD result.texcoord[4].zw, vertex.texcoord[0].xyxy, c[8].xyxy, c[8];
MAD result.texcoord[4].xy, vertex.texcoord[0], c[7], c[7].zwzw;
MAD result.texcoord[5].zw, vertex.texcoord[0].xyxy, c[10].xyxy, c[10];
MAD result.texcoord[5].xy, vertex.texcoord[0], c[9], c[9].zwzw;
DP4 result.position.w, vertex.position, c[15];
MOV result.position.z, R0.x;
DP4 result.position.y, vertex.position, c[13];
DP4 result.position.x, vertex.position, c[12];
MOV result.fogcoord.x, R0;
ADD result.texcoord[2].w, -R0.y, c[0].x;
END
# 19 instructions, 1 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "POINT_NOATT" "SHADOWS_CUBE" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 8, [_ObjectSpaceLightPos0]
Matrix 0, [_Object2World]
Local 9, [_LightPositionRange]
Local 10, [_Splat0_ST]
Local 11, [_Splat1_ST]
Local 12, [_Splat2_ST]
Local 13, [_Splat3_ST]
Local 14, [_RealtimeFade]
Matrix 4, [glstate_matrix_mvp]
"vs_1_1
def c15, 1.00000000, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord0 v2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
dp4 r0.z, v0, c2
add oT0.xyz, r0, -c9
dp4 r0.x, v0, c6
mad r0.y, r0.x, c14.z, c14.w
mov oT1.xyz, v1
add oT2.xyz, -v0, c8
mov oT3.xy, v2
mad oT4.zw, v2.xyxy, c11.xyxy, c11
mad oT4.xy, v2, c10, c10.zwzw
mad oT5.zw, v2.xyxy, c13.xyxy, c13
mad oT5.xy, v2, c12, c12.zwzw
dp4 oPos.w, v0, c7
mov oPos.z, r0.x
dp4 oPos.y, v0, c5
dp4 oPos.x, v0, c4
mov oFog, r0.x
add oT2.w, -r0.y, c15.x
"
}

SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_NATIVE" "SHADOWS_PCF4" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 9, [_ObjectSpaceLightPos0]
Matrix 1, [_Object2World]
Matrix 5, [_World2Shadow]
Local 10, [_LightShadowData]
Local 11, [_Splat0_ST]
Local 12, [_Splat1_ST]
Local 13, [_Splat2_ST]
Local 14, [_Splat3_ST]
Local 15, [_RealtimeFade]
"!!ARBvp1.0
# 25 instructions
PARAM c[24] = { { 1 },
		program.local[1..15],
		state.matrix.modelview[0],
		state.matrix.mvp };
TEMP R0;
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 result.texcoord[0].w, R0, c[8];
DP4 result.texcoord[0].z, R0, c[7];
DP4 result.texcoord[0].y, R0, c[6];
DP4 result.texcoord[0].x, R0, c[5];
DP4 R0.x, vertex.position, c[22];
DP4 R0.y, vertex.position, c[18];
MOV result.position.z, R0.x;
MOV result.fogcoord.x, R0;
MAD R0.x, R0, c[15].z, c[15].w;
MOV result.texcoord[2].xyz, vertex.normal;
MOV result.texcoord[3].xyz, c[9];
MOV result.texcoord[4].xy, vertex.texcoord[0];
MAD result.texcoord[5].zw, vertex.texcoord[0].xyxy, c[12].xyxy, c[12];
MAD result.texcoord[5].xy, vertex.texcoord[0], c[11], c[11].zwzw;
MAD result.texcoord[6].zw, vertex.texcoord[0].xyxy, c[14].xyxy, c[14];
MAD result.texcoord[6].xy, vertex.texcoord[0], c[13], c[13].zwzw;
DP4 result.position.w, vertex.position, c[23];
DP4 result.position.y, vertex.position, c[21];
DP4 result.position.x, vertex.position, c[20];
MAD result.texcoord[1].x, -R0.y, c[10].z, c[10].w;
ADD result.texcoord[3].w, -R0.x, c[0].x;
END
# 25 instructions, 1 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_NATIVE" "SHADOWS_PCF4" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 16, [_ObjectSpaceLightPos0]
Matrix 0, [_Object2World]
Matrix 4, [_World2Shadow]
Local 17, [_LightShadowData]
Local 18, [_Splat0_ST]
Local 19, [_Splat1_ST]
Local 20, [_Splat2_ST]
Local 21, [_Splat3_ST]
Local 22, [_RealtimeFade]
Matrix 8, [glstate_matrix_modelview0]
Matrix 12, [glstate_matrix_mvp]
"vs_1_1
def c23, 1.00000000, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord0 v2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 oT0.w, r0, c7
dp4 oT0.z, r0, c6
dp4 oT0.y, r0, c5
dp4 oT0.x, r0, c4
dp4 r0.x, v0, c14
dp4 r0.y, v0, c10
mov oPos.z, r0.x
mov oFog, r0.x
mad r0.x, r0, c22.z, c22.w
mov oT2.xyz, v1
mov oT3.xyz, c16
mov oT4.xy, v2
mad oT5.zw, v2.xyxy, c19.xyxy, c19
mad oT5.xy, v2, c18, c18.zwzw
mad oT6.zw, v2.xyxy, c21.xyxy, c21
mad oT6.xy, v2, c20, c20.zwzw
dp4 oPos.w, v0, c15
dp4 oPos.y, v0, c13
dp4 oPos.x, v0, c12
mad oT1.x, r0.y, c17.z, c17.w
add oT3.w, -r0.x, c23.x
"
}

SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_NATIVE" "SHADOWS_PCF4" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 17, [_ObjectSpaceLightPos0]
Matrix 1, [_Object2World]
Matrix 5, [_World2Shadow]
Local 18, [_LightShadowData]
Matrix 9, [_SpotlightProjectionMatrix0]
Matrix 13, [_SpotlightProjectionMatrixB0]
Local 19, [_Splat0_ST]
Local 20, [_Splat1_ST]
Local 21, [_Splat2_ST]
Local 22, [_Splat3_ST]
Local 23, [_RealtimeFade]
"!!ARBvp1.0
# 30 instructions
PARAM c[32] = { { 1 },
		program.local[1..23],
		state.matrix.modelview[0],
		state.matrix.mvp };
TEMP R0;
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
DP4 R0.w, vertex.position, c[4];
DP4 result.texcoord[1].w, R0, c[8];
DP4 result.texcoord[1].z, R0, c[7];
DP4 result.texcoord[1].y, R0, c[6];
DP4 result.texcoord[1].x, R0, c[5];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
DP4 R0.z, vertex.position, c[12];
MOV result.texcoord[0].xyz, R0;
DP4 R0.x, vertex.position, c[30];
DP4 R0.y, vertex.position, c[26];
MOV result.position.z, R0.x;
MOV result.fogcoord.x, R0;
MAD R0.x, R0, c[23].z, c[23].w;
MOV result.texcoord[3].xyz, vertex.normal;
ADD result.texcoord[4].xyz, -vertex.position, c[17];
MOV result.texcoord[5].xy, vertex.texcoord[0];
MAD result.texcoord[6].zw, vertex.texcoord[0].xyxy, c[20].xyxy, c[20];
MAD result.texcoord[6].xy, vertex.texcoord[0], c[19], c[19].zwzw;
MAD result.texcoord[7].zw, vertex.texcoord[0].xyxy, c[22].xyxy, c[22];
MAD result.texcoord[7].xy, vertex.texcoord[0], c[21], c[21].zwzw;
DP4 result.position.w, vertex.position, c[31];
DP4 result.position.y, vertex.position, c[29];
DP4 result.position.x, vertex.position, c[28];
DP4 result.texcoord[0].w, vertex.position, c[15];
MAD result.texcoord[2].x, -R0.y, c[18].z, c[18].w;
ADD result.texcoord[4].w, -R0.x, c[0].x;
END
# 30 instructions, 1 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_NATIVE" "SHADOWS_PCF4" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 24, [_ObjectSpaceLightPos0]
Matrix 0, [_Object2World]
Matrix 4, [_World2Shadow]
Local 25, [_LightShadowData]
Matrix 8, [_SpotlightProjectionMatrix0]
Matrix 12, [_SpotlightProjectionMatrixB0]
Local 26, [_Splat0_ST]
Local 27, [_Splat1_ST]
Local 28, [_Splat2_ST]
Local 29, [_Splat3_ST]
Local 30, [_RealtimeFade]
Matrix 16, [glstate_matrix_modelview0]
Matrix 20, [glstate_matrix_mvp]
"vs_1_1
def c31, 1.00000000, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord0 v2
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
dp4 r0.w, v0, c3
dp4 oT1.w, r0, c7
dp4 oT1.z, r0, c6
dp4 oT1.y, r0, c5
dp4 oT1.x, r0, c4
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
dp4 r0.z, v0, c11
mov oT0.xyz, r0
dp4 r0.x, v0, c22
dp4 r0.y, v0, c18
mov oPos.z, r0.x
mov oFog, r0.x
mad r0.x, r0, c30.z, c30.w
mov oT3.xyz, v1
add oT4.xyz, -v0, c24
mov oT5.xy, v2
mad oT6.zw, v2.xyxy, c27.xyxy, c27
mad oT6.xy, v2, c26, c26.zwzw
mad oT7.zw, v2.xyxy, c29.xyxy, c29
mad oT7.xy, v2, c28, c28.zwzw
dp4 oPos.w, v0, c23
dp4 oPos.y, v0, c21
dp4 oPos.x, v0, c20
dp4 oT0.w, v0, c14
mad oT2.x, r0.y, c25.z, c25.w
add oT4.w, -r0.x, c31.x
"
}

SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_NATIVE" "SHADOWS_PCF4" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 13, [_ObjectSpaceLightPos0]
Matrix 1, [_Object2World]
Matrix 5, [_World2Shadow]
Local 14, [_LightShadowData]
Matrix 9, [_SpotlightProjectionMatrix0]
Local 15, [_Splat0_ST]
Local 16, [_Splat1_ST]
Local 17, [_Splat2_ST]
Local 18, [_Splat3_ST]
Local 19, [_RealtimeFade]
"!!ARBvp1.0
# 27 instructions
PARAM c[28] = { { 1 },
		program.local[1..19],
		state.matrix.modelview[0],
		state.matrix.mvp };
TEMP R0;
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 result.texcoord[1].w, R0, c[8];
DP4 result.texcoord[1].z, R0, c[7];
DP4 result.texcoord[1].y, R0, c[6];
DP4 result.texcoord[1].x, R0, c[5];
DP4 R0.x, vertex.position, c[26];
DP4 R0.y, vertex.position, c[22];
MOV result.position.z, R0.x;
MOV result.fogcoord.x, R0;
MAD R0.x, R0, c[19].z, c[19].w;
MOV result.texcoord[3].xyz, vertex.normal;
MOV result.texcoord[4].xyz, c[13];
MOV result.texcoord[5].xy, vertex.texcoord[0];
MAD result.texcoord[6].zw, vertex.texcoord[0].xyxy, c[16].xyxy, c[16];
MAD result.texcoord[6].xy, vertex.texcoord[0], c[15], c[15].zwzw;
MAD result.texcoord[7].zw, vertex.texcoord[0].xyxy, c[18].xyxy, c[18];
MAD result.texcoord[7].xy, vertex.texcoord[0], c[17], c[17].zwzw;
DP4 result.position.w, vertex.position, c[27];
DP4 result.position.y, vertex.position, c[25];
DP4 result.position.x, vertex.position, c[24];
DP4 result.texcoord[0].y, vertex.position, c[10];
DP4 result.texcoord[0].x, vertex.position, c[9];
MAD result.texcoord[2].x, -R0.y, c[14].z, c[14].w;
ADD result.texcoord[4].w, -R0.x, c[0].x;
END
# 27 instructions, 1 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_NATIVE" "SHADOWS_PCF4" }
Bind "vertex", Vertex
Bind "normal", Normal
Bind "texcoord", TexCoord0
Local 20, [_ObjectSpaceLightPos0]
Matrix 0, [_Object2World]
Matrix 4, [_World2Shadow]
Local 21, [_LightShadowData]
Matrix 8, [_SpotlightProjectionMatrix0]
Local 22, [_Splat0_ST]
Local 23, [_Splat1_ST]
Local 24, [_Splat2_ST]
Local 25, [_Splat3_ST]
Local 26, [_RealtimeFade]
Matrix 12, [glstate_matrix_modelview0]
Matrix 16, [glstate_matrix_mvp]
"vs_1_1
def c27, 1.00000000, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord0 v2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 oT1.w, r0, c7
dp4 oT1.z, r0, c6
dp4 oT1.y, r0, c5
dp4 oT1.x, r0, c4
dp4 r0.x, v0, c18
dp4 r0.y, v0, c14
mov oPos.z, r0.x
mov oFog, r0.x
mad r0.x, r0, c26.z, c26.w
mov oT3.xyz, v1
mov oT4.xyz, c20
mov oT5.xy, v2
mad oT6.zw, v2.xyxy, c23.xyxy, c23
mad oT6.xy, v2, c22, c22.zwzw
mad oT7.zw, v2.xyxy, c25.xyxy, c25
mad oT7.xy, v2, c24, c24.zwzw
dp4 oPos.w, v0, c19
dp4 oPos.y, v0, c17
dp4 oPos.x, v0, c16
dp4 oT0.y, v0, c9
dp4 oT0.x, v0, c8
mad oT2.x, r0.y, c21.z, c21.w
add oT4.w, -r0.x, c27.x
"
}

SubProgram "opengl " {
Keywords { "POINT" "SHADOWS_OFF" }
Local 0, [_ModelLightColor0]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_LightTexture0] {3D}
"!!ARBfp1.0
OPTION ARB_fog_exp2;
OPTION ARB_precision_hint_fastest;
# 24 instructions, 6 texture reads
PARAM c[2] = { program.local[0],
		{ 0, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0, fragment.texcoord[3], texture[0], 2D;
TEX R2.xyz, fragment.texcoord[4].zwzw, texture[2], 2D;
TEX R3.xyz, fragment.texcoord[5], texture[3], 2D;
TEX R1.xyz, fragment.texcoord[4], texture[1], 2D;
TEX R1.w, fragment.texcoord[0], texture[5], 3D;
TEX R4.xyz, fragment.texcoord[5].zwzw, texture[4], 2D;
MUL R2.xyz, R0.y, R2;
MUL R3.xyz, R0.z, R3;
MUL R0.xyz, R0.x, R1;
ADD R0.xyz, R0, R2;
MUL R1.xyz, R0.w, R4;
ADD R0.xyz, R0, R3;
DP3 R2.x, fragment.texcoord[2], fragment.texcoord[2];
RSQ R2.x, R2.x;
MOV_SAT R0.w, fragment.texcoord[2];
ADD R0.xyz, R0, R1;
MUL R0.w, R1, R0;
MUL R2.xyz, R2.x, fragment.texcoord[2];
DP3 R1.w, fragment.texcoord[1], R2;
MUL R0.w, R1, R0;
MUL R0.w, R0, c[1].y;
MUL R0.xyz, R0, c[0];
MUL result.color.xyz, R0, R0.w;
MOV result.color.w, c[1].x;
END
# 24 instructions, 5 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "POINT" "SHADOWS_OFF" }
Local 0, [_ModelLightColor0]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_LightTexture0] {3D}
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_volume s5
def c1, 2.00000000, 0.00000000, 0, 0
dcl t0.xyz
dcl t1.xyz
dcl t2
dcl t3.xy
dcl t4
dcl t5
texld r5, t0, s5
texld r4, t5, s3
texld r2, t4, s1
mov r1.y, t5.w
mov r1.x, t5.z
mov r0.y, t4.w
mov r0.x, t4.z
texld r3, r1, s4
texld r0, r0, s2
texld r1, t3, s0
mul r2.xyz, r1.x, r2
mul r0.xyz, r1.y, r0
add_pp r0.xyz, r2, r0
mul r1.xyz, r1.z, r4
add_pp r1.xyz, r0, r1
dp3_pp r0.x, t2, t2
rsq_pp r2.x, r0.x
mul r3.xyz, r1.w, r3
mov_sat r0.x, t2.w
mul_pp r2.xyz, r2.x, t2
add_pp r1.xyz, r1, r3
mul r0.x, r5, r0
dp3_pp r2.x, t1, r2
mul_pp r0.x, r2, r0
mul_pp r0.x, r0, c1
mul r1.xyz, r1, c0
mul r0.xyz, r1, r0.x
mov_pp r0.w, c1.y
mov_pp oC0, r0
"
}

SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" }
Local 0, [_ModelLightColor0]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
"!!ARBfp1.0
OPTION ARB_fog_exp2;
OPTION ARB_precision_hint_fastest;
# 20 instructions, 5 texture reads
PARAM c[2] = { program.local[0],
		{ 0, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0, fragment.texcoord[2], texture[0], 2D;
TEX R3.xyz, fragment.texcoord[4], texture[3], 2D;
TEX R2.xyz, fragment.texcoord[3].zwzw, texture[2], 2D;
TEX R1.xyz, fragment.texcoord[3], texture[1], 2D;
TEX R4.xyz, fragment.texcoord[4].zwzw, texture[4], 2D;
MUL R2.xyz, R0.y, R2;
MUL R3.xyz, R0.z, R3;
MUL R0.xyz, R0.x, R1;
ADD R0.xyz, R0, R2;
MUL R1.xyz, R0.w, R4;
ADD R0.xyz, R0, R3;
MOV R2.xyz, fragment.texcoord[1];
ADD R0.xyz, R0, R1;
MOV_SAT R0.w, fragment.texcoord[1];
DP3 R1.w, fragment.texcoord[0], R2;
MUL R0.w, R1, R0;
MUL R0.w, R0, c[1].y;
MUL R0.xyz, R0, c[0];
MUL result.color.xyz, R0, R0.w;
MOV result.color.w, c[1].x;
END
# 20 instructions, 5 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" }
Local 0, [_ModelLightColor0]
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
def c1, 2.00000000, 0.00000000, 0, 0
dcl t0.xyz
dcl t1
dcl t2.xy
dcl t3
dcl t4
texld r4, t4, s3
texld r2, t3, s1
mov r0.y, t4.w
mov r0.x, t4.z
mov r1.xy, r0
mov r0.y, t3.w
mov r0.x, t3.z
texld r3, r1, s4
texld r0, r0, s2
texld r1, t2, s0
mul r2.xyz, r1.x, r2
mul r0.xyz, r1.y, r0
add_pp r0.xyz, r2, r0
mul r1.xyz, r1.z, r4
add_pp r2.xyz, r0, r1
mov_pp r1.xyz, t1
dp3_pp r1.x, t0, r1
mov_sat r0.x, t1.w
mul_pp r0.x, r1, r0
mul r3.xyz, r1.w, r3
add_pp r1.xyz, r2, r3
mul_pp r0.x, r0, c1
mul r1.xyz, r1, c0
mul r0.xyz, r1, r0.x
mov_pp r0.w, c1.y
mov_pp oC0, r0
"
}

SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_OFF" }
Local 0, [_ModelLightColor0]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_LightTexture0] {2D}
SetTexture [_LightTextureB0] {2D}
"!!ARBfp1.0
OPTION ARB_fog_exp2;
OPTION ARB_precision_hint_fastest;
# 26 instructions, 7 texture reads
PARAM c[2] = { program.local[0],
		{ 0, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R2, fragment.texcoord[3], texture[0], 2D;
TEX R0.xyz, fragment.texcoord[4], texture[1], 2D;
TEX R1.xyz, fragment.texcoord[4].zwzw, texture[2], 2D;
TEX R1.w, fragment.texcoord[0].w, texture[6], 2D;
TXP R0.w, fragment.texcoord[0].xyzz, texture[5], 2D;
TEX R4.xyz, fragment.texcoord[5].zwzw, texture[4], 2D;
TEX R3.xyz, fragment.texcoord[5], texture[3], 2D;
MUL R0.xyz, R2.x, R0;
MUL R1.xyz, R2.y, R1;
ADD R0.xyz, R0, R1;
MUL R1.xyz, R2.z, R3;
ADD R0.xyz, R0, R1;
MUL R1.xyz, R2.w, R4;
DP3 R2.x, fragment.texcoord[2], fragment.texcoord[2];
RSQ R2.x, R2.x;
ADD R0.xyz, R0, R1;
MUL R0.w, R0, R1;
MUL R2.xyz, R2.x, fragment.texcoord[2];
MOV_SAT R2.w, fragment.texcoord[2];
MUL R0.w, R0, R2;
DP3 R1.w, fragment.texcoord[1], R2;
MUL R0.w, R1, R0;
MUL R0.w, R0, c[1].y;
MUL R0.xyz, R0, c[0];
MUL result.color.xyz, R0, R0.w;
MOV result.color.w, c[1].x;
END
# 26 instructions, 5 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_OFF" }
Local 0, [_ModelLightColor0]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_LightTexture0] {2D}
SetTexture [_LightTextureB0] {2D}
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
dcl_2d s6
def c1, 2.00000000, 0.00000000, 0, 0
dcl t0
dcl t1.xyz
dcl t2
dcl t3.xy
dcl t4
dcl t5
texld r4, t5, s3
mov r3.xy, t0.w
mov r0.x, t0
mov r0.w, t0.z
mov r0.y, t0
mov r2.xyw, r0
mov r1.y, t5.w
mov r1.x, t5.z
mov r0.y, t4.w
mov r0.x, t4.z
texld r5, r3, s6
texldp r6, r2, s5
texld r3, r1, s4
texld r0, r0, s2
texld r1, t3, s0
texld r2, t4, s1
mul r2.xyz, r1.x, r2
mul r0.xyz, r1.y, r0
mul r1.xyz, r1.z, r4
add_pp r0.xyz, r2, r0
add_pp r2.xyz, r0, r1
dp3_pp r1.x, t2, t2
rsq_pp r4.x, r1.x
mov_sat r1.x, t2.w
mul r3.xyz, r1.w, r3
mul r0.x, r6.w, r5.w
mul r0.x, r0, r1
mul_pp r4.xyz, r4.x, t2
dp3_pp r1.x, t1, r4
mul_pp r0.x, r1, r0
add_pp r1.xyz, r2, r3
mul_pp r0.x, r0, c1
mul r1.xyz, r1, c0
mul r0.xyz, r1, r0.x
mov_pp r0.w, c1.y
mov_pp oC0, r0
"
}

SubProgram "opengl " {
Keywords { "POINT_COOKIE" "SHADOWS_OFF" }
Local 0, [_ModelLightColor0]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_LightTexture0] {CUBE}
"!!ARBfp1.0
OPTION ARB_fog_exp2;
OPTION ARB_precision_hint_fastest;
# 24 instructions, 6 texture reads
PARAM c[2] = { program.local[0],
		{ 0, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0, fragment.texcoord[3], texture[0], 2D;
TEX R2.xyz, fragment.texcoord[4].zwzw, texture[2], 2D;
TEX R3.xyz, fragment.texcoord[5], texture[3], 2D;
TEX R1.xyz, fragment.texcoord[4], texture[1], 2D;
TEX R1.w, fragment.texcoord[0], texture[5], CUBE;
TEX R4.xyz, fragment.texcoord[5].zwzw, texture[4], 2D;
MUL R2.xyz, R0.y, R2;
MUL R3.xyz, R0.z, R3;
MUL R0.xyz, R0.x, R1;
ADD R0.xyz, R0, R2;
MUL R1.xyz, R0.w, R4;
ADD R0.xyz, R0, R3;
DP3 R2.x, fragment.texcoord[2], fragment.texcoord[2];
RSQ R2.x, R2.x;
MOV_SAT R0.w, fragment.texcoord[2];
ADD R0.xyz, R0, R1;
MUL R0.w, R1, R0;
MUL R2.xyz, R2.x, fragment.texcoord[2];
DP3 R1.w, fragment.texcoord[1], R2;
MUL R0.w, R1, R0;
MUL R0.w, R0, c[1].y;
MUL R0.xyz, R0, c[0];
MUL result.color.xyz, R0, R0.w;
MOV result.color.w, c[1].x;
END
# 24 instructions, 5 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" "SHADOWS_OFF" }
Local 0, [_ModelLightColor0]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_LightTexture0] {CUBE}
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_cube s5
def c1, 2.00000000, 0.00000000, 0, 0
dcl t0.xyz
dcl t1.xyz
dcl t2
dcl t3.xy
dcl t4
dcl t5
texld r5, t0, s5
texld r4, t5, s3
texld r2, t4, s1
mov r1.y, t5.w
mov r1.x, t5.z
mov r0.y, t4.w
mov r0.x, t4.z
texld r3, r1, s4
texld r0, r0, s2
texld r1, t3, s0
mul r2.xyz, r1.x, r2
mul r0.xyz, r1.y, r0
add_pp r0.xyz, r2, r0
mul r1.xyz, r1.z, r4
add_pp r1.xyz, r0, r1
dp3_pp r0.x, t2, t2
rsq_pp r2.x, r0.x
mul r3.xyz, r1.w, r3
mov_sat r0.x, t2.w
mul_pp r2.xyz, r2.x, t2
add_pp r1.xyz, r1, r3
mul r0.x, r5.w, r0
dp3_pp r2.x, t1, r2
mul_pp r0.x, r2, r0
mul_pp r0.x, r0, c1
mul r1.xyz, r1, c0
mul r0.xyz, r1, r0.x
mov_pp r0.w, c1.y
mov_pp oC0, r0
"
}

SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_OFF" }
Local 0, [_ModelLightColor0]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_LightTexture0] {2D}
"!!ARBfp1.0
OPTION ARB_fog_exp2;
OPTION ARB_precision_hint_fastest;
# 22 instructions, 6 texture reads
PARAM c[2] = { program.local[0],
		{ 0, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0, fragment.texcoord[3], texture[0], 2D;
TEX R2.xyz, fragment.texcoord[4].zwzw, texture[2], 2D;
TEX R3.xyz, fragment.texcoord[5], texture[3], 2D;
TEX R1.xyz, fragment.texcoord[4], texture[1], 2D;
TEX R1.w, fragment.texcoord[0], texture[5], 2D;
TEX R4.xyz, fragment.texcoord[5].zwzw, texture[4], 2D;
MUL R2.xyz, R0.y, R2;
MUL R3.xyz, R0.z, R3;
MUL R0.xyz, R0.x, R1;
ADD R0.xyz, R0, R2;
MUL R1.xyz, R0.w, R4;
ADD R0.xyz, R0, R3;
MOV_SAT R0.w, fragment.texcoord[2];
ADD R0.xyz, R0, R1;
MUL R0.w, R1, R0;
MOV R2.xyz, fragment.texcoord[2];
DP3 R1.w, fragment.texcoord[1], R2;
MUL R0.w, R1, R0;
MUL R0.w, R0, c[1].y;
MUL R0.xyz, R0, c[0];
MUL result.color.xyz, R0, R0.w;
MOV result.color.w, c[1].x;
END
# 22 instructions, 5 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_OFF" }
Local 0, [_ModelLightColor0]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_LightTexture0] {2D}
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
def c1, 2.00000000, 0.00000000, 0, 0
dcl t0.xy
dcl t1.xyz
dcl t2
dcl t3.xy
dcl t4
dcl t5
texld r5, t0, s5
texld r4, t5, s3
texld r2, t4, s1
mov r1.y, t5.w
mov r1.x, t5.z
mov r0.y, t4.w
mov r0.x, t4.z
texld r3, r1, s4
texld r0, r0, s2
texld r1, t3, s0
mul r2.xyz, r1.x, r2
mul r0.xyz, r1.y, r0
add_pp r0.xyz, r2, r0
mul r2.xyz, r1.w, r3
mul r1.xyz, r1.z, r4
add_pp r1.xyz, r0, r1
mov_sat r0.x, t2.w
mov_pp r3.xyz, t2
add_pp r1.xyz, r1, r2
mul r0.x, r5.w, r0
dp3_pp r3.x, t1, r3
mul_pp r0.x, r3, r0
mul_pp r0.x, r0, c1
mul r1.xyz, r1, c0
mul r0.xyz, r1, r0.x
mov_pp r0.w, c1.y
mov_pp oC0, r0
"
}

SubProgram "opengl " {
Keywords { "POINT_NOATT" "SHADOWS_OFF" }
Local 0, [_ModelLightColor0]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
"!!ARBfp1.0
OPTION ARB_fog_exp2;
OPTION ARB_precision_hint_fastest;
# 22 instructions, 5 texture reads
PARAM c[2] = { program.local[0],
		{ 0, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0, fragment.texcoord[2], texture[0], 2D;
TEX R2.xyz, fragment.texcoord[3].zwzw, texture[2], 2D;
TEX R1.xyz, fragment.texcoord[3], texture[1], 2D;
TEX R4.xyz, fragment.texcoord[4].zwzw, texture[4], 2D;
TEX R3.xyz, fragment.texcoord[4], texture[3], 2D;
DP3 R1.w, fragment.texcoord[1], fragment.texcoord[1];
MUL R2.xyz, R0.y, R2;
MUL R1.xyz, R0.x, R1;
ADD R1.xyz, R1, R2;
RSQ R1.w, R1.w;
MUL R0.xyz, R0.z, R3;
ADD R0.xyz, R1, R0;
MUL R1.xyz, R0.w, R4;
MUL R2.xyz, R1.w, fragment.texcoord[1];
ADD R0.xyz, R0, R1;
MOV_SAT R0.w, fragment.texcoord[1];
DP3 R1.w, fragment.texcoord[0], R2;
MUL R0.w, R1, R0;
MUL R0.w, R0, c[1].y;
MUL R0.xyz, R0, c[0];
MUL result.color.xyz, R0, R0.w;
MOV result.color.w, c[1].x;
END
# 22 instructions, 5 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "POINT_NOATT" "SHADOWS_OFF" }
Local 0, [_ModelLightColor0]
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
def c1, 2.00000000, 0.00000000, 0, 0
dcl t0.xyz
dcl t1
dcl t2.xy
dcl t3
dcl t4
texld r3, t3, s1
texld r4, t2, s0
mov r1.y, t3.w
mov r1.x, t3.z
mul r3.xyz, r4.x, r3
mov r0.y, t4.w
mov r0.x, t4.z
texld r2, r1, s2
texld r0, r0, s4
texld r1, t4, s3
mul r2.xyz, r4.y, r2
add_pp r2.xyz, r3, r2
mul r1.xyz, r4.z, r1
add_pp r2.xyz, r2, r1
mul r3.xyz, r4.w, r0
dp3_pp r1.x, t1, t1
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, t1
dp3_pp r1.x, t0, r1
mov_sat r0.x, t1.w
mul_pp r0.x, r1, r0
add_pp r1.xyz, r2, r3
mul_pp r0.x, r0, c1
mul r1.xyz, r1, c0
mul r0.xyz, r1, r0.x
mov_pp r0.w, c1.y
mov_pp oC0, r0
"
}

SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_NATIVE" }
Local 0, [_ModelLightColor0]
Local 1, [_LightShadowData]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {2D}
"!!ARBfp1.0
OPTION ARB_fog_exp2;
OPTION ARB_precision_hint_fastest;
# 28 instructions, 6 texture reads
PARAM c[3] = { program.local[0..1],
		{ 0, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R0, fragment.texcoord[4], texture[0], 2D;
TEX R2.xyz, fragment.texcoord[5].zwzw, texture[2], 2D;
TEX R3.xyz, fragment.texcoord[6], texture[3], 2D;
TEX R1.xyz, fragment.texcoord[5], texture[1], 2D;
TEX R4.xyz, fragment.texcoord[6].zwzw, texture[4], 2D;
TXP R5.x, fragment.texcoord[0], texture[5], 2D;
RCP R1.w, fragment.texcoord[0].w;
MUL R2.xyz, R0.y, R2;
MUL R3.xyz, R0.z, R3;
MUL R0.xyz, R0.x, R1;
ADD R0.xyz, R0, R2;
MUL R1.xyz, R0.w, R4;
ADD R0.xyz, R0, R3;
ADD R0.xyz, R0, R1;
MAD R1.w, -fragment.texcoord[0].z, R1, R5.x;
MOV R0.w, c[2].y;
CMP R0.w, R1, c[1].x, R0;
MOV_SAT R1.w, fragment.texcoord[1].x;
ADD_SAT R0.w, R0, R1;
MOV R2.xyz, fragment.texcoord[3];
MOV_SAT R2.w, fragment.texcoord[3];
MUL R0.w, R0, R2;
DP3 R1.w, fragment.texcoord[2], R2;
MUL R0.w, R1, R0;
MUL R0.w, R0, c[2].z;
MUL R0.xyz, R0, c[0];
MUL result.color.xyz, R0, R0.w;
MOV result.color.w, c[2].x;
END
# 28 instructions, 6 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_NATIVE" }
Local 0, [_ModelLightColor0]
Local 1, [_LightShadowData]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {2D}
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
def c2, 1.00000000, 2.00000000, 0.00000000, 0
dcl t0
dcl t1.x
dcl t2.xyz
dcl t3
dcl t4.xy
dcl t5
dcl t6
texldp r5, t0, s5
texld r4, t6, s3
texld r2, t5, s1
mov r1.y, t6.w
mov r1.x, t6.z
mov r0.y, t5.w
mov r0.x, t5.z
texld r3, r1, s4
texld r0, r0, s2
texld r1, t4, s0
mul r2.xyz, r1.x, r2
mul r0.xyz, r1.y, r0
mul r1.xyz, r1.z, r4
add_pp r0.xyz, r2, r0
add_pp r2.xyz, r0, r1
rcp r0.x, t0.w
mad r4.x, -t0.z, r0, r5
mov r1.x, c1
cmp r1.x, r4, c2, r1
mov_pp_sat r0.x, t1
add_sat r0.x, r1, r0
mov_sat r1.x, t3.w
mul r0.x, r0, r1
mov_pp r4.xyz, t3
dp3_pp r1.x, t2, r4
mul_pp r0.x, r1, r0
mul r3.xyz, r1.w, r3
add_pp r1.xyz, r2, r3
mul_pp r0.x, r0, c2.y
mul r1.xyz, r1, c0
mul r0.xyz, r1, r0.x
mov_pp r0.w, c2.z
mov_pp oC0, r0
"
}

SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_NATIVE" }
Local 0, [_ModelLightColor0]
Local 1, [_LightShadowData]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {2D}
SetTexture [_LightTexture0] {2D}
SetTexture [_LightTextureB0] {2D}
"!!ARBfp1.0
OPTION ARB_fog_exp2;
OPTION ARB_precision_hint_fastest;
# 34 instructions, 8 texture reads
PARAM c[3] = { program.local[0..1],
		{ 0, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R2, fragment.texcoord[5], texture[0], 2D;
TEX R1.xyz, fragment.texcoord[6], texture[1], 2D;
TEX R3.xyz, fragment.texcoord[6].zwzw, texture[2], 2D;
TXP R0.x, fragment.texcoord[1], texture[5], 2D;
TXP R0.w, fragment.texcoord[0].xyzz, texture[6], 2D;
TEX R5.xyz, fragment.texcoord[7].zwzw, texture[4], 2D;
TEX R4.xyz, fragment.texcoord[7], texture[3], 2D;
TEX R1.w, fragment.texcoord[0].w, texture[7], 2D;
DP3 R0.y, fragment.texcoord[4], fragment.texcoord[4];
RCP R0.z, fragment.texcoord[1].w;
MAD R0.z, -fragment.texcoord[1], R0, R0.x;
MOV R0.x, c[2].y;
CMP R0.x, R0.z, c[1], R0;
MUL R3.xyz, R2.y, R3;
MUL R1.xyz, R2.x, R1;
ADD R1.xyz, R1, R3;
MUL R2.xyz, R2.z, R4;
ADD R1.xyz, R1, R2;
RSQ R0.y, R0.y;
MUL R3.xyz, R0.y, fragment.texcoord[4];
MUL R0.y, R0.w, R1.w;
MUL R2.xyz, R2.w, R5;
MOV_SAT R0.w, fragment.texcoord[2].x;
ADD_SAT R0.x, R0, R0.w;
MUL R0.x, R0.y, R0;
MOV_SAT R0.z, fragment.texcoord[4].w;
ADD R1.xyz, R1, R2;
MUL R0.x, R0, R0.z;
DP3 R0.y, fragment.texcoord[3], R3;
MUL R0.x, R0.y, R0;
MUL R0.x, R0, c[2].z;
MUL R1.xyz, R1, c[0];
MUL result.color.xyz, R1, R0.x;
MOV result.color.w, c[2].x;
END
# 34 instructions, 6 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_NATIVE" }
Local 0, [_ModelLightColor0]
Local 1, [_LightShadowData]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {2D}
SetTexture [_LightTexture0] {2D}
SetTexture [_LightTextureB0] {2D}
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
dcl_2d s6
dcl_2d s7
def c2, 1.00000000, 2.00000000, 0.00000000, 0
dcl t0
dcl t1
dcl t2.x
dcl t3.xyz
dcl t4
dcl t5.xy
dcl t6
dcl t7
texldp r7, t1, s5
texld r4, t7, s3
mov r3.xy, t0.w
mov r0.x, t0
mov r0.w, t0.z
mov r0.y, t0
mov r2.xyw, r0
mov r1.y, t7.w
mov r1.x, t7.z
mov r0.y, t6.w
mov r0.x, t6.z
texld r5, r3, s7
texldp r6, r2, s6
texld r3, r1, s4
texld r0, r0, s2
texld r1, t5, s0
texld r2, t6, s1
mul r2.xyz, r1.x, r2
mul r0.xyz, r1.y, r0
mul r1.xyz, r1.z, r4
add_pp r0.xyz, r2, r0
add_pp r2.xyz, r0, r1
rcp r1.x, t1.w
mad r5.x, -t1.z, r1, r7
mov r4.x, c1
mov_pp_sat r1.x, t2
cmp r4.x, r5, c2, r4
add_sat r4.x, r4, r1
mul r0.x, r6.w, r5.w
mul r0.x, r0, r4
dp3_pp r1.x, t4, t4
rsq_pp r4.x, r1.x
mov_sat r1.x, t4.w
mul r0.x, r0, r1
mul_pp r4.xyz, r4.x, t4
dp3_pp r1.x, t3, r4
mul_pp r0.x, r1, r0
mul r3.xyz, r1.w, r3
add_pp r1.xyz, r2, r3
mul_pp r0.x, r0, c2.y
mul r1.xyz, r1, c0
mul r0.xyz, r1, r0.x
mov_pp r0.w, c2.z
mov_pp oC0, r0
"
}

SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_NATIVE" }
Local 0, [_ModelLightColor0]
Local 1, [_LightShadowData]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {2D}
SetTexture [_LightTexture0] {2D}
"!!ARBfp1.0
OPTION ARB_fog_exp2;
OPTION ARB_precision_hint_fastest;
# 30 instructions, 7 texture reads
PARAM c[3] = { program.local[0..1],
		{ 0, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R1, fragment.texcoord[5], texture[0], 2D;
TEX R3.xyz, fragment.texcoord[6].zwzw, texture[2], 2D;
TEX R4.xyz, fragment.texcoord[7], texture[3], 2D;
TEX R2.xyz, fragment.texcoord[6], texture[1], 2D;
TXP R0.x, fragment.texcoord[1], texture[5], 2D;
TEX R5.xyz, fragment.texcoord[7].zwzw, texture[4], 2D;
TEX R0.w, fragment.texcoord[0], texture[6], 2D;
RCP R0.y, fragment.texcoord[1].w;
MAD R0.y, -fragment.texcoord[1].z, R0, R0.x;
MOV R0.x, c[2].y;
CMP R0.x, R0.y, c[1], R0;
MOV_SAT R0.z, fragment.texcoord[2].x;
ADD_SAT R0.x, R0, R0.z;
MUL R3.xyz, R1.y, R3;
MUL R4.xyz, R1.z, R4;
MUL R1.xyz, R1.x, R2;
ADD R1.xyz, R1, R3;
MOV_SAT R0.y, fragment.texcoord[4].w;
MUL R0.x, R0.w, R0;
MUL R0.x, R0, R0.y;
MOV R3.xyz, fragment.texcoord[4];
DP3 R0.y, fragment.texcoord[3], R3;
MUL R0.x, R0.y, R0;
ADD R1.xyz, R1, R4;
MUL R2.xyz, R1.w, R5;
ADD R1.xyz, R1, R2;
MUL R0.x, R0, c[2].z;
MUL R1.xyz, R1, c[0];
MUL result.color.xyz, R1, R0.x;
MOV result.color.w, c[2].x;
END
# 30 instructions, 6 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_NATIVE" }
Local 0, [_ModelLightColor0]
Local 1, [_LightShadowData]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {2D}
SetTexture [_LightTexture0] {2D}
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
dcl_2d s6
def c2, 1.00000000, 2.00000000, 0.00000000, 0
dcl t0.xy
dcl t1
dcl t2.x
dcl t3.xyz
dcl t4
dcl t5.xy
dcl t6
dcl t7
texld r5, t0, s6
texldp r6, t1, s5
texld r4, t7, s3
texld r2, t6, s1
mov r1.y, t7.w
mov r1.x, t7.z
mov r0.y, t6.w
mov r0.x, t6.z
texld r3, r1, s4
texld r0, r0, s2
texld r1, t5, s0
mul r2.xyz, r1.x, r2
mul r0.xyz, r1.y, r0
mul r1.xyz, r1.z, r4
add_pp r0.xyz, r2, r0
add_pp r2.xyz, r0, r1
mul r4.xyz, r1.w, r3
rcp r0.x, t1.w
mad r3.x, -t1.z, r0, r6
mov r1.x, c1
cmp r1.x, r3, c2, r1
mov_pp_sat r0.x, t2
add_sat r0.x, r1, r0
mov_sat r1.x, t4.w
mul r0.x, r5.w, r0
mul r0.x, r0, r1
mov_pp r3.xyz, t4
dp3_pp r1.x, t3, r3
mul_pp r0.x, r1, r0
add_pp r1.xyz, r2, r4
mul_pp r0.x, r0, c2.y
mul r1.xyz, r1, c0
mul r0.xyz, r1, r0.x
mov_pp r0.w, c2.z
mov_pp oC0, r0
"
}

SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
Local 0, [_ModelLightColor0]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {RECT}
"!!ARBfp1.0
OPTION ARB_fog_exp2;
OPTION ARB_precision_hint_fastest;
# 22 instructions, 6 texture reads
PARAM c[2] = { program.local[0],
		{ 0, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R0, fragment.texcoord[3], texture[0], 2D;
TEX R2.xyz, fragment.texcoord[4].zwzw, texture[2], 2D;
TEX R3.xyz, fragment.texcoord[5], texture[3], 2D;
TEX R1.xyz, fragment.texcoord[4], texture[1], 2D;
TEX R4.xyz, fragment.texcoord[5].zwzw, texture[4], 2D;
TXP R5.x, fragment.texcoord[0].xyzz, texture[5], RECT;
MUL R2.xyz, R0.y, R2;
MUL R3.xyz, R0.z, R3;
MUL R0.xyz, R0.x, R1;
ADD R0.xyz, R0, R2;
MUL R1.xyz, R0.w, R4;
ADD R0.xyz, R0, R3;
MOV_SAT R0.w, fragment.texcoord[2];
MOV R2.xyz, fragment.texcoord[2];
ADD R0.xyz, R0, R1;
MUL R0.w, R5.x, R0;
DP3 R1.w, fragment.texcoord[1], R2;
MUL R0.w, R1, R0;
MUL R0.w, R0, c[1].y;
MUL R0.xyz, R0, c[0];
MUL result.color.xyz, R0, R0.w;
MOV result.color.w, c[1].x;
END
# 22 instructions, 6 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
Local 0, [_ModelLightColor0]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {RECT}
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
def c1, 2.00000000, 0.00000000, 0, 0
dcl t0.xyz
dcl t1.xyz
dcl t2
dcl t3.xy
dcl t4
dcl t5
texld r4, t5, s3
mov r0.x, t0
mov r0.w, t0.z
mov r0.y, t0
mov r2.xyw, r0
mov r1.y, t5.w
mov r1.x, t5.z
mov r0.y, t4.w
mov r0.x, t4.z
texldp r5, r2, s5
texld r3, r1, s4
texld r0, r0, s2
texld r1, t3, s0
texld r2, t4, s1
mul r2.xyz, r1.x, r2
mul r0.xyz, r1.y, r0
add_pp r0.xyz, r2, r0
mul r2.xyz, r1.w, r3
mul r1.xyz, r1.z, r4
add_pp r1.xyz, r0, r1
mov_pp r3.xyz, t2
add_pp r1.xyz, r1, r2
mov_sat r0.x, t2.w
mul r0.x, r5, r0
dp3_pp r3.x, t1, r3
mul_pp r0.x, r3, r0
mul_pp r0.x, r0, c1
mul r1.xyz, r1, c0
mul r0.xyz, r1, r0.x
mov_pp r0.w, c1.y
mov_pp oC0, r0
"
}

SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_SCREEN" }
Local 0, [_ModelLightColor0]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {RECT}
SetTexture [_LightTexture0] {2D}
"!!ARBfp1.0
OPTION ARB_fog_exp2;
OPTION ARB_precision_hint_fastest;
# 24 instructions, 7 texture reads
PARAM c[2] = { program.local[0],
		{ 0, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R1, fragment.texcoord[4], texture[0], 2D;
TEX R3.xyz, fragment.texcoord[5].zwzw, texture[2], 2D;
TEX R4.xyz, fragment.texcoord[6], texture[3], 2D;
TEX R2.xyz, fragment.texcoord[5], texture[1], 2D;
TEX R5.xyz, fragment.texcoord[6].zwzw, texture[4], 2D;
TEX R0.w, fragment.texcoord[0], texture[6], 2D;
TXP R0.x, fragment.texcoord[1].xyzz, texture[5], RECT;
MUL R3.xyz, R1.y, R3;
MUL R4.xyz, R1.z, R4;
MUL R1.xyz, R1.x, R2;
ADD R1.xyz, R1, R3;
MOV_SAT R0.y, fragment.texcoord[3].w;
MUL R0.x, R0.w, R0;
MUL R0.x, R0, R0.y;
MOV R3.xyz, fragment.texcoord[3];
DP3 R0.y, fragment.texcoord[2], R3;
MUL R0.x, R0.y, R0;
ADD R1.xyz, R1, R4;
MUL R2.xyz, R1.w, R5;
ADD R1.xyz, R1, R2;
MUL R0.x, R0, c[1].y;
MUL R1.xyz, R1, c[0];
MUL result.color.xyz, R1, R0.x;
MOV result.color.w, c[1].x;
END
# 24 instructions, 6 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_SCREEN" }
Local 0, [_ModelLightColor0]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {RECT}
SetTexture [_LightTexture0] {2D}
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
dcl_2d s6
def c1, 2.00000000, 0.00000000, 0, 0
dcl t0.xy
dcl t1.xyz
dcl t2.xyz
dcl t3
dcl t4.xy
dcl t5
dcl t6
texld r5, t0, s6
texld r4, t6, s3
mov r0.x, t1
mov r0.w, t1.z
mov r0.y, t1
mov r2.xyw, r0
mov r1.y, t6.w
mov r1.x, t6.z
mov r0.y, t5.w
mov r0.x, t5.z
texldp r6, r2, s5
texld r3, r1, s4
texld r0, r0, s2
texld r1, t4, s0
texld r2, t5, s1
mul r2.xyz, r1.x, r2
mul r0.xyz, r1.y, r0
mul r1.xyz, r1.z, r4
add_pp r0.xyz, r2, r0
add_pp r2.xyz, r0, r1
mov_sat r1.x, t3.w
mul r0.x, r5.w, r6
mul r0.x, r0, r1
mov_pp r4.xyz, t3
dp3_pp r1.x, t2, r4
mul_pp r0.x, r1, r0
mul r3.xyz, r1.w, r3
add_pp r1.xyz, r2, r3
mul_pp r0.x, r0, c1
mul r1.xyz, r1, c0
mul r0.xyz, r1, r0.x
mov_pp r0.w, c1.y
mov_pp oC0, r0
"
}

SubProgram "opengl " {
Keywords { "POINT" "SHADOWS_CUBE" }
Local 0, [_ModelLightColor0]
Local 1, [_LightPositionRange]
Local 2, [_RGBADecodeDot]
Local 3, [_LightShadowData]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {CUBE}
SetTexture [_LightTexture0] {3D}
"!!ARBfp1.0
OPTION ARB_fog_exp2;
OPTION ARB_precision_hint_fastest;
# 34 instructions, 7 texture reads
PARAM c[5] = { program.local[0..3],
		{ 0, 0.97000003, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R1, fragment.texcoord[1], texture[5], CUBE;
TEX R0, fragment.texcoord[4], texture[0], 2D;
TEX R3.xyz, fragment.texcoord[5].zwzw, texture[2], 2D;
TEX R4.xyz, fragment.texcoord[6], texture[3], 2D;
TEX R2.xyz, fragment.texcoord[5], texture[1], 2D;
TEX R5.xyz, fragment.texcoord[6].zwzw, texture[4], 2D;
TEX R2.w, fragment.texcoord[0], texture[6], 3D;
DP4 R1.x, R1, c[2];
MUL R3.xyz, R0.y, R3;
MUL R4.xyz, R0.z, R4;
MUL R0.xyz, R0.x, R2;
ADD R0.xyz, R0, R3;
MUL R2.xyz, R0.w, R5;
ADD R0.xyz, R0, R4;
DP3 R3.x, fragment.texcoord[1], fragment.texcoord[1];
RSQ R0.w, R3.x;
RCP R1.y, R0.w;
MUL R1.y, R1, c[1].w;
ADD R0.xyz, R0, R2;
MAD R1.x, -R1.y, c[4].y, R1;
MOV R0.w, c[4].z;
CMP R0.w, R1.x, c[3].x, R0;
DP3 R1.x, fragment.texcoord[3], fragment.texcoord[3];
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, fragment.texcoord[3];
MUL R0.w, R2, R0;
MOV_SAT R1.w, fragment.texcoord[3];
MUL R0.w, R0, R1;
DP3 R1.x, fragment.texcoord[2], R1;
MUL R0.w, R1.x, R0;
MUL R0.w, R0, c[4];
MUL R0.xyz, R0, c[0];
MUL result.color.xyz, R0, R0.w;
MOV result.color.w, c[4].x;
END
# 34 instructions, 6 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "POINT" "SHADOWS_CUBE" }
Local 0, [_ModelLightColor0]
Local 1, [_LightPositionRange]
Local 2, [_RGBADecodeDot]
Local 3, [_LightShadowData]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {CUBE}
SetTexture [_LightTexture0] {3D}
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_cube s5
dcl_volume s6
def c4, 0.97000003, 1.00000000, 2.00000000, 0.00000000
dcl t0.xyz
dcl t1.xyz
dcl t2.xyz
dcl t3
dcl t4.xy
dcl t5
dcl t6
texld r6, t0, s6
texld r5, t6, s3
texld r3, t5, s1
mov r0.y, t5.w
mov r0.x, t5.z
mov r1.xy, r0
mov r0.y, t6.w
mov r0.x, t6.z
mov r2.xy, r0
texld r4, r2, s4
texld r0, t1, s5
texld r2, t4, s0
texld r1, r1, s2
dp4 r0.x, r0, c2
mul r3.xyz, r2.x, r3
mul r1.xyz, r2.y, r1
add_pp r1.xyz, r3, r1
mul r2.xyz, r2.z, r5
add_pp r2.xyz, r1, r2
dp3 r1.x, t1, t1
mul r3.xyz, r2.w, r4
rsq r1.x, r1.x
rcp r4.x, r1.x
mul r4.x, r4, c1.w
mov r1.x, c3
mad r0.x, -r4, c4, r0
cmp r0.x, r0, c4.y, r1
dp3_pp r1.x, t3, t3
rsq_pp r4.x, r1.x
mov_sat r1.x, t3.w
mul r0.x, r6, r0
mul r0.x, r0, r1
mul_pp r4.xyz, r4.x, t3
dp3_pp r1.x, t2, r4
mul_pp r0.x, r1, r0
add_pp r1.xyz, r2, r3
mul_pp r0.x, r0, c4.z
mul r1.xyz, r1, c0
mul r0.xyz, r1, r0.x
mov_pp r0.w, c4
mov_pp oC0, r0
"
}

SubProgram "opengl " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" }
Local 0, [_ModelLightColor0]
Local 1, [_LightPositionRange]
Local 2, [_RGBADecodeDot]
Local 3, [_LightShadowData]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {CUBE}
SetTexture [_LightTexture0] {CUBE}
"!!ARBfp1.0
OPTION ARB_fog_exp2;
OPTION ARB_precision_hint_fastest;
# 34 instructions, 7 texture reads
PARAM c[5] = { program.local[0..3],
		{ 0, 0.97000003, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R1, fragment.texcoord[1], texture[5], CUBE;
TEX R0, fragment.texcoord[4], texture[0], 2D;
TEX R3.xyz, fragment.texcoord[5].zwzw, texture[2], 2D;
TEX R4.xyz, fragment.texcoord[6], texture[3], 2D;
TEX R2.xyz, fragment.texcoord[5], texture[1], 2D;
TEX R5.xyz, fragment.texcoord[6].zwzw, texture[4], 2D;
TEX R2.w, fragment.texcoord[0], texture[6], CUBE;
DP4 R1.x, R1, c[2];
MUL R3.xyz, R0.y, R3;
MUL R4.xyz, R0.z, R4;
MUL R0.xyz, R0.x, R2;
ADD R0.xyz, R0, R3;
MUL R2.xyz, R0.w, R5;
ADD R0.xyz, R0, R4;
DP3 R3.x, fragment.texcoord[1], fragment.texcoord[1];
RSQ R0.w, R3.x;
RCP R1.y, R0.w;
MUL R1.y, R1, c[1].w;
ADD R0.xyz, R0, R2;
MAD R1.x, -R1.y, c[4].y, R1;
MOV R0.w, c[4].z;
CMP R0.w, R1.x, c[3].x, R0;
DP3 R1.x, fragment.texcoord[3], fragment.texcoord[3];
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, fragment.texcoord[3];
MUL R0.w, R2, R0;
MOV_SAT R1.w, fragment.texcoord[3];
MUL R0.w, R0, R1;
DP3 R1.x, fragment.texcoord[2], R1;
MUL R0.w, R1.x, R0;
MUL R0.w, R0, c[4];
MUL R0.xyz, R0, c[0];
MUL result.color.xyz, R0, R0.w;
MOV result.color.w, c[4].x;
END
# 34 instructions, 6 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" }
Local 0, [_ModelLightColor0]
Local 1, [_LightPositionRange]
Local 2, [_RGBADecodeDot]
Local 3, [_LightShadowData]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {CUBE}
SetTexture [_LightTexture0] {CUBE}
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_cube s5
dcl_cube s6
def c4, 0.97000003, 1.00000000, 2.00000000, 0.00000000
dcl t0.xyz
dcl t1.xyz
dcl t2.xyz
dcl t3
dcl t4.xy
dcl t5
dcl t6
texld r6, t0, s6
texld r5, t6, s3
texld r3, t5, s1
mov r0.y, t5.w
mov r0.x, t5.z
mov r1.xy, r0
mov r0.y, t6.w
mov r0.x, t6.z
mov r2.xy, r0
texld r4, r2, s4
texld r0, t1, s5
texld r2, t4, s0
texld r1, r1, s2
dp4 r0.x, r0, c2
mul r3.xyz, r2.x, r3
mul r1.xyz, r2.y, r1
add_pp r1.xyz, r3, r1
mul r2.xyz, r2.z, r5
add_pp r2.xyz, r1, r2
dp3 r1.x, t1, t1
mul r3.xyz, r2.w, r4
rsq r1.x, r1.x
rcp r4.x, r1.x
mul r4.x, r4, c1.w
mov r1.x, c3
mad r0.x, -r4, c4, r0
cmp r0.x, r0, c4.y, r1
dp3_pp r1.x, t3, t3
rsq_pp r4.x, r1.x
mov_sat r1.x, t3.w
mul r0.x, r6.w, r0
mul r0.x, r0, r1
mul_pp r4.xyz, r4.x, t3
dp3_pp r1.x, t2, r4
mul_pp r0.x, r1, r0
add_pp r1.xyz, r2, r3
mul_pp r0.x, r0, c4.z
mul r1.xyz, r1, c0
mul r0.xyz, r1, r0.x
mov_pp r0.w, c4
mov_pp oC0, r0
"
}

SubProgram "opengl " {
Keywords { "POINT_NOATT" "SHADOWS_CUBE" }
Local 0, [_ModelLightColor0]
Local 1, [_LightPositionRange]
Local 2, [_RGBADecodeDot]
Local 3, [_LightShadowData]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {CUBE}
"!!ARBfp1.0
OPTION ARB_fog_exp2;
OPTION ARB_precision_hint_fastest;
# 32 instructions, 6 texture reads
PARAM c[5] = { program.local[0..3],
		{ 0, 0.97000003, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R1, fragment.texcoord[0], texture[5], CUBE;
TEX R0, fragment.texcoord[3], texture[0], 2D;
TEX R3.xyz, fragment.texcoord[4].zwzw, texture[2], 2D;
TEX R2.xyz, fragment.texcoord[4], texture[1], 2D;
TEX R5.xyz, fragment.texcoord[5].zwzw, texture[4], 2D;
TEX R4.xyz, fragment.texcoord[5], texture[3], 2D;
DP4 R1.x, R1, c[2];
DP3 R2.w, fragment.texcoord[0], fragment.texcoord[0];
MUL R3.xyz, R0.y, R3;
MUL R2.xyz, R0.x, R2;
ADD R2.xyz, R2, R3;
MUL R0.xyz, R0.z, R4;
ADD R0.xyz, R2, R0;
MUL R2.xyz, R0.w, R5;
RSQ R2.w, R2.w;
RCP R0.w, R2.w;
MUL R0.w, R0, c[1];
MAD R1.y, -R0.w, c[4], R1.x;
MOV R0.w, c[4].z;
DP3 R1.x, fragment.texcoord[2], fragment.texcoord[2];
ADD R0.xyz, R0, R2;
CMP R0.w, R1.y, c[3].x, R0;
RSQ R1.x, R1.x;
MOV_SAT R1.w, fragment.texcoord[2];
MUL R1.xyz, R1.x, fragment.texcoord[2];
MUL R0.w, R0, R1;
DP3 R1.x, fragment.texcoord[1], R1;
MUL R0.w, R1.x, R0;
MUL R0.w, R0, c[4];
MUL R0.xyz, R0, c[0];
MUL result.color.xyz, R0, R0.w;
MOV result.color.w, c[4].x;
END
# 32 instructions, 6 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "POINT_NOATT" "SHADOWS_CUBE" }
Local 0, [_ModelLightColor0]
Local 1, [_LightPositionRange]
Local 2, [_RGBADecodeDot]
Local 3, [_LightShadowData]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {CUBE}
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_cube s5
def c4, 0.97000003, 1.00000000, 2.00000000, 0.00000000
dcl t0.xyz
dcl t1.xyz
dcl t2
dcl t3.xy
dcl t4
dcl t5
texld r4, t4, s1
texld r5, t3, s0
mov r0.y, t4.w
mov r0.x, t4.z
mov r2.xy, r0
mov r0.y, t5.w
mov r0.x, t5.z
mov r1.xy, r0
mul r4.xyz, r5.x, r4
texld r3, r2, s2
texld r0, t0, s5
texld r1, r1, s4
texld r2, t5, s3
dp4 r0.x, r0, c2
mul r3.xyz, r5.y, r3
add_pp r3.xyz, r4, r3
mul r2.xyz, r5.z, r2
add_pp r3.xyz, r3, r2
mul r4.xyz, r5.w, r1
dp3 r2.x, t0, t0
rsq r1.x, r2.x
rcp r1.x, r1.x
mul r1.x, r1, c1.w
mad r2.x, -r1, c4, r0
mov r0.x, c3
dp3_pp r1.x, t2, t2
cmp r0.x, r2, c4.y, r0
rsq_pp r2.x, r1.x
mov_sat r1.x, t2.w
mul r0.x, r0, r1
mul_pp r2.xyz, r2.x, t2
dp3_pp r1.x, t1, r2
mul_pp r0.x, r1, r0
add_pp r1.xyz, r3, r4
mul_pp r0.x, r0, c4.z
mul r1.xyz, r1, c0
mul r0.xyz, r1, r0.x
mov_pp r0.w, c4
mov_pp oC0, r0
"
}

SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_NATIVE" "SHADOWS_PCF4" }
Local 0, [_ModelLightColor0]
Local 1, [_LightShadowData]
Local 2, [_ShadowOffsets0]
Local 3, [_ShadowOffsets1]
Local 4, [_ShadowOffsets2]
Local 5, [_ShadowOffsets3]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {2D}
"!!ARBfp1.0
OPTION ARB_fog_exp2;
OPTION ARB_precision_hint_fastest;
# 40 instructions, 9 texture reads
PARAM c[7] = { program.local[0..5],
		{ 0, 1, 0.25, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
TEMP R8;
TEX R3, fragment.texcoord[4], texture[0], 2D;
TEX R8.xyz, fragment.texcoord[6].zwzw, texture[4], 2D;
TEX R7.xyz, fragment.texcoord[6], texture[3], 2D;
TEX R5.xyz, fragment.texcoord[5], texture[1], 2D;
TEX R6.xyz, fragment.texcoord[5].zwzw, texture[2], 2D;
RCP R0.x, fragment.texcoord[0].w;
MUL R2.xyz, fragment.texcoord[0], R0.x;
ADD R1.xy, R2, c[5];
ADD R0.xy, R2, c[3];
ADD R1.zw, R2.xyxy, c[2].xyxy;
ADD R0.zw, R2.xyxy, c[4].xyxy;
MOV result.color.w, c[6].x;
TEX R1.x, R1, texture[5], 2D;
TEX R2.x, R0.zwzw, texture[5], 2D;
TEX R0.x, R0, texture[5], 2D;
TEX R4.x, R1.zwzw, texture[5], 2D;
MOV R4.w, R1.x;
MOV R4.z, R2.x;
MOV R4.y, R0.x;
ADD R0, R4, -R2.z;
MOV R1.x, c[6].y;
CMP R0, R0, c[1].x, R1.x;
DP4 R0.x, R0, c[6].z;
MOV_SAT R1.x, fragment.texcoord[1];
ADD_SAT R0.w, R0.x, R1.x;
MOV_SAT R1.x, fragment.texcoord[3].w;
MUL R0.w, R0, R1.x;
MOV R0.xyz, fragment.texcoord[3];
DP3 R0.x, fragment.texcoord[2], R0;
MUL R0.w, R0.x, R0;
MUL R1.xyz, R3.x, R5;
MUL R0.xyz, R3.y, R6;
ADD R0.xyz, R1, R0;
MUL R1.xyz, R3.z, R7;
MUL R2.xyz, R3.w, R8;
ADD R0.xyz, R0, R1;
ADD R0.xyz, R0, R2;
MUL R0.w, R0, c[6];
MUL R0.xyz, R0, c[0];
MUL result.color.xyz, R0, R0.w;
END
# 40 instructions, 9 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_NATIVE" "SHADOWS_PCF4" }
Local 0, [_ModelLightColor0]
Local 1, [_LightShadowData]
Local 2, [_ShadowOffsets0]
Local 3, [_ShadowOffsets1]
Local 4, [_ShadowOffsets2]
Local 5, [_ShadowOffsets3]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {2D}
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
def c6, 1.00000000, 0.25000000, 2.00000000, 0.00000000
dcl t0
dcl t1.x
dcl t2.xyz
dcl t3
dcl t4.xy
dcl t5
dcl t6
texld r4, t6, s3
rcp r0.x, t0.w
mul r9.xyz, t0, r0.x
add r0.xy, r9, c5
add r2.xy, r9, c4
add r6.xy, r9, c3
add r5.xy, r9, c2
mov r1.y, t6.w
mov r1.x, t6.z
mov r3.xy, r1
mov r1.y, t5.w
mov r1.x, t5.z
texld r7, r2, s5
texld r8, r0, s5
texld r2, t5, s1
texld r3, r3, s4
texld r6, r6, s5
texld r0, t4, s0
texld r1, r1, s2
texld r5, r5, s5
mul r2.xyz, r0.x, r2
mul r1.xyz, r0.y, r1
mul r3.xyz, r0.w, r3
mul r4.xyz, r0.z, r4
add_pp r1.xyz, r2, r1
add_pp r1.xyz, r1, r4
add_pp r1.xyz, r1, r3
mov r5.w, r8.x
mov r5.z, r7.x
mov r5.y, r6.x
mov r0.x, c1
add r2, r5, -r9.z
cmp r2, r2, c6.x, r0.x
dp4 r4.x, r2, c6.y
mov_pp_sat r2.x, t1
add_pp_sat r2.x, r4, r2
mov_sat r0.x, t3.w
mul r0.x, r2, r0
mov_pp r2.xyz, t3
dp3_pp r2.x, t2, r2
mul_pp r0.x, r2, r0
mul_pp r0.x, r0, c6.z
mul r1.xyz, r1, c0
mul r0.xyz, r1, r0.x
mov_pp r0.w, c6
mov_pp oC0, r0
"
}

SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_NATIVE" "SHADOWS_PCF4" }
Local 0, [_ModelLightColor0]
Local 1, [_LightShadowData]
Local 2, [_ShadowOffsets0]
Local 3, [_ShadowOffsets1]
Local 4, [_ShadowOffsets2]
Local 5, [_ShadowOffsets3]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {2D}
SetTexture [_LightTexture0] {2D}
SetTexture [_LightTextureB0] {2D}
"!!ARBfp1.0
OPTION ARB_fog_exp2;
OPTION ARB_precision_hint_fastest;
# 46 instructions, 11 texture reads
PARAM c[7] = { program.local[0..5],
		{ 0, 1, 0.25, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
TEMP R8;
TEX R3, fragment.texcoord[5], texture[0], 2D;
TEX R8.xyz, fragment.texcoord[7].zwzw, texture[4], 2D;
TEX R7.xyz, fragment.texcoord[7], texture[3], 2D;
TEX R5.xyz, fragment.texcoord[6], texture[1], 2D;
TEX R6.xyz, fragment.texcoord[6].zwzw, texture[2], 2D;
RCP R0.x, fragment.texcoord[1].w;
MUL R2.xyz, fragment.texcoord[1], R0.x;
ADD R1.zw, R2.xyxy, c[2].xyxy;
ADD R1.xy, R2, c[4];
ADD R0.xy, R2, c[3];
ADD R0.zw, R2.xyxy, c[5].xyxy;
MOV result.color.w, c[6].x;
TEX R2.x, R0.zwzw, texture[5], 2D;
TEX R1.x, R1, texture[5], 2D;
TEX R4.x, R1.zwzw, texture[5], 2D;
TEX R0.x, R0, texture[5], 2D;
TXP R0.w, fragment.texcoord[0].xyzz, texture[6], 2D;
TEX R1.w, fragment.texcoord[0].w, texture[7], 2D;
MOV R4.z, R1.x;
MOV R4.y, R0.x;
MOV R4.w, R2.x;
MUL R0.z, R0.w, R1.w;
MOV R0.x, c[6].y;
ADD R2, R4, -R2.z;
CMP R2, R2, c[1].x, R0.x;
DP4 R0.y, R2, c[6].z;
MOV_SAT R0.x, fragment.texcoord[2];
ADD_SAT R0.x, R0.y, R0;
MUL R0.w, R0.z, R0.x;
DP3 R0.y, fragment.texcoord[4], fragment.texcoord[4];
MOV_SAT R1.x, fragment.texcoord[4].w;
MUL R0.w, R0, R1.x;
RSQ R0.x, R0.y;
MUL R0.xyz, R0.x, fragment.texcoord[4];
DP3 R0.x, fragment.texcoord[3], R0;
MUL R0.w, R0.x, R0;
MUL R1.xyz, R3.x, R5;
MUL R0.xyz, R3.y, R6;
ADD R0.xyz, R1, R0;
MUL R1.xyz, R3.z, R7;
MUL R2.xyz, R3.w, R8;
ADD R0.xyz, R0, R1;
ADD R0.xyz, R0, R2;
MUL R0.w, R0, c[6];
MUL R0.xyz, R0, c[0];
MUL result.color.xyz, R0, R0.w;
END
# 46 instructions, 9 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_NATIVE" "SHADOWS_PCF4" }
Local 0, [_ModelLightColor0]
Local 1, [_LightShadowData]
Local 2, [_ShadowOffsets0]
Local 3, [_ShadowOffsets1]
Local 4, [_ShadowOffsets2]
Local 5, [_ShadowOffsets3]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {2D}
SetTexture [_LightTexture0] {2D}
SetTexture [_LightTextureB0] {2D}
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
dcl_2d s6
dcl_2d s7
def c6, 1.00000000, 0.25000000, 2.00000000, 0.00000000
dcl t0
dcl t1
dcl t2.x
dcl t3.xyz
dcl t4
dcl t5.xy
dcl t6
dcl t7
rcp r0.x, t1.w
mul r11.xyz, t1, r0.x
add r0.xy, r11, c5
add r2.xy, r11, c4
add r5.xy, r11, c2
mov r7.xy, t0.w
add r4.xy, r11, c3
mov r1.x, t0
mov r1.w, t0.z
mov r1.y, t0
mov r6.xyw, r1
mov r1.y, t6.w
mov r1.x, t6.z
mov r3.y, t7.w
mov r3.x, t7.z
texldp r8, r6, s6
texld r6, r4, s5
texld r9, r2, s5
texld r10, r0, s5
texld r2, t6, s1
texld r3, r3, s4
texld r7, r7, s7
texld r4, t7, s3
texld r0, t5, s0
texld r1, r1, s2
texld r5, r5, s5
mul r3.xyz, r0.w, r3
mul r2.xyz, r0.x, r2
mul r1.xyz, r0.y, r1
mul r0.xyz, r0.z, r4
add_pp r1.xyz, r2, r1
add_pp r1.xyz, r1, r0
add_pp r1.xyz, r1, r3
mov r5.w, r10.x
mov r5.z, r9.x
mov r5.y, r6.x
mov r0.x, c1
add r2, r5, -r11.z
cmp r2, r2, c6.x, r0.x
dp4 r2.x, r2, c6.y
mov_pp_sat r0.x, t2
add_pp_sat r0.x, r2, r0
mul r2.x, r8.w, r7.w
mul r0.x, r2, r0
mov_sat r4.x, t4.w
dp3_pp r2.x, t4, t4
rsq_pp r2.x, r2.x
mul_pp r2.xyz, r2.x, t4
mul r0.x, r0, r4
dp3_pp r2.x, t3, r2
mul_pp r0.x, r2, r0
mul_pp r0.x, r0, c6.z
mul r1.xyz, r1, c0
mul r0.xyz, r1, r0.x
mov_pp r0.w, c6
mov_pp oC0, r0
"
}

SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_NATIVE" "SHADOWS_PCF4" }
Local 0, [_ModelLightColor0]
Local 1, [_LightShadowData]
Local 2, [_ShadowOffsets0]
Local 3, [_ShadowOffsets1]
Local 4, [_ShadowOffsets2]
Local 5, [_ShadowOffsets3]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {2D}
SetTexture [_LightTexture0] {2D}
"!!ARBfp1.0
OPTION ARB_fog_exp2;
OPTION ARB_precision_hint_fastest;
# 42 instructions, 10 texture reads
PARAM c[7] = { program.local[0..5],
		{ 0, 1, 0.25, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
TEMP R8;
TEX R3, fragment.texcoord[5], texture[0], 2D;
TEX R8.xyz, fragment.texcoord[7].zwzw, texture[4], 2D;
TEX R7.xyz, fragment.texcoord[7], texture[3], 2D;
TEX R5.xyz, fragment.texcoord[6], texture[1], 2D;
TEX R6.xyz, fragment.texcoord[6].zwzw, texture[2], 2D;
RCP R0.x, fragment.texcoord[1].w;
MUL R2.xyz, fragment.texcoord[1], R0.x;
ADD R1.xy, R2, c[4];
ADD R0.xy, R2, c[3];
ADD R1.zw, R2.xyxy, c[2].xyxy;
ADD R0.zw, R2.xyxy, c[5].xyxy;
MOV result.color.w, c[6].x;
TEX R2.x, R0.zwzw, texture[5], 2D;
TEX R0.x, R0, texture[5], 2D;
TEX R1.x, R1, texture[5], 2D;
TEX R4.x, R1.zwzw, texture[5], 2D;
TEX R0.w, fragment.texcoord[0], texture[6], 2D;
MOV R4.y, R0.x;
MOV R4.w, R2.x;
MOV R4.z, R1.x;
ADD R1, R4, -R2.z;
MOV R0.x, c[6].y;
CMP R1, R1, c[1].x, R0.x;
DP4 R0.y, R1, c[6].z;
MOV_SAT R0.x, fragment.texcoord[2];
ADD_SAT R0.x, R0.y, R0;
MUL R0.w, R0, R0.x;
MOV_SAT R1.x, fragment.texcoord[4].w;
MUL R0.w, R0, R1.x;
MOV R0.xyz, fragment.texcoord[4];
DP3 R0.x, fragment.texcoord[3], R0;
MUL R0.w, R0.x, R0;
MUL R1.xyz, R3.x, R5;
MUL R0.xyz, R3.y, R6;
ADD R0.xyz, R1, R0;
MUL R1.xyz, R3.z, R7;
MUL R2.xyz, R3.w, R8;
ADD R0.xyz, R0, R1;
ADD R0.xyz, R0, R2;
MUL R0.w, R0, c[6];
MUL R0.xyz, R0, c[0];
MUL result.color.xyz, R0, R0.w;
END
# 42 instructions, 9 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_NATIVE" "SHADOWS_PCF4" }
Local 0, [_ModelLightColor0]
Local 1, [_LightShadowData]
Local 2, [_ShadowOffsets0]
Local 3, [_ShadowOffsets1]
Local 4, [_ShadowOffsets2]
Local 5, [_ShadowOffsets3]
SetTexture [_Control] {2D}
SetTexture [_Splat0] {2D}
SetTexture [_Splat1] {2D}
SetTexture [_Splat2] {2D}
SetTexture [_Splat3] {2D}
SetTexture [_ShadowMapTexture] {2D}
SetTexture [_LightTexture0] {2D}
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
dcl_2d s6
def c6, 1.00000000, 0.25000000, 2.00000000, 0.00000000
dcl t0.xy
dcl t1
dcl t2.x
dcl t3.xyz
dcl t4
dcl t5.xy
dcl t6
dcl t7
texld r7, t0, s6
rcp r0.x, t1.w
mul r10.xyz, t1, r0.x
add r0.xy, r10, c5
add r2.xy, r10, c4
add r4.xy, r10, c3
add r5.xy, r10, c2
mov r1.y, t7.w
mov r1.x, t7.z
mov r3.xy, r1
mov r1.y, t6.w
mov r1.x, t6.z
texld r6, r4, s5
texld r8, r2, s5
texld r9, r0, s5
texld r2, t6, s1
texld r3, r3, s4
texld r4, t7, s3
texld r0, t5, s0
texld r1, r1, s2
texld r5, r5, s5
mul r3.xyz, r0.w, r3
mul r2.xyz, r0.x, r2
mul r1.xyz, r0.y, r1
mul r0.xyz, r0.z, r4
add_pp r1.xyz, r2, r1
add_pp r1.xyz, r1, r0
add_pp r1.xyz, r1, r3
mov r5.w, r9.x
mov r5.z, r8.x
mov r5.y, r6.x
mov r0.x, c1
add r2, r5, -r10.z
cmp r2, r2, c6.x, r0.x
dp4 r2.x, r2, c6.y
mov_pp_sat r0.x, t2
add_pp_sat r2.x, r2, r0
mul r2.x, r7.w, r2
mov_sat r0.x, t4.w
mul r0.x, r2, r0
mov_pp r2.xyz, t4
dp3_pp r2.x, t3, r2
mul_pp r0.x, r2, r0
mul_pp r0.x, r0, c6.z
mul r1.xyz, r1, c0
mul r0.xyz, r1, r0.x
mov_pp r0.w, c6
mov_pp oC0, r0
"
}

}
#LINE 66

	}
}
 	
// Fallback to VertexLit
Fallback "Hidden/TerrainEngine/Splatmap/Vertexlit-AddPass"
}
