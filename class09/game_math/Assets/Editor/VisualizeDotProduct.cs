using UnityEngine;
using UnityEditor;
using System.Collections;

/**
 * Not a component, but an editor script.
 */
[CustomEditor(typeof(VisualizeDotProductComponent))]
public class VisualizeDotProduct : Editor
{
	GUIStyle _style = null;
	GUIStyle style
	{
		get
		{
			if(_style == null)
			{
				_style = new GUIStyle(EditorStyles.label);
				_style.fontSize = 42;
			}
			return _style;
		}
	}

	// Reference to the component inspected by this editor script.
	VisualizeDotProductComponent script;
	Vector3 a_direction, b_direction;

	// Called when Unity class is instantiated
	void OnEnable()
	{
		script = (VisualizeDotProductComponent) target;
	}

	// When the Unity inspector is drawn, this function overrides
	// the default OnInspectorGUI implementation, allowing us to
	// render custom inspector contents.
	public override void OnInspectorGUI()
	{
		GUILayout.Label("Hello, world!");

		float dot = Vector3.Dot(a_direction, b_direction);

		GUILayout.Label("Dot Product: " + dot);

		base.OnInspectorGUI();
	}

	void OnSceneGUI()
	{
		// https://docs.unity3d.com/ScriptReference/Handles.DrawLine.html
		// Draw lines representing the direction from a0 -> a1
		Handles.color = Color.green;
		Handles.DrawLine(	script.a0.transform.position,
											script.a1.transform.position);

		Handles.color = Color.red;
		Handles.DrawLine(	script.b0.transform.position,
											script.b1.transform.position);

		Handles.BeginGUI();

		// We'll be doing math with the positions of these
		// GameObjects, so keep a local copy.
		Vector3 pos_a0 = script.a0.transform.position;
		Vector3 pos_a1 = script.a1.transform.position;

		Vector3 pos_b0 = script.b0.transform.position;
		Vector3 pos_b1 = script.b1.transform.position;

		// Get the direction of line A
		a_direction = (pos_a1 - pos_a0);
		b_direction = (pos_b1 - pos_b0);

		// Normalize the value since it's a direction (no magnitude
		// necessary)
		a_direction.Normalize();
		b_direction.Normalize();

		string a_text = "Direction: " + a_direction.ToString();
		a_text += "\nA dot B: " + Vector3.Dot(a_direction, b_direction);

		Handles.Label( pos_a0 + Vector3.right, a_text, style);

		Handles.EndGUI();
	}
}
