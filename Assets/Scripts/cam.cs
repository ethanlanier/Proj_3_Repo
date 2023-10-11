using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
	public float MouseSensitivity;
	public Transform CamTransform;

	private float camRotation = 0f;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update()
	{
		//up/down movement
		float mouseInputY = Input.GetAxis("Mouse Y") * MouseSensitivity;
		camRotation -= mouseInputY;
		camRotation = Mathf.Clamp(camRotation, -90f, 90f); //dont look over 90 degrees
		CamTransform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0f, 0f));

		//rotate entire body on y axis
		float mouseInputX = Input.GetAxis("Mouse X") * MouseSensitivity;
		transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, mouseInputX, 0f));
	}
}
