Shader "Nature/Soft Occlusion Bark" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,0)
		_MainTex ("Main Texture", 2D) = "white" {  }
		_BaseLight ("BaseLight", range (0, 1)) = 0.35
		_AO ("Amb. Occlusion", range (0, 10)) = 2.4
		_Scale ("Scale", Vector) = (1,1,1,1)
	}
	SubShader {
		Tags {
			"IgnoreProjector"="True"
			"BillboardShader" = "Hidden/TerrainEngine/Soft Occlusion Bark rendertex"
			"RenderType" = "TreeOpaque"
		}

		Pass {
			Program "" {
// Vertex combos: 1, instructions: 87 to 87
SubProgram "opengl " {
Keywords { }
Bind "vertex", Vertex
Bind "tangent", ATTR14
Bind "normal", Normal
Bind "color", Color
Bind "texcoord", TexCoord0
Local 9, [_Scale]
Matrix 1, [_TerrainEngineBendTree]
Local 10, ([_AO],0,0,0)
Local 11, ([_BaseLight],0,0,0)
Local 12, [_Color]
Matrix 5, [_CameraToWorld]
"!!ARBvp1.0
# 87 instructions
PARAM c[34] = { { 1, 0 },
		program.local[1..12],
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
DP4 R2.z, R1, c[28];
DP4 R2.x, R1, c[26];
DP4 R2.y, R1, c[27];
MAD R3.xyz, -R2, c[20].w, c[20];
MAD R0.xyz, -R2, c[14].w, c[14];
MOV R0.yz, -R0;
DP3 R2.w, R0, R0;
MOV R3.yz, -R3;
DP3 R0.w, R3, R3;
RSQ R4.x, R0.w;
MUL R4.xyz, R4.x, R3;
RSQ R3.w, R2.w;
MUL R3.xyz, R3.w, R0;
DP3 R0.z, R4, c[7];
DP3 R0.x, R4, c[5];
DP3 R0.y, R4, c[6];
DP3 R3.w, vertex.normal, R0;
DP3 R0.z, R3, c[7];
DP3 R0.y, R3, c[6];
DP3 R0.x, R3, c[5];
DP3 R0.x, vertex.normal, R0;
MUL R0.y, R2.w, c[15].z;
ADD R3.x, R0.y, c[0];
MUL R0.z, vertex.attrib[14].w, c[10].x;
ADD R2.w, R0.z, c[11].x;
MAX R0.x, R0, c[0].y;
MUL R4.x, R2.w, R0;
MAD R0.xyz, -R2, c[17].w, c[17];
MAD R2.xyz, -R2, c[23].w, c[23];
RCP R4.y, R3.x;
MOV R3.x, R0;
MOV R3.yz, -R0;
MUL R0.x, R4, R4.y;
DP3 R4.w, R3, R3;
RSQ R4.x, R4.w;
MUL R4.xyz, R4.x, R3;
MUL R0.xyz, R0.x, c[13];
ADD R3.xyz, R0, c[25];
DP3 R0.z, R4, c[7];
DP3 R0.y, R4, c[6];
DP3 R0.x, R4, c[5];
DP3 R0.x, vertex.normal, R0;
MUL R4.x, R4.w, c[18].z;
ADD R0.y, R4.x, c[0].x;
MAX R0.x, R0, c[0].y;
RCP R0.y, R0.y;
MUL R0.x, R2.w, R0;
MUL R0.x, R0, R0.y;
MAD R0.xyz, R0.x, c[16], R3;
MUL R0.w, R0, c[21].z;
ADD R3.y, R0.w, c[0].x;
MOV R2.yz, -R2;
MAX R3.w, R3, c[0].y;
DP3 R0.w, R2, R2;
RCP R3.z, R3.y;
RSQ R3.y, R0.w;
MUL R2.xyz, R3.y, R2;
MUL R3.x, R2.w, R3.w;
MUL R3.x, R3, R3.z;
MAD R0.xyz, R3.x, c[19], R0;
MUL R0.w, R0, c[24].z;
ADD R0.w, R0, c[0].x;
DP3 R3.z, R2, c[7];
DP3 R3.y, R2, c[6];
DP3 R3.x, R2, c[5];
DP3 R2.x, R3, vertex.normal;
MAX R2.x, R2, c[0].y;
RCP R0.w, R0.w;
MUL R2.x, R2, R2.w;
MUL R0.w, R2.x, R0;
MAD R0.xyz, R0.w, c[22], R0;
MOV R0.w, c[0].x;
MUL result.color, R0, c[12];
DP4 R0.x, R1, c[32];
DP4 result.position.w, R1, c[33];
MOV result.position.z, R0.x;
DP4 result.position.y, R1, c[31];
DP4 result.position.x, R1, c[30];
MOV result.fogcoord.x, R0;
MOV result.texcoord[0], vertex.texcoord[0];
END
# 87 instructions, 5 R-regs
"
}

SubProgram "d3d9 " {
Keywords { }
Bind "vertex", Vertex
Bind "tangent", TexCoord2
Bind "normal", Normal
Bind "color", Color
Bind "texcoord", TexCoord0
Local 16, [_Scale]
Matrix 0, [_TerrainEngineBendTree]
Local 17, ([_AO],0,0,0)
Local 18, ([_BaseLight],0,0,0)
Local 19, [_Color]
Matrix 4, [_CameraToWorld]
Local 20, [glstate_light0_diffuse]
Local 21, [glstate_light0_position]
Local 22, [glstate_light0_attenuation]
Local 23, [glstate_light1_diffuse]
Local 24, [glstate_light1_position]
Local 25, [glstate_light1_attenuation]
Local 26, [glstate_light2_diffuse]
Local 27, [glstate_light2_position]
Local 28, [glstate_light2_attenuation]
Local 29, [glstate_light3_diffuse]
Local 30, [glstate_light3_position]
Local 31, [glstate_light3_attenuation]
Local 32, [glstate_lightmodel_ambient]
Matrix 8, [glstate_matrix_modelview0]
Matrix 12, [glstate_matrix_mvp]
"vs_1_1
def c33, 0.00000000, 1.00000000, 0, 0
dcl_position v0
dcl_tangent v1
dcl_normal v2
dcl_color v3
dcl_texcoord0 v4
mul r0.xyz, v0, c16
mov r1.w, v0
dp3 r1.z, r0, c2
dp3 r1.x, r0, c0
dp3 r1.y, r0, c1
add r1.xyz, r1, -r0
mad r1.xyz, v3.w, r1, r0
dp4 r2.z, r1, c10
dp4 r2.x, r1, c8
dp4 r2.y, r1, c9
mad r3.xyz, -r2, c27.w, c27
mad r0.xyz, -r2, c21.w, c21
mov r0.yz, -r0
dp3 r2.w, r0, r0
mov r3.yz, -r3
dp3 r0.w, r3, r3
rsq r4.x, r0.w
mul r4.xyz, r4.x, r3
rsq r3.w, r2.w
mul r3.xyz, r3.w, r0
dp3 r0.z, r4, c6
dp3 r0.x, r4, c4
dp3 r0.y, r4, c5
dp3 r3.w, v2, r0
dp3 r0.z, r3, c6
dp3 r0.y, r3, c5
dp3 r0.x, r3, c4
dp3 r0.x, v2, r0
mul r0.y, r2.w, c22.z
add r3.x, r0.y, c33.y
mul r0.z, v1.w, c17.x
add r2.w, r0.z, c18.x
max r0.x, r0, c33
mul r4.x, r2.w, r0
mad r0.xyz, -r2, c24.w, c24
mad r2.xyz, -r2, c30.w, c30
rcp r4.y, r3.x
mov r3.x, r0
mov r3.yz, -r0
mul r0.x, r4, r4.y
dp3 r4.w, r3, r3
rsq r4.x, r4.w
mul r4.xyz, r4.x, r3
mul r0.xyz, r0.x, c20
add r3.xyz, r0, c32
dp3 r0.z, r4, c6
dp3 r0.y, r4, c5
dp3 r0.x, r4, c4
dp3 r0.x, v2, r0
mul r4.x, r4.w, c25.z
add r0.y, r4.x, c33
max r0.x, r0, c33
rcp r0.y, r0.y
mul r0.x, r2.w, r0
mul r0.x, r0, r0.y
mad r0.xyz, r0.x, c23, r3
mul r0.w, r0, c28.z
add r3.y, r0.w, c33
mov r2.yz, -r2
max r3.w, r3, c33.x
dp3 r0.w, r2, r2
rcp r3.z, r3.y
rsq r3.y, r0.w
mul r2.xyz, r3.y, r2
mul r3.x, r2.w, r3.w
mul r3.x, r3, r3.z
mad r0.xyz, r3.x, c26, r0
mul r0.w, r0, c31.z
add r0.w, r0, c33.y
dp3 r3.z, r2, c6
dp3 r3.y, r2, c5
dp3 r3.x, r2, c4
dp3 r2.x, r3, v2
max r2.x, r2, c33
rcp r0.w, r0.w
mul r2.x, r2, r2.w
mul r0.w, r2.x, r0
mad r0.xyz, r0.w, c29, r0
mov r0.w, c33.y
mul oD0, r0, c19
dp4 r0.x, r1, c14
dp4 oPos.w, r1, c15
mov oPos.z, r0.x
dp4 oPos.y, r1, c13
dp4 oPos.x, r1, c12
mov oFog, r0.x
mov oT0, v4
"
}

}
#LINE 20

						
			SetTexture [_MainTex] { combine primary * texture DOUBLE, constant }
		}
		
		// Pass to render object as a shadow caster
		Pass {
			Name "ShadowCaster"
			Tags { "LightMode" = "ShadowCaster" }
			
			Fog {Mode Off}
			ZWrite On ZTest Less Cull Off
			Offset [_ShadowBias], [_ShadowBiasSlope]
	
			Program "" {
// Vertex combos: 2, instructions: 15 to 16
// Fragment combos: 2, instructions: 1 to 7, texreads: 0 to 0
SubProgram "opengl " {
Keywords { "SHADOWS_NATIVE" }
Bind "vertex", Vertex
Bind "color", Color
Local 5, [_LightDirectionBias]
Local 6, [_Scale]
Matrix 1, [_TerrainEngineBendTree]
"!!ARBvp1.0
# 16 instructions
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
END
# 16 instructions, 2 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "SHADOWS_NATIVE" }
Bind "vertex", Vertex
Bind "color", Color
Local 8, [_LightDirectionBias]
Local 9, [_Scale]
Matrix 0, [_TerrainEngineBendTree]
Matrix 4, [glstate_matrix_mvp]
"vs_1_1
dcl_position v0
dcl_color v1
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
"
}

SubProgram "opengl " {
Keywords { "SHADOWS_CUBE" }
Bind "vertex", Vertex
Bind "color", Color
Matrix 1, [_Object2World]
Local 9, [_LightPositionRange]
Local 10, [_Scale]
Matrix 5, [_TerrainEngineBendTree]
"!!ARBvp1.0
# 15 instructions
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
END
# 15 instructions, 2 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "SHADOWS_CUBE" }
Bind "vertex", Vertex
Bind "color", Color
Matrix 0, [_Object2World]
Local 12, [_LightPositionRange]
Local 13, [_Scale]
Matrix 4, [_TerrainEngineBendTree]
Matrix 8, [glstate_matrix_mvp]
"vs_1_1
dcl_position v0
dcl_color v1
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
"
}

SubProgram "opengl " {
Keywords { "SHADOWS_NATIVE" }
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 1 instructions, 0 texture reads
PARAM c[1] = { { 0 } };
MOV result.color, c[0].x;
END
# 1 instructions, 0 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "SHADOWS_NATIVE" }
"ps_2_0
dcl t0.xyzw
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
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 7 instructions, 0 texture reads
PARAM c[3] = { program.local[0..2] };
TEMP R0;
DP3 R0.x, fragment.texcoord[0], fragment.texcoord[0];
RSQ R0.x, R0.x;
RCP R0.x, R0.x;
MUL R0.x, R0, c[0].w;
MUL R0, R0.x, c[1];
FRC R0, R0;
ADD result.color, R0, c[2];
END
# 7 instructions, 1 R-regs
"
}

SubProgram "d3d9 " {
Keywords { "SHADOWS_CUBE" }
Local 0, [_LightPositionRange]
Local 1, [_RGBAEncodeDot]
Local 2, [_RGBAEncodeBias]
"ps_2_0
dcl t0.xyz
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
#LINE 62
	
		}
	}
	SubShader {
		Tags {
			"IgnoreProjector"="True"
			"BillboardShader" = "Hidden/TerrainEngine/Soft Occlusion Bark rendertex"
			"RenderType" = "Opaque"
		}
		Pass {
			Lighting On
			Material {
				Diffuse [_Color]
				Ambient [_Color]
			}
			SetTexture [_MainTex] { combine primary * texture DOUBLE, constant }
		}		
	}
	
	Fallback Off
}
