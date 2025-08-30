// cee00d2aaa71742248a1a43893a85c11, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MeshCombineUtility
using UnityEngine;

public class MeshCombineUtility
{
	public struct MeshInstance
	{
		public Mesh mesh;

		public int subMeshIndex;

		public Matrix4x4 transform;
	}

	public static Mesh Combine(MeshInstance[] combines, bool generateStrips)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = combines.Length;
		for (int i = 0; i < num4; i++)
		{
			MeshInstance meshInstance = combines[i];
			if (!meshInstance.mesh)
			{
				continue;
			}
			num += meshInstance.mesh.vertexCount;
			if (!generateStrips)
			{
				continue;
			}
			int num5 = meshInstance.mesh.GetTriangleStrip(meshInstance.subMeshIndex).Length;
			if (num5 != 0)
			{
				if (num3 != 0)
				{
					num3 = (((num3 & 1) != 1) ? (num3 + 2) : (num3 + 3));
				}
				num3 += num5;
			}
			else
			{
				generateStrips = false;
			}
		}
		if (!generateStrips)
		{
			int num6 = combines.Length;
			for (int j = 0; j < num6; j++)
			{
				MeshInstance meshInstance2 = combines[j];
				if ((bool)meshInstance2.mesh)
				{
					num2 += meshInstance2.mesh.GetTriangles(meshInstance2.subMeshIndex).Length;
				}
			}
		}
		Vector3[] array = new Vector3[num];
		Vector3[] array2 = new Vector3[num];
		Vector4[] array3 = new Vector4[num];
		Vector2[] array4 = new Vector2[num];
		Vector2[] array5 = new Vector2[num];
		Color[] array6 = new Color[num];
		int[] array7 = new int[num2];
		int[] array8 = new int[num3];
		int offset = 0;
		int num7 = combines.Length;
		for (int k = 0; k < num7; k++)
		{
			MeshInstance meshInstance3 = combines[k];
			if ((bool)meshInstance3.mesh)
			{
				Copy(meshInstance3.mesh.vertexCount, meshInstance3.mesh.vertices, array, ref offset, meshInstance3.transform);
			}
		}
		offset = 0;
		int num8 = combines.Length;
		for (int l = 0; l < num8; l++)
		{
			MeshInstance meshInstance4 = combines[l];
			if ((bool)meshInstance4.mesh)
			{
				Matrix4x4 transform = meshInstance4.transform;
				transform = transform.inverse.transpose;
				CopyNormal(meshInstance4.mesh.vertexCount, meshInstance4.mesh.normals, array2, ref offset, transform);
			}
		}
		offset = 0;
		int num9 = combines.Length;
		for (int m = 0; m < num9; m++)
		{
			MeshInstance meshInstance5 = combines[m];
			if ((bool)meshInstance5.mesh)
			{
				Matrix4x4 transform2 = meshInstance5.transform;
				transform2 = transform2.inverse.transpose;
				CopyTangents(meshInstance5.mesh.vertexCount, meshInstance5.mesh.tangents, array3, ref offset, transform2);
			}
		}
		offset = 0;
		int num10 = combines.Length;
		for (int n = 0; n < num10; n++)
		{
			MeshInstance meshInstance6 = combines[n];
			if ((bool)meshInstance6.mesh)
			{
				Copy(meshInstance6.mesh.vertexCount, meshInstance6.mesh.uv, array4, ref offset);
			}
		}
		offset = 0;
		int num11 = combines.Length;
		for (int num12 = 0; num12 < num11; num12++)
		{
			MeshInstance meshInstance7 = combines[num12];
			if ((bool)meshInstance7.mesh)
			{
				Copy(meshInstance7.mesh.vertexCount, meshInstance7.mesh.uv1, array5, ref offset);
			}
		}
		offset = 0;
		int num13 = combines.Length;
		for (int num14 = 0; num14 < num13; num14++)
		{
			MeshInstance meshInstance8 = combines[num14];
			if ((bool)meshInstance8.mesh)
			{
				CopyColors(meshInstance8.mesh.vertexCount, meshInstance8.mesh.colors, array6, ref offset);
			}
		}
		int num15 = 0;
		int num16 = 0;
		int num17 = 0;
		int num18 = combines.Length;
		for (int num19 = 0; num19 < num18; num19++)
		{
			MeshInstance meshInstance9 = combines[num19];
			if (!meshInstance9.mesh)
			{
				continue;
			}
			if (generateStrips)
			{
				int[] triangleStrip = meshInstance9.mesh.GetTriangleStrip(meshInstance9.subMeshIndex);
				if (num16 != 0)
				{
					if ((num16 & 1) == 1)
					{
						array8[num16 + 0] = array8[num16 - 1];
						array8[num16 + 1] = triangleStrip[0] + num17;
						array8[num16 + 2] = triangleStrip[0] + num17;
						num16 += 3;
					}
					else
					{
						array8[num16 + 0] = array8[num16 - 1];
						array8[num16 + 1] = triangleStrip[0] + num17;
						num16 += 2;
					}
				}
				for (int num20 = 0; num20 < triangleStrip.Length; num20++)
				{
					array8[num20 + num16] = triangleStrip[num20] + num17;
				}
				num16 += triangleStrip.Length;
			}
			else
			{
				int[] triangles = meshInstance9.mesh.GetTriangles(meshInstance9.subMeshIndex);
				for (int num21 = 0; num21 < triangles.Length; num21++)
				{
					array7[num21 + num15] = triangles[num21] + num17;
				}
				num15 += triangles.Length;
			}
			num17 += meshInstance9.mesh.vertexCount;
		}
		Mesh mesh = new Mesh();
		mesh.name = "Combined Mesh";
		mesh.vertices = array;
		mesh.normals = array2;
		mesh.colors = array6;
		mesh.uv = array4;
		mesh.uv1 = array5;
		mesh.tangents = array3;
		if (generateStrips)
		{
			mesh.SetTriangleStrip(array8, 0);
		}
		else
		{
			mesh.triangles = array7;
		}
		return mesh;
	}

	private static void Copy(int vertexcount, Vector3[] src, Vector3[] dst, ref int offset, Matrix4x4 transform)
	{
		for (int i = 0; i < src.Length; i++)
		{
			ref Vector3 reference = ref dst[i + offset];
			reference = transform.MultiplyPoint(src[i]);
		}
		offset += vertexcount;
	}

	private static void CopyNormal(int vertexcount, Vector3[] src, Vector3[] dst, ref int offset, Matrix4x4 transform)
	{
		for (int i = 0; i < src.Length; i++)
		{
			ref Vector3 reference = ref dst[i + offset];
			reference = transform.MultiplyVector(src[i]).normalized;
		}
		offset += vertexcount;
	}

	private static void Copy(int vertexcount, Vector2[] src, Vector2[] dst, ref int offset)
	{
		for (int i = 0; i < src.Length; i++)
		{
			ref Vector2 reference = ref dst[i + offset];
			reference = src[i];
		}
		offset += vertexcount;
	}

	private static void CopyColors(int vertexcount, Color[] src, Color[] dst, ref int offset)
	{
		for (int i = 0; i < src.Length; i++)
		{
			ref Color reference = ref dst[i + offset];
			reference = src[i];
		}
		offset += vertexcount;
	}

	private static void CopyTangents(int vertexcount, Vector4[] src, Vector4[] dst, ref int offset, Matrix4x4 transform)
	{
		for (int i = 0; i < src.Length; i++)
		{
			Vector4 vector = src[i];
			Vector3 v = new Vector3(vector.x, vector.y, vector.z);
			v = transform.MultiplyVector(v).normalized;
			ref Vector4 reference = ref dst[i + offset];
			reference = new Vector4(v.x, v.y, v.z, vector.w);
		}
		offset += vertexcount;
	}
}
