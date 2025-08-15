Shader "Nature/Soft Occlusion Leaves" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Main Texture", 2D) = "white" {  }
		_Cutoff ("Base Alpha cutoff", Range (.5,.9)) = .5
		_BaseLight ("BaseLight", range (0, 1)) = 0.35
		_AO ("Amb. Occlusion", range (0, 10)) = 2.4
		_Occlusion ("Dir Occlusion", range (0, 20)) = 7.5
		_Scale ("Scale", Vector) = (1,1,1,1)
	}
	SubShader {
		Tags {
			"Queue" = "Transparent-99"
			"IgnoreProjector"="True"
			"BillboardShader" = "Hidden/TerrainEngine/Soft Occlusion Leaves rendertex"
			"RenderType" = "TreeTransparentCutout"
		}
		Cull Off
		ColorMask RGB
		
		Pass {
			Program "" {
// Vertex combos: 1, instructions: 93 to 93
SubProgram "opengl " {
Keywords { }
Bind "vertex", Vertex
Bind "tangent", ATTR14
Bind "color", Color
Bind "texcoord", TexCoord0
Local 9, [_Scale]
Matrix 1, [_TerrainEngineBendTree]
Local 10, ([_Occlusion],0,0,0)
Local 11, ([_AO],0,0,0)
Local 12, ([_BaseLight],0,0,0)
Local 13, [_Color]
Matrix 5, [_CameraToWorld]
"!!ARBvp1.0
# 93 instructions
PARAM c[35] = { { 1, 0 },
		program.local[1..13],
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
		state.matrix.mvp };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R0.xyz, vertex.position, c[9];
MOV R1.w, vertex.position;
DP3 R1.z, R0, c[3];
DP3 R1.x, R0, c[1];
DP3 R1.y, R0, c[2];
ADD R1.xyz, R1, -R0;
MAD R1.xyz, vertex.color.w, R1, R0;
DP4 R3.z, R1, c[29];
DP4 R3.x, R1, c[27];
DP4 R3.y, R1, c[28];
MAD R0.xyz, -R3, c[21].w, c[21];
MOV R0.yz, -R0;
DP3 R2.w, R0, R0;
MAD R2.xyz, -R3, c[15].w, c[15];
RSQ R0.w, R2.w;
MUL R4.xyz, R0.w, R0;
DP3 R0.z, R4, c[7];
DP3 R0.y, R4, c[6];
DP3 R0.x, R4, c[5];
MOV R2.yz, -R2;
DP3 R4.x, R2, R2;
RSQ R3.w, R4.x;
MUL R2.xyz, R3.w, R2;
MUL R0.xyz, R0, c[10].x;
MOV R0.w, c[11].x;
DP4 R3.w, vertex.attrib[14], R0;
MAX R3.w, R3, c[0].y;
DP3 R0.z, R2, c[7];
DP3 R0.y, R2, c[6];
DP3 R0.x, R2, c[5];
MUL R0.xyz, R0, c[10].x;
MOV R0.w, c[11].x;
DP4 R0.x, vertex.attrib[14], R0;
MUL R0.y, R4.x, c[16].z;
ADD R2.x, R0.y, c[0];
MAX R0.x, R0, c[0].y;
ADD R0.w, R0.x, c[12].x;
MAD R0.xyz, -R3, c[18].w, c[18];
RCP R4.x, R2.x;
MOV R2.x, R0;
MOV R2.yz, -R0;
MUL R0.x, R0.w, R4;
DP3 R4.w, R2, R2;
RSQ R0.w, R4.w;
MUL R4.xyz, R0.w, R2;
MUL R0.xyz, R0.x, c[14];
ADD R2.xyz, R0, c[26];
DP3 R0.z, R4, c[7];
DP3 R0.x, R4, c[5];
DP3 R0.y, R4, c[6];
MUL R0.xyz, R0, c[10].x;
MOV R0.w, c[11].x;
DP4 R0.x, vertex.attrib[14], R0;
MUL R0.w, R2, c[22].z;
ADD R2.w, R0, c[0].x;
MUL R4.x, R4.w, c[19].z;
ADD R0.y, R4.x, c[0].x;
MAX R0.x, R0, c[0].y;
RCP R0.y, R0.y;
ADD R0.x, R0, c[12];
MUL R0.x, R0, R0.y;
MAD R0.xyz, R0.x, c[17], R2;
MAD R2.xyz, -R3, c[24].w, c[24];
MOV R2.yz, -R2;
DP3 R0.w, R2, R2;
RSQ R3.x, R0.w;
MUL R2.xyz, R3.x, R2;
MUL R0.w, R0, c[25].z;
ADD R0.w, R0, c[0].x;
ADD R3.w, R3, c[12].x;
RCP R2.w, R2.w;
MUL R2.w, R3, R2;
MAD R0.xyz, R2.w, c[20], R0;
DP3 R3.z, R2, c[7];
DP3 R3.x, R2, c[5];
DP3 R3.y, R2, c[6];
MUL R2.xyz, R3, c[10].x;
MOV R2.w, c[11].x;
DP4 R2.x, vertex.attrib[14], R2;
MAX R2.x, R2, c[0].y;
RCP R0.w, R0.w;
ADD R2.x, R2, c[12];
MUL R0.w, R2.x, R0;
MAD R0.xyz, R0.w, c[23], R0;
MOV R0.w, c[0].x;
MUL result.color, R0, c[13];
DP4 R0.x, R1, c[33];
DP4 result.position.w, R1, c[34];
MOV result.position.z, R0.x;
DP4 result.position.y, R1, c[32];
DP4 result.position.x, R1, c[31];
MOV result.fogcoord.x, R0;
MOV result.texcoord[0], vertex.texcoord[0];
END
# 93 instructions, 5 R-regs
"
}

SubProgram "d3d9 " {
Keywords { }
Bind "vertex", Vertex
Bind "tangent", TexCoord2
Bind "color", Color
Bind "texcoord", TexCoord0
Local 16, [_Scale]
Matrix 0, [_TerrainEngineBendTree]
Local 17, ([_Occlusion],0,0,0)
Local 18, ([_AO],0,0,0)
Local 19, ([_BaseLight],0,0,0)
Local 20, [_Color]
Matrix 4, [_CameraToWorld]
Local 21, [glstate_light0_diffuse]
Local 22, [glstate_light0_position]
Local 23, [glstate_light0_attenuation]
Local 24, [glstate_light1_diffuse]
Local 25, [glstate_light1_position]
Local 26, [glstate_light1_attenuation]
Local 27, [glstate_light2_diffuse]
Local 28, [glstate_light2_position]
Local 29, [glstate_light2_attenuation]
Local 30, [glstate_light3_diffuse]
Local 31, [glstate_light3_position]
Local 32, [glstate_light3_attenuation]
Local 33, [glstate_lightmodel_ambient]
Matrix 8, [glstate_matrix_modelview0]
Matrix 12, [glstate_matrix_mvp]
"vs_1_1
def c34, 0.00000000, 1.00000000, 0, 0
dcl_position v0
dcl_tangent v1
dcl_color v2
dcl_texcoord0 v3
mul r0.xyz, v0, c16
mov r1.w, v0
dp3 r1.z, r0, c2
dp3 r1.x, r0, c0
dp3 r1.y, r0, c1
add r1.xyz, r1, -r0
mad r1.xyz, v2.w, r1, r0
dp4 r3.z, r1, c10
dp4 r3.x, r1, c8
dp4 r3.y, r1, c9
mad r0.xyz, -r3, c28.w, c28
mov r0.yz, -r0
dp3 r2.w, r0, r0
mad r2.xyz, -r3, c22.w, c22
rsq r0.w, r2.w
mul r4.xyz, r0.w, r0
dp3 r0.z, r4, c6
dp3 r0.y, r4, c5
dp3 r0.x, r4, c4
mov r2.yz, -r2
dp3 r4.x, r2, r2
rsq r3.w, r4.x
mul r2.xyz, r3.w, r2
mul r0.xyz, r0, c17.x
mov r0.w, c18.x
dp4 r3.w, v1, r0
max r3.w, r3, c34.x
dp3 r0.z, r2, c6
dp3 r0.y, r2, c5
dp3 r0.x, r2, c4
mul r0.xyz, r0, c17.x
mov r0.w, c18.x
dp4 r0.x, v1, r0
mul r0.y, r4.x, c23.z
add r2.x, r0.y, c34.y
max r0.x, r0, c34
add r0.w, r0.x, c19.x
mad r0.xyz, -r3, c25.w, c25
rcp r4.x, r2.x
mov r2.x, r0
mov r2.yz, -r0
mul r0.x, r0.w, r4
dp3 r4.w, r2, r2
rsq r0.w, r4.w
mul r4.xyz, r0.w, r2
mul r0.xyz, r0.x, c21
add r2.xyz, r0, c33
dp3 r0.z, r4, c6
dp3 r0.x, r4, c4
dp3 r0.y, r4, c5
mul r0.xyz, r0, c17.x
mov r0.w, c18.x
dp4 r0.x, v1, r0
mul r0.w, r2, c29.z
add r2.w, r0, c34.y
mul r4.x, r4.w, c26.z
add r0.y, r4.x, c34
max r0.x, r0, c34
rcp r0.y, r0.y
add r0.x, r0, c19
mul r0.x, r0, r0.y
mad r0.xyz, r0.x, c24, r2
mad r2.xyz, -r3, c31.w, c31
mov r2.yz, -r2
dp3 r0.w, r2, r2
rsq r3.x, r0.w
mul r2.xyz, r3.x, r2
mul r0.w, r0, c32.z
add r0.w, r0, c34.y
add r3.w, r3, c19.x
rcp r2.w, r2.w
mul r2.w, r3, r2
mad r0.xyz, r2.w, c27, r0
dp3 r3.z, r2, c6
dp3 r3.x, r2, c4
dp3 r3.y, r2, c5
mul r2.xyz, r3, c17.x
mov r2.w, c18.x
dp4 r2.x, v1, r2
max r2.x, r2, c34
rcp r0.w, r0.w
add r2.x, r2, c19
mul r0.w, r2.x, r0
mad r0.xyz, r0.w, c30, r0
mov r0.w, c34.y
mul oD0, r0, c20
dp4 r0.x, r1, c14
dp4 oPos.w, r1, c15
mov oPos.z, r0.x
dp4 oPos.y, r1, c13
dp4 oPos.x, r1, c12
mov oFog, r0.x
mov oT0, v3
"
}

}
#LINE 25


			AlphaTest GEqual [_Cutoff]
			ZWrite On
			
			SetTexture [_MainTex] { combine primary * texture DOUBLE, texture }
		}
		
		Pass {
			Tags { "RequireOptions" = "SoftVegetation" }
			Program "" {
// Vertex combos: 1, instructions: 93 to 93
SubProgram "opengl " {
Keywords { }
Bind "vertex", Vertex
Bind "tangent", ATTR14
Bind "color", Color
Bind "texcoord", TexCoord0
Local 9, [_Scale]
Matrix 1, [_TerrainEngineBendTree]
Local 10, ([_Occlusion],0,0,0)
Local 11, ([_AO],0,0,0)
Local 12, ([_BaseLight],0,0,0)
Local 13, [_Color]
Matrix 5, [_CameraToWorld]
"!!ARBvp1.0
# 93 instructions
PARAM c[35] = { { 1, 0 },
		program.local[1..13],
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
		state.matrix.mvp };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R0.xyz, vertex.position, c[9];
MOV R1.w, vertex.position;
DP3 R1.z, R0, c[3];
DP3 R1.x, R0, c[1];
DP3 R1.y, R0, c[2];
ADD R1.xyz, R1, -R0;
MAD R1.xyz, vertex.color.w, R1, R0;
DP4 R3.z, R1, c[29];
DP4 R3.x, R1, c[27];
DP4 R3.y, R1, c[28];
MAD R0.xyz, -R3, c[21].w, c[21];
MOV R0.yz, -R0;
DP3 R2.w, R0, R0;
MAD R2.xyz, -R3, c[15].w, c[15];
RSQ R0.w, R2.w;
MUL R4.xyz, R0.w, R0;
DP3 R0.z, R4, c[7];
DP3 R0.y, R4, c[6];
DP3 R0.x, R4, c[5];
MOV R2.yz, -R2;
DP3 R4.x, R2, R2;
RSQ R3.w, R4.x;
MUL R2.xyz, R3.w, R2;
MUL R0.xyz, R0, c[10].x;
MOV R0.w, c[11].x;
DP4 R3.w, vertex.attrib[14], R0;
MAX R3.w, R3, c[0].y;
DP3 R0.z, R2, c[7];
DP3 R0.y, R2, c[6];
DP3 R0.x, R2, c[5];
MUL R0.xyz, R0, c[10].x;
MOV R0.w, c[11].x;
DP4 R0.x, vertex.attrib[14], R0;
MUL R0.y, R4.x, c[16].z;
ADD R2.x, R0.y, c[0];
MAX R0.x, R0, c[0].y;
ADD R0.w, R0.x, c[12].x;
MAD R0.xyz, -R3, c[18].w, c[18];
RCP R4.x, R2.x;
MOV R2.x, R0;
MOV R2.yz, -R0;
MUL R0.x, R0.w, R4;
DP3 R4.w, R2, R2;
RSQ R0.w, R4.w;
MUL R4.xyz, R0.w, R2;
MUL R0.xyz, R0.x, c[14];
ADD R2.xyz, R0, c[26];
DP3 R0.z, R4, c[7];
DP3 R0.x, R4, c[5];
DP3 R0.y, R4, c[6];
MUL R0.xyz, R0, c[10].x;
MOV R0.w, c[11].x;
DP4 R0.x, vertex.attrib[14], R0;
MUL R0.w, R2, c[22].z;
ADD R2.w, R0, c[0].x;
MUL R4.x, R4.w, c[19].z;
ADD R0.y, R4.x, c[0].x;
MAX R0.x, R0, c[0].y;
RCP R0.y, R0.y;
ADD R0.x, R0, c[12];
MUL R0.x, R0, R0.y;
MAD R0.xyz, R0.x, c[17], R2;
MAD R2.xyz, -R3, c[24].w, c[24];
MOV R2.yz, -R2;
DP3 R0.w, R2, R2;
RSQ R3.x, R0.w;
MUL R2.xyz, R3.x, R2;
MUL R0.w, R0, c[25].z;
ADD R0.w, R0, c[0].x;
ADD R3.w, R3, c[12].x;
RCP R2.w, R2.w;
MUL R2.w, R3, R2;
MAD R0.xyz, R2.w, c[20], R0;
DP3 R3.z, R2, c[7];
DP3 R3.x, R2, c[5];
DP3 R3.y, R2, c[6];
MUL R2.xyz, R3, c[10].x;
MOV R2.w, c[11].x;
DP4 R2.x, vertex.attrib[14], R2;
MAX R2.x, R2, c[0].y;
RCP R0.w, R0.w;
ADD R2.x, R2, c[12];
MUL R0.w, R2.x, R0;
MAD R0.xyz, R0.w, c[23], R0;
MOV R0.w, c[0].x;
MUL result.color, R0, c[13];
DP4 R0.x, R1, c[33];
DP4 result.position.w, R1, c[34];
MOV result.position.z, R0.x;
DP4 result.position.y, R1, c[32];
DP4 result.position.x, R1, c[31];
MOV result.fogcoord.x, R0;
MOV result.texcoord[0], vertex.texcoord[0];
END
# 93 instructions, 5 R-regs
"
}

SubProgram "d3d9 " {
Keywords { }
Bind "vertex", Vertex
Bind "tangent", TexCoord2
Bind "color", Color
Bind "texcoord", TexCoord0
Local 16, [_Scale]
Matrix 0, [_TerrainEngineBendTree]
Local 17, ([_Occlusion],0,0,0)
Local 18, ([_AO],0,0,0)
Local 19, ([_BaseLight],0,0,0)
Local 20, [_Color]
Matrix 4, [_CameraToWorld]
Local 21, [glstate_light0_diffuse]
Local 22, [glstate_light0_position]
Local 23, [glstate_light0_attenuation]
Local 24, [glstate_light1_diffuse]
Local 25, [glstate_light1_position]
Local 26, [glstate_light1_attenuation]
Local 27, [glstate_light2_diffuse]
Local 28, [glstate_light2_position]
Local 29, [glstate_light2_attenuation]
Local 30, [glstate_light3_diffuse]
Local 31, [glstate_light3_position]
Local 32, [glstate_light3_attenuation]
Local 33, [glstate_lightmodel_ambient]
Matrix 8, [glstate_matrix_modelview0]
Matrix 12, [glstate_matrix_mvp]
"vs_1_1
def c34, 0.00000000, 1.00000000, 0, 0
dcl_position v0
dcl_tangent v1
dcl_color v2
dcl_texcoord0 v3
mul r0.xyz, v0, c16
mov r1.w, v0
dp3 r1.z, r0, c2
dp3 r1.x, r0, c0
dp3 r1.y, r0, c1
add r1.xyz, r1, -r0
mad r1.xyz, v2.w, r1, r0
dp4 r3.z, r1, c10
dp4 r3.x, r1, c8
dp4 r3.y, r1, c9
mad r0.xyz, -r3, c28.w, c28
mov r0.yz, -r0
dp3 r2.w, r0, r0
mad r2.xyz, -r3, c22.w, c22
rsq r0.w, r2.w
mul r4.xyz, r0.w, r0
dp3 r0.z, r4, c6
dp3 r0.y, r4, c5
dp3 r0.x, r4, c4
mov r2.yz, -r2
dp3 r4.x, r2, r2
rsq r3.w, r4.x
mul r2.xyz, r3.w, r2
mul r0.xyz, r0, c17.x
mov r0.w, c18.x
dp4 r3.w, v1, r0
max r3.w, r3, c34.x
dp3 r0.z, r2, c6
dp3 r0.y, r2, c5
dp3 r0.x, r2, c4
mul r0.xyz, r0, c17.x
mov r0.w, c18.x
dp4 r0.x, v1, r0
mul r0.y, r4.x, c23.z
add r2.x, r0.y, c34.y
max r0.x, r0, c34
add r0.w, r0.x, c19.x
mad r0.xyz, -r3, c25.w, c25
rcp r4.x, r2.x
mov r2.x, r0
mov r2.yz, -r0
mul r0.x, r0.w, r4
dp3 r4.w, r2, r2
rsq r0.w, r4.w
mul r4.xyz, r0.w, r2
mul r0.xyz, r0.x, c21
add r2.xyz, r0, c33
dp3 r0.z, r4, c6
dp3 r0.x, r4, c4
dp3 r0.y, r4, c5
mul r0.xyz, r0, c17.x
mov r0.w, c18.x
dp4 r0.x, v1, r0
mul r0.w, r2, c29.z
add r2.w, r0, c34.y
mul r4.x, r4.w, c26.z
add r0.y, r4.x, c34
max r0.x, r0, c34
rcp r0.y, r0.y
add r0.x, r0, c19
mul r0.x, r0, r0.y
mad r0.xyz, r0.x, c24, r2
mad r2.xyz, -r3, c31.w, c31
mov r2.yz, -r2
dp3 r0.w, r2, r2
rsq r3.x, r0.w
mul r2.xyz, r3.x, r2
mul r0.w, r0, c32.z
add r0.w, r0, c34.y
add r3.w, r3, c19.x
rcp r2.w, r2.w
mul r2.w, r3, r2
mad r0.xyz, r2.w, c27, r0
dp3 r3.z, r2, c6
dp3 r3.x, r2, c4
dp3 r3.y, r2, c5
mul r2.xyz, r3, c17.x
mov r2.w, c18.x
dp4 r2.x, v1, r2
max r2.x, r2, c34
rcp r0.w, r0.w
add r2.x, r2, c19
mul r0.w, r2.x, r0
mad r0.xyz, r0.w, c30, r0
mov r0.w, c34.y
mul oD0, r0, c20
dp4 r0.x, r1, c14
dp4 oPos.w, r1, c15
mov oPos.z, r0.x
dp4 oPos.y, r1, c13
dp4 oPos.x, r1, c12
mov oFog, r0.x
mov oT0, v3
"
}

}
#LINE 38

			// the texture is premultiplied alpha!
			Blend SrcAlpha OneMinusSrcAlpha
			ZWrite Off

			SetTexture [_MainTex] { combine primary * texture DOUBLE, texture }
		}
		
		// Pass to render object as a shadow caster
		Pass {
			Name "ShadowCaster"
			Tags { "LightMode" = "ShadowCaster" }
			
			Fog {Mode Off}
			ZWrite On ZTest Less Cull Off
			Offset [_ShadowBias], [_ShadowBiasSlope]
	
			Program "" {
// Vertex combos: 2, instructions: 16 to 17
// Fragment combos: 2, instructions: 4 to 10, texreads: 1 to 1
SubProgram "opengl " {
Keywords { "SHADOWS_NATIVE" }
Bind "vertex", Vertex
Bind "color", Color
Bind "texcoord", TexCoord0
Local 5, [_LightDirectionBias]
Local 6, [_Scale]
Matrix 1, [_TerrainEngineBendTree]
"!!ARBvp1.0
# 17 instructions
PARAM c[11] = { program.local[0..6],
		state.matrix.mvp };
TEMP R0;
TEMP R1;
MUL R1.xyz, vertex.position, c[6];
DP3 R0.z, R1, c[3];
DP3 R0.x, R1, c[1];
DP3 R0.y, R1, c[2];
ADD R0.xyz, R0, -R1;
MAD R0.xyz, vertex.color.w, R0, R1;
MOV R0.w, vertex.position;
MAD R0.xyz, c[5], c[5].w, R0;
DP4 R1.x, R0, c[10];
DP4 R1.y, R0, c[9];
SLT R1.z, R1.y, -R1.x;
ADD R1.w, -R1.x, -R1.y;
MAD result.position.z, R1.w, R1, R1.y;
MOV result.position.w, R1.x;
DP4 result.position.y, R0, c[8];
DP4 result.position.x, R0, c[7];
MOV result.texcoord[0].xy, vertex.texcoord[0];
END
# 17 instructions, 2 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "SHADOWS_NATIVE" }
Bind "vertex", Vertex
Bind "color", Color
Bind "texcoord", TexCoord0
Local 8, [_LightDirectionBias]
Local 9, [_Scale]
Matrix 0, [_TerrainEngineBendTree]
Matrix 4, [glstate_matrix_mvp]
"vs_1_1
dcl_position v0
dcl_color v1
dcl_texcoord0 v2
def c10, 0.00000000, 1.00000000, 0, 0
mul r1.xyz, v0, c9
mov r1.w, v0
dp3 r0.z, r1, c2
dp3 r0.x, r1, c0
dp3 r0.y, r1, c1
add r0.xyz, r0, -r1
mad r0.xyz, v1.w, r0, r1
mad r1.xyz, c8, c8.w, r0
dp4 r0.x, r1, c6
slt r0.y, r0.x, c10.x
max r0.y, -r0, r0
slt r0.y, c10.x, r0
add r0.y, -r0, c10
mul r0.z, r0.y, r0.x
dp4 r0.w, r1, c7
dp4 r0.x, r1, c4
dp4 r0.y, r1, c5
mov oPos, r0
mov oT0, r0
mov oT1.xy, v2
"
}

SubProgram "opengl " {
Keywords { "SHADOWS_CUBE" }
Bind "vertex", Vertex
Bind "color", Color
Bind "texcoord", TexCoord0
Matrix 1, [_Object2World]
Local 9, [_LightPositionRange]
Local 10, [_Scale]
Matrix 5, [_TerrainEngineBendTree]
"!!ARBvp1.0
# 16 instructions
PARAM c[15] = { program.local[0..10],
		state.matrix.mvp };
TEMP R0;
TEMP R1;
MUL R0.xyz, vertex.position, c[10];
MOV R1.w, vertex.position;
DP3 R1.z, R0, c[7];
DP3 R1.x, R0, c[5];
DP3 R1.y, R0, c[6];
ADD R1.xyz, R1, -R0;
MAD R1.xyz, vertex.color.w, R1, R0;
DP4 R0.z, R1, c[3];
DP4 R0.x, R1, c[1];
DP4 R0.y, R1, c[2];
ADD result.texcoord[0].xyz, R0, -c[9];
DP4 result.position.w, R1, c[14];
DP4 result.position.z, R1, c[13];
DP4 result.position.y, R1, c[12];
DP4 result.position.x, R1, c[11];
MOV result.texcoord[1].xy, vertex.texcoord[0];
END
# 16 instructions, 2 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "SHADOWS_CUBE" }
Bind "vertex", Vertex
Bind "color", Color
Bind "texcoord", TexCoord0
Matrix 0, [_Object2World]
Local 12, [_LightPositionRange]
Local 13, [_Scale]
Matrix 4, [_TerrainEngineBendTree]
Matrix 8, [glstate_matrix_mvp]
"vs_1_1
dcl_position v0
dcl_color v1
dcl_texcoord0 v2
mul r0.xyz, v0, c13
mov r1.w, v0
dp3 r1.z, r0, c6
dp3 r1.x, r0, c4
dp3 r1.y, r0, c5
add r1.xyz, r1, -r0
mad r1.xyz, v1.w, r1, r0
dp4 r0.z, r1, c2
dp4 r0.x, r1, c0
dp4 r0.y, r1, c1
add oT0.xyz, r0, -c12
dp4 oPos.w, r1, c11
dp4 oPos.z, r1, c10
dp4 oPos.y, r1, c9
dp4 oPos.x, r1, c8
mov oT1.xy, v2
"
}

SubProgram "opengl " {
Keywords { "SHADOWS_NATIVE" }
Local 0, ([_Cutoff],0,0,0)
SetTexture [_MainTex] {2D}
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 4 instructions, 1 texture reads
PARAM c[2] = { program.local[0],
		{ 0 } };
TEMP R0;
TEX R0.w, fragment.texcoord[0], texture[0], 2D;
SLT R0.x, R0.w, c[0];
MOV result.color, c[1].x;
KIL -R0.x;
END
# 4 instructions, 1 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "SHADOWS_NATIVE" }
Local 0, ([_Cutoff],0,0,0)
SetTexture [_MainTex] {2D}
"ps_2_0
dcl_2d s0
def c1, 0.00000000, 1.00000000, 0, 0
dcl t0.xyzw
dcl t1.xy
texld r0, t1, s0
add r0.x, r0.w, -c0
cmp r0.x, r0, c1, c1.y
mov_pp r0, -r0.x
texkill r0.xyzw
rcp r0.x, t0.w
mul r0.x, t0.z, r0
mov r0, r0.x
mov oC0, r0
"
}

SubProgram "opengl " {
Keywords { "SHADOWS_CUBE" }
Local 0, [_LightPositionRange]
Local 1, [_RGBAEncodeDot]
Local 2, [_RGBAEncodeBias]
Local 3, ([_Cutoff],0,0,0)
SetTexture [_MainTex] {2D}
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 10 instructions, 1 texture reads
PARAM c[4] = { program.local[0..3] };
TEMP R0;
TEX R0.w, fragment.texcoord[1], texture[0], 2D;
SLT R0.x, R0.w, c[3];
KIL -R0.x;
DP3 R0.x, fragment.texcoord[0], fragment.texcoord[0];
RSQ R0.x, R0.x;
RCP R0.x, R0.x;
MUL R0.x, R0, c[0].w;
MUL R0, R0.x, c[1];
FRC R0, R0;
ADD result.color, R0, c[2];
END
# 10 instructions, 1 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "SHADOWS_CUBE" }
Local 0, [_LightPositionRange]
Local 1, [_RGBAEncodeDot]
Local 2, [_RGBAEncodeBias]
Local 3, ([_Cutoff],0,0,0)
SetTexture [_MainTex] {2D}
"ps_2_0
dcl_2d s0
def c4, 0.00000000, 1.00000000, 0, 0
dcl t0.xyz
dcl t1.xy
texld r0, t1, s0
add r0.x, r0.w, -c3
cmp r0.x, r0, c4, c4.y
mov_pp r0, -r0.x
texkill r0.xyzw
dp3 r0.x, t0, t0
rsq r0.x, r0.x
rcp r0.x, r0.x
mul r0.x, r0, c0.w
mul r0, r0.x, c1
frc r0, r0
add r0, r0, c2
mov oC0, r0
"
}

}
#LINE 91
	
		}
	}
	
	SubShader {
		Tags {
			"Queue" = "Transparent-99"
			"IgnoreProjector"="True"
			"BillboardShader" = "Hidden/TerrainEngine/Soft Occlusion Leaves rendertex"
			"RenderType" = "TransparentCutout"
		}
		Cull Off
		ColorMask RGB
		Pass {
			AlphaTest GEqual [_Cutoff]
			Lighting On
			Material {
				Diffuse [_Color]
				Ambient [_Color]
			}
			SetTexture [_MainTex] { combine primary * texture DOUBLE, texture }
		}		
	}
	
	Fallback Off
}
