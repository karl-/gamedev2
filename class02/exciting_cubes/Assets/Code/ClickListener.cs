using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class ClickListener : MonoBehaviour
{
	private void OnMouseDown()
	{
		ColorManager.instance.OnSelectedCube(gameObject);
	}
}
