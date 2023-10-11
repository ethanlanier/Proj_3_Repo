using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class casting : MonoBehaviour
{
	public CharacterController cc;
	public Transform camTransform;
	private int count = 4;
	public GameObject door;

    void Update()
    {

		if (Input.GetMouseButton(0))
		{
			RaycastHit hit;

			if (Physics.Raycast(camTransform.position, camTransform.forward, out hit))
			{
				Debug.DrawLine(camTransform.position + new Vector3(0f, -1f, 0f), hit.point, Color.green, 1f);
				if (hit.collider.gameObject.CompareTag("goal"))
                {
					Destroy(hit.collider.gameObject);
					count--;
                }

			}
			else
			{
				Debug.DrawRay(camTransform.position + new Vector3(0f, -1f, 0f), camTransform.forward * 100f, Color.red, 1f);
			}
		}

		if (count <= 0)
        {
			Destroy(door);
        }
	}
}
