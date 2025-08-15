Shader "Hidden/TerrainEngine/Soft Occlusion Leaves rendertex" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,0)
		_MainTex ("Main Texture", 2D) = "white" { }
		_HalfOverCutoff ("0.5 / alpha cutoff", Range(0,1)) = 1.0
		_BaseLight ("BaseLight", range (0, 1)) = 0.35
		_AO ("Amb. Occlusion", range (0, 10)) = 2.4
		_Occlusion ("Dir Occlusion", range (0, 20)) = 7.5
		_Scale ("Scale", Vector) = (1,1,1,1)
	}
	SubShader {
		#LINE 16


		Tags { "Queue" = "Transparent-99" }
		Cull Off
		Fog { Mode Off}
		
		Pass {
			Program "" {
// Vertex combos: 1, instructions: 42 to 42
SubProgram "opengl " {
Keywords { }
Bind "vertex", Vertex
Bind "tangent", ATTR14
Bind "color", Color
Bind "texcoord", TexCoord0
Local 5, [_Scale]
Matrix 1, [_TerrainEngineBendTree]
Local 6, ([_Occlusion],0,0,0)
Local 7, ([_AO],0,0,0)
Local 8, ([_BaseLight],0,0,0)
Local 9, [_Color]
Local 10, [_TerrainTreeLightDirections0]
Local 11, [_TerrainTreeLightDirections1]
Local 12, [_TerrainTreeLightDirections2]
Local 13, [_TerrainTreeLightDirections3]
"!!ARBvp1.0
# 42 instructions
PARAM c[23] = { { 0, 1 },
		program.local[1..13],
		state.light[0].diffuse,
		state.light[1].diffuse,
		state.light[2].diffuse,
		state.light[3].diffuse,
		state.lightmodel.ambient,
		state.matrix.mvp };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.w, c[6].x;
MOV R0.w, c[7].x;
MUL R0.xyz, R1.w, c[10];
DP4 R0.x, vertex.attrib[14], R0;
MAX R0.x, R0, c[0];
ADD R1.x, R0, c[8];
MUL R0.xyz, R1.w, c[11];
MOV R0.w, c[7].x;
DP4 R0.w, vertex.attrib[14], R0;
MUL R0.xyz, R1.x, c[14];
MAX R0.w, R0, c[0].x;
ADD R0.xyz, R0, c[18];
ADD R0.w, R0, c[8].x;
MAD R1.xyz, R0.w, c[15], R0;
MOV R0.w, c[7].x;
MUL R0.xyz, R1.w, c[12];
DP4 R2.x, vertex.attrib[14], R0;
MUL R0.xyz, R1.w, c[13];
MOV R0.w, c[7].x;
DP4 R0.x, vertex.attrib[14], R0;
MAX R0.y, R2.x, c[0].x;
ADD R0.y, R0, c[8].x;
MAX R0.x, R0, c[0];
MAD R1.xyz, R0.y, c[16], R1;
ADD R0.x, R0, c[8];
MAD R0.xyz, R0.x, c[17], R1;
MOV R0.w, c[0].y;
MUL result.color, R0, c[9];
MUL R1.xyz, vertex.position, c[5];
MOV R0.w, vertex.position;
DP3 R0.z, R1, c[3];
DP3 R0.x, R1, c[1];
DP3 R0.y, R1, c[2];
ADD R0.xyz, R0, -R1;
MAD R0.xyz, vertex.color.w, R0, R1;
DP4 R1.x, R0, c[21];
DP4 result.position.w, R0, c[22];
MOV result.position.z, R1.x;
DP4 result.position.y, R0, c[20];
DP4 result.position.x, R0, c[19];
MOV result.fogcoord.x, R1;
MOV result.texcoord[0], vertex.texcoord[0];
END
# 42 instructions, 3 R-regs
"
}

SubProgram "d3d9 " {
Keywords { }
Bind "vertex", Vertex
Bind "tangent", TexCoord2
Bind "color", Color
Bind "texcoord", TexCoord0
Local 12, [_Scale]
Matrix 0, [_TerrainEngineBendTree]
Local 13, ([_Occlusion],0,0,0)
Local 14, ([_AO],0,0,0)
Local 15, ([_BaseLight],0,0,0)
Local 16, [_Color]
Local 17, [_TerrainTreeLightDirections0]
Local 18, [_TerrainTreeLightDirections1]
Local 19, [_TerrainTreeLightDirections2]
Local 20, [_TerrainTreeLightDirections3]
Local 21, [glstate_light0_diffuse]
Local 22, [glstate_light1_diffuse]
Local 23, [glstate_light2_diffuse]
Local 24, [glstate_light3_diffuse]
Local 25, [glstate_lightmodel_ambient]
Matrix 8, [glstate_matrix_mvp]
"vs_1_1
def c26, 0.00000000, 1.00000000, 0, 0
dcl_position v0
dcl_tangent v1
dcl_color v2
dcl_texcoord0 v3
mov r0.xyz, c17
mul r0.xyz, c13.x, r0
mov r0.w, c14.x
dp4 r0.x, v1, r0
max r0.x, r0, c26
add r1.x, r0, c15
mov r0.xyz, c18
mul r1.xyz, r1.x, c21
mul r0.xyz, c13.x, r0
mov r0.w, c14.x
dp4 r0.x, v1, r0
max r0.x, r0, c26
add r0.x, r0, c15
add r1.xyz, r1, c25
mad r1.xyz, r0.x, c22, r1
mov r0.xyz, c19
mov r0.w, c14.x
mul r0.xyz, c13.x, r0
dp4 r1.w, v1, r0
mov r0.xyz, c20
mul r0.xyz, c13.x, r0
mov r0.w, c14.x
dp4 r0.x, v1, r0
max r0.y, r1.w, c26.x
add r0.y, r0, c15.x
max r0.x, r0, c26
mad r1.xyz, r0.y, c23, r1
add r0.x, r0, c15
mad r0.xyz, r0.x, c24, r1
mov r0.w, c26.y
mul oD0, r0, c16
mul r1.xyz, v0, c12
mov r0.w, v0
dp3 r0.z, r1, c2
dp3 r0.x, r1, c0
dp3 r0.y, r1, c1
add r0.xyz, r0, -r1
mad r0.xyz, v2.w, r0, r1
dp4 r1.x, r0, c10
dp4 oPos.w, r0, c11
mov oPos.z, r1.x
dp4 oPos.y, r0, c9
dp4 oPos.x, r0, c8
mov oFog, r1.x
mov oT0, v3
"
}

}
#LINE 24

			ZWrite On
			// Here we want to do alpha testing on cutoff, but at the same
			// time write 1.0 into alpha. So we multiply alpha by 1/cutoff
			// and alpha test on alpha being 1.0
			AlphaTest GEqual 1.0
			SetTexture [_MainTex] {
				constantColor(0,0,0,[_HalfOverCutoff])
				combine primary * texture double, texture * constant DOUBLE
			}
		}
		
		Pass {
			Program "" {
// Vertex combos: 1, instructions: 42 to 42
SubProgram "opengl " {
Keywords { }
Bind "vertex", Vertex
Bind "tangent", ATTR14
Bind "color", Color
Bind "texcoord", TexCoord0
Local 5, [_Scale]
Matrix 1, [_TerrainEngineBendTree]
Local 6, ([_Occlusion],0,0,0)
Local 7, ([_AO],0,0,0)
Local 8, ([_BaseLight],0,0,0)
Local 9, [_Color]
Local 10, [_TerrainTreeLightDirections0]
Local 11, [_TerrainTreeLightDirections1]
Local 12, [_TerrainTreeLightDirections2]
Local 13, [_TerrainTreeLightDirections3]
"!!ARBvp1.0
# 42 instructions
PARAM c[23] = { { 0, 1 },
		program.local[1..13],
		state.light[0].diffuse,
		state.light[1].diffuse,
		state.light[2].diffuse,
		state.light[3].diffuse,
		state.lightmodel.ambient,
		state.matrix.mvp };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.w, c[6].x;
MOV R0.w, c[7].x;
MUL R0.xyz, R1.w, c[10];
DP4 R0.x, vertex.attrib[14], R0;
MAX R0.x, R0, c[0];
ADD R1.x, R0, c[8];
MUL R0.xyz, R1.w, c[11];
MOV R0.w, c[7].x;
DP4 R0.w, vertex.attrib[14], R0;
MUL R0.xyz, R1.x, c[14];
MAX R0.w, R0, c[0].x;
ADD R0.xyz, R0, c[18];
ADD R0.w, R0, c[8].x;
MAD R1.xyz, R0.w, c[15], R0;
MOV R0.w, c[7].x;
MUL R0.xyz, R1.w, c[12];
DP4 R2.x, vertex.attrib[14], R0;
MUL R0.xyz, R1.w, c[13];
MOV R0.w, c[7].x;
DP4 R0.x, vertex.attrib[14], R0;
MAX R0.y, R2.x, c[0].x;
ADD R0.y, R0, c[8].x;
MAX R0.x, R0, c[0];
MAD R1.xyz, R0.y, c[16], R1;
ADD R0.x, R0, c[8];
MAD R0.xyz, R0.x, c[17], R1;
MOV R0.w, c[0].y;
MUL result.color, R0, c[9];
MUL R1.xyz, vertex.position, c[5];
MOV R0.w, vertex.position;
DP3 R0.z, R1, c[3];
DP3 R0.x, R1, c[1];
DP3 R0.y, R1, c[2];
ADD R0.xyz, R0, -R1;
MAD R0.xyz, vertex.color.w, R0, R1;
DP4 R1.x, R0, c[21];
DP4 result.position.w, R0, c[22];
MOV result.position.z, R1.x;
DP4 result.position.y, R0, c[20];
DP4 result.position.x, R0, c[19];
MOV result.fogcoord.x, R1;
MOV result.texcoord[0], vertex.texcoord[0];
END
# 42 instructions, 3 R-regs
"
}

SubProgram "d3d9 " {
Keywords { }
Bind "vertex", Vertex
Bind "tangent", TexCoord2
Bind "color", Color
Bind "texcoord", TexCoord0
Local 12, [_Scale]
Matrix 0, [_TerrainEngineBendTree]
Local 13, ([_Occlusion],0,0,0)
Local 14, ([_AO],0,0,0)
Local 15, ([_BaseLight],0,0,0)
Local 16, [_Color]
Local 17, [_TerrainTreeLightDirections0]
Local 18, [_TerrainTreeLightDirections1]
Local 19, [_TerrainTreeLightDirections2]
Local 20, [_TerrainTreeLightDirections3]
Local 21, [glstate_light0_diffuse]
Local 22, [glstate_light1_diffuse]
Local 23, [glstate_light2_diffuse]
Local 24, [glstate_light3_diffuse]
Local 25, [glstate_lightmodel_ambient]
Matrix 8, [glstate_matrix_mvp]
"vs_1_1
def c26, 0.00000000, 1.00000000, 0, 0
dcl_position v0
dcl_tangent v1
dcl_color v2
dcl_texcoord0 v3
mov r0.xyz, c17
mul r0.xyz, c13.x, r0
mov r0.w, c14.x
dp4 r0.x, v1, r0
max r0.x, r0, c26
add r1.x, r0, c15
mov r0.xyz, c18
mul r1.xyz, r1.x, c21
mul r0.xyz, c13.x, r0
mov r0.w, c14.x
dp4 r0.x, v1, r0
max r0.x, r0, c26
add r0.x, r0, c15
add r1.xyz, r1, c25
mad r1.xyz, r0.x, c22, r1
mov r0.xyz, c19
mov r0.w, c14.x
mul r0.xyz, c13.x, r0
dp4 r1.w, v1, r0
mov r0.xyz, c20
mul r0.xyz, c13.x, r0
mov r0.w, c14.x
dp4 r0.x, v1, r0
max r0.y, r1.w, c26.x
add r0.y, r0, c15.x
max r0.x, r0, c26
mad r1.xyz, r0.y, c23, r1
add r0.x, r0, c15
mad r0.xyz, r0.x, c24, r1
mov r0.w, c26.y
mul oD0, r0, c16
mul r1.xyz, v0, c12
mov r0.w, v0
dp3 r0.z, r1, c2
dp3 r0.x, r1, c0
dp3 r0.y, r1, c1
add r0.xyz, r0, -r1
mad r0.xyz, v2.w, r0, r1
dp4 r1.x, r0, c10
dp4 oPos.w, r0, c11
mov oPos.z, r1.x
dp4 oPos.y, r0, c9
dp4 oPos.x, r0, c8
mov oFog, r1.x
mov oT0, v3
"
}

}
#LINE 38


			Blend One OneMinusSrcAlpha
			ZWrite Off
			SetTexture [_MainTex] { combine primary * texture double, texture }
			SetTexture [_MainTex] { combine previous alpha * previous, previous }
		}
	}
	
	Fallback Off
}
