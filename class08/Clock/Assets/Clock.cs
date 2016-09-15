using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
	// Second hand root
	[Tooltip("Hook up the seconds root transform")]
	public Transform secondsRoot;
	public Transform minutesRoot;
	public Transform hoursRoot;

	public Text clockText;

	const float SEC_TO_ROTATION = -360f / 60f;
	const float MIN_TO_ROTATION = -360f / 60f;
	const float HOUR_TO_ROTATION = -360f / 12f;

	void Update ()
	{
		// Get the current time and date
		DateTime time = DateTime.Now;

		// Set the UI.Text component 'text' field to a string (text)
		// representation of the DateTime instance
		clockText.text = string.Format("{0}:{1}:{2}",
			time.Hour % 12,
			time.Minute,
			time.Second);

		secondsRoot.localRotation = Quaternion.Euler(
			new Vector3(0, 0, SEC_TO_ROTATION * time.Second));

		minutesRoot.localRotation = Quaternion.Euler(
			new Vector3(0, 0, MIN_TO_ROTATION * time.Minute));

		hoursRoot.localRotation = Quaternion.Euler(
			new Vector3(0, 0, HOUR_TO_ROTATION * time.Hour));
	}
}
