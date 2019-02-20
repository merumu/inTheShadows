using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipObject : MonoBehaviour {

	void Start () {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
	    int[] tri = mesh.triangles;   
	    int l = 0;   
	    while (l < tri.Length)
	    {
	    	int tmp = tri[l+1];
	    	tri[l+1]=tri[l+2];
	        tri[l+2]=tmp;
	        l+=3;
	    }
	    mesh.triangles = tri;
	    MeshCollider sc = gameObject.AddComponent<MeshCollider>() as MeshCollider;
	}
}