using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class OnClick : MonoBehaviour {

	/**
	 * Called when a mouse clicks on this object's collider
	 */
	void OnMouseDown()
	{
		// Tell manager that this gameObject was clicked
		ColorManager.instance.SetCubeSelected(this.gameObject);
	}
}
