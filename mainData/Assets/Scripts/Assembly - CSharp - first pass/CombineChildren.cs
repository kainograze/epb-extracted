// cee00d2aaa71742248a1a43893a85c11, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// CombineChildren
using System;
using System.Collections;
using UnityEngine;

[AddComponentMenu("Mesh/Combine Children")]
public class CombineChildren : MonoBehaviour
{
	public bool generateTriangleStrips = true;

	private void Start()
	{
		Component[] componentsInChildren = GetComponentsInChildren(typeof(MeshFilter));
		Matrix4x4 worldToLocalMatrix = base.transform.worldToLocalMatrix;
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			MeshFilter meshFilter = (MeshFilter)componentsInChildren[i];
			Renderer renderer = componentsInChildren[i].renderer;
			MeshCombineUtility.MeshInstance meshInstance = new MeshCombineUtility.MeshInstance
			{
				mesh = meshFilter.sharedMesh
			};
			if (!(renderer != null) || !renderer.enabled || !(meshInstance.mesh != null))
			{
				continue;
			}
			meshInstance.transform = worldToLocalMatrix * meshFilter.transform.localToWorldMatrix;
			Material[] sharedMaterials = renderer.sharedMaterials;
			for (int j = 0; j < sharedMaterials.Length; j++)
			{
				meshInstance.subMeshIndex = Math.Min(j, meshInstance.mesh.subMeshCount - 1);
				ArrayList arrayList = (ArrayList)hashtable[sharedMaterials[j]];
				if (arrayList != null)
				{
					arrayList.Add(meshInstance);
					continue;
				}
				arrayList = new ArrayList();
				arrayList.Add(meshInstance);
				hashtable.Add(sharedMaterials[j], arrayList);
			}
			renderer.enabled = false;
		}
		foreach (object item in hashtable)
		{
			DictionaryEntry dictionaryEntry = (DictionaryEntry)item;
			ArrayList arrayList2 = (ArrayList)dictionaryEntry.Value;
			MeshCombineUtility.MeshInstance[] combines = (MeshCombineUtility.MeshInstance[])arrayList2.ToArray(typeof(MeshCombineUtility.MeshInstance));
			if (hashtable.Count == 1)
			{
				if (GetComponent(typeof(MeshFilter)) == null)
				{
					base.gameObject.AddComponent(typeof(MeshFilter));
				}
				if (!GetComponent("MeshRenderer"))
				{
					base.gameObject.AddComponent("MeshRenderer");
				}
				MeshFilter meshFilter2 = (MeshFilter)GetComponent(typeof(MeshFilter));
				meshFilter2.mesh = MeshCombineUtility.Combine(combines, generateTriangleStrips);
				MeshCollider meshCollider = (MeshCollider)GetComponent(typeof(MeshCollider));
				meshCollider.sharedMesh = meshFilter2.mesh;
				base.renderer.material = (Material)dictionaryEntry.Key;
				base.renderer.enabled = true;
			}
			else
			{
				GameObject gameObject = new GameObject("Combined mesh");
				gameObject.transform.parent = base.transform;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localRotation = Quaternion.identity;
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.AddComponent(typeof(MeshFilter));
				gameObject.AddComponent("MeshRenderer");
				gameObject.renderer.material = (Material)dictionaryEntry.Key;
				MeshFilter meshFilter3 = (MeshFilter)gameObject.GetComponent(typeof(MeshFilter));
				meshFilter3.mesh = MeshCombineUtility.Combine(combines, generateTriangleStrips);
				MeshCollider meshCollider2 = (MeshCollider)GetComponent(typeof(MeshCollider));
				meshCollider2.sharedMesh = meshFilter3.mesh;
			}
		}
	}
}
