Shader "Hidden/TerrainEngine/Soft Occlusion Bark rendertex" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,0)
		_MainTex ("Main Texture", 2D) = "white" {  }
		_BaseLight ("BaseLight", range (0, 1)) = 0.35
		_AO ("Amb. Occlusion", range (0, 10)) = 2.4
		_Scale ("Scale", Vector) = (1,1,1,1)
	}
	SubShader {
		Fog { Mode Off }
		Pass {
			Program "" {
// Vertex combos: 1, instructions: 35 to 35
SubProgram "opengl " {
Keywords { }
Bind "vertex", Vertex
Bind "tangent", ATTR14
Bind "normal", Normal
Bind "color", Color
Bind "texcoord", TexCoord0
Local 5, [_Scale]
Matrix 1, [_TerrainEngineBendTree]
Local 6, ([_AO],0,0,0)
Local 7, ([_BaseLight],0,0,0)
Local 8, [_Color]
Local 9, [_TerrainTreeLightDirections0]
Local 10, [_TerrainTreeLightDirections1]
Local 11, [_TerrainTreeLightDirections2]
Local 12, [_TerrainTreeLightDirections3]
"!!ARBvp1.0
# 35 instructions
PARAM c[22] = { { 0, 1 },
		program.local[1..12],
		state.light[0].diffuse,
		state.light[1].diffuse,
		state.light[2].diffuse,
		state.light[3].diffuse,
		state.lightmodel.ambient,
		state.matrix.mvp };
TEMP R0;
TEMP R1;
MUL R1.xyz, vertex.position, c[5];
MOV R0.w, vertex.position;
DP3 R0.z, R1, c[3];
DP3 R0.x, R1, c[1];
DP3 R0.y, R1, c[2];
ADD R0.xyz, R0, -R1;
MAD R0.xyz, vertex.color.w, R0, R1;
DP4 R1.x, R0, c[20];
DP4 result.position.w, R0, c[21];
DP4 result.position.y, R0, c[19];
DP4 result.position.x, R0, c[18];
MUL R0.y, vertex.attrib[14].w, c[6].x;
DP3 R0.x, vertex.normal, c[9];
DP3 R0.w, vertex.normal, c[10];
ADD R1.y, R0, c[7].x;
MAX R0.w, R0, c[0].x;
MUL R1.z, R1.y, R0.w;
MAX R0.x, R0, c[0];
MUL R0.x, R1.y, R0;
MUL R0.xyz, R0.x, c[13];
ADD R0.xyz, R0, c[17];
DP3 R0.w, vertex.normal, c[11];
MAD R0.xyz, R1.z, c[14], R0;
MAX R1.z, R0.w, c[0].x;
DP3 R0.w, vertex.normal, c[12];
MUL R1.z, R1.y, R1;
MAX R0.w, R0, c[0].x;
MAD R0.xyz, R1.z, c[15], R0;
MUL R0.w, R0, R1.y;
MAD R0.xyz, R0.w, c[16], R0;
MOV result.position.z, R1.x;
MOV result.fogcoord.x, R1;
MUL result.color.xyz, R0, c[8];
MOV result.texcoord[0], vertex.texcoord[0];
MOV result.color.w, c[0].y;
END
# 35 instructions, 2 R-regs
"
}

SubProgram "d3d9 " {
Keywords { }
Bind "vertex", Vertex
Bind "tangent", TexCoord2
Bind "normal", Normal
Bind "color", Color
Bind "texcoord", TexCoord0
Local 12, [_Scale]
Matrix 0, [_TerrainEngineBendTree]
Local 13, ([_AO],0,0,0)
Local 14, ([_BaseLight],0,0,0)
Local 15, [_Color]
Local 16, [_TerrainTreeLightDirections0]
Local 17, [_TerrainTreeLightDirections1]
Local 18, [_TerrainTreeLightDirections2]
Local 19, [_TerrainTreeLightDirections3]
Local 20, [glstate_light0_diffuse]
Local 21, [glstate_light1_diffuse]
Local 22, [glstate_light2_diffuse]
Local 23, [glstate_light3_diffuse]
Local 24, [glstate_lightmodel_ambient]
Matrix 8, [glstate_matrix_mvp]
"vs_1_1
def c25, 0.00000000, 1.00000000, 0, 0
dcl_position v0
dcl_tangent v1
dcl_normal v2
dcl_color v3
dcl_texcoord0 v4
mul r1.xyz, v0, c12
mov r0.w, v0
dp3 r0.z, r1, c2
dp3 r0.x, r1, c0
dp3 r0.y, r1, c1
add r0.xyz, r0, -r1
mad r0.xyz, v3.w, r0, r1
dp4 r1.x, r0, c10
dp4 oPos.w, r0, c11
dp4 oPos.y, r0, c9
dp4 oPos.x, r0, c8
mul r0.y, v1.w, c13.x
dp3 r0.x, v2, c16
dp3 r0.w, v2, c17
add r1.y, r0, c14.x
max r0.w, r0, c25.x
mul r1.z, r1.y, r0.w
max r0.x, r0, c25
mul r0.x, r1.y, r0
mul r0.xyz, r0.x, c20
add r0.xyz, r0, c24
dp3 r0.w, v2, c18
mad r0.xyz, r1.z, c21, r0
max r1.z, r0.w, c25.x
dp3 r0.w, v2, c19
mul r1.z, r1.y, r1
max r0.w, r0, c25.x
mad r0.xyz, r1.z, c22, r0
mul r0.w, r0, r1.y
mad r0.xyz, r0.w, c23, r0
mov oPos.z, r1.x
mov oFog, r1.x
mul oD0.xyz, r0, c15
mov oT0, v4
mov oD0.w, c25.y
"
}

}
#LINE 17

			
			SetTexture [_MainTex] {
				combine primary * texture double, primary
			}
		}
	}
	
	Fallback Off
}