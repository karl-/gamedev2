using UnityEngine;
using System.Collections;

public class ColorManager : MonoBehaviour
{
	// A single instance of the ColorManger script
	public static ColorManager instance;

	public Material unselectedMaterial;
	public Material selectedMaterial;

	// Called as soon as a monobehaviour is instantiated - prior to Start() and Update()
	private void Awake()
	{
		// Set the static member `instance` to this
		instance = this;
	}

	// Called after all MonoBehaviours run Awake(), before Update()
	private void Start()
	{
		SetCubeSelected(null);
	}

	public void SetCubeSelected(GameObject go)
	{
		foreach(Transform child in transform)
		{
			SetCubeColor(child.gameObject, unselectedMaterial);
		}

		SetCubeColor(go, selectedMaterial);
	}

	/**
	 * Set a gameObjects mesh renderer to use `material`.
	 */
	private void SetCubeColor(GameObject go, Material material)
	{
		// Make sure gameobject isn't null
		if(go == null)
		{
			// Debug.LogError("GameObject is null!");
			return;
		}

		MeshRenderer mr = go.GetComponent<MeshRenderer>();

		if(mr == null)
		{
			Debug.LogError("GameObject " + go.name + " has no MeshRenderer!");
			return;
		}

		mr.sharedMaterial = material;
	}
}
