using UnityEngine;
using System.Collections;

public class FlyThroughCam : MonoBehaviour {
	public float lookSpeed = 1f;
	public float moveSpeed = 0.25f;

	float rotationX = 0;
	float rotationY = 0;

	void Update()
	{
		rotationX += Input.GetAxis("Mouse X") * lookSpeed;
		rotationY += Input.GetAxis("Mouse Y") * lookSpeed;
		rotationY = Mathf.Clamp(rotationY, -90, 90);

		transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
		transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

		transform.position += transform.forward * moveSpeed * Input.GetAxis("Vertical");
		transform.position += transform.right * moveSpeed * Input.GetAxis("Horizontal");

		if (Input.GetKey(KeyCode.Q))
			transform.position += Vector3.up * moveSpeed;

		if (Input.GetKey(KeyCode.E))
			transform.position += -Vector3.up * moveSpeed;
	}
}
