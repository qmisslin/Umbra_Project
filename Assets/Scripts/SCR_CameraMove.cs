using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CameraMove : MonoBehaviour {

	public float horizontalSpeed = 5.0f;
	public float verticalSpeed = 5.0f;
	private Vector3 persoPosition;

	public float smoothing = 5.0f;

	private Vector3 anchorCameraPosition;

	// Use this for initialization
	void Start () {
		anchorCameraPosition = transform.position - GameObject.FindWithTag("Player").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float h = horizontalSpeed * Input.GetAxis ("Mouse X");
		float v = 0;//verticalSpeed * Input.GetAxis ("Mouse Y");
		transform.Rotate(0,h,v);

		// On get les positions du personnage et on l'attribut à la camera
		persoPosition = GameObject.FindWithTag("Player").transform.position;
		transform.position = anchorCameraPosition + persoPosition;

		//transform.position = Vector3.Lerp(transform.position, persoPosition, smoothing * Time.deltaTime);
	}
}
