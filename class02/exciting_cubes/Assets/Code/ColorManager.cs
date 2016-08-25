using UnityEngine;
using System.Collections;

public class ColorManager : MonoBehaviour
{
	public Material selectedMaterial, unselectedMaterial;

	private GameObject[] cubes;

	public static ColorManager instance = null;

	private void Awake()
	{
		instance = this;

		int childCount = transform.childCount;

		cubes = new GameObject[childCount];

		for(int i = 0; i < childCount; i++)
			cubes[i] = transform.GetChild(i).gameObject;
	}

	private void Start()
	{
		OnSelectedCube(null);
	}

	public void OnSelectedCube(GameObject target)
	{
		foreach(GameObject go in cubes)
		{
			SetCubeColor(go, unselectedMaterial);
		}

		SetCubeColor(target, selectedMaterial);
	}

	public void SetCubeColor(GameObject cube, Material material)
	{
		if(cube == null)
			return;		

		MeshRenderer mr = cube.GetComponent<MeshRenderer>();

		if(mr == null)
		{
			Debug.Log(string.Format("Cube {0} has no MeshRenderer!", cube.name));
			return;
		}

		mr.sharedMaterial = material;
	}
}
