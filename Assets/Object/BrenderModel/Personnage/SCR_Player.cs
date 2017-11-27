using UnityEngine;
using System.Collections;

public class SCR_Player : MonoBehaviour {

	Animator animations;
	CapsuleCollider playerCollider;

	public float walkSpeed = 4f;
	public float runSpeed = 8f;
	public float turnSpeed = 50f;
	public Vector3 jumpSpeed = new Vector3 (0, 5f, 0);

	public string inputFront = "z";
	public string inputBack = "s";
	public string inputLeft = "q";
	public string inputRight = "d";

	// Use this for initialization
	void Start () {
		animations = gameObject.GetComponent<Animator>();
		playerCollider = gameObject.GetComponent<CapsuleCollider> ();
	}

	bool IsGrounded(){
		return Physics.CheckCapsule (
			playerCollider.bounds.center,
			new Vector3(
				playerCollider.bounds.center.x, /* centre x */
				playerCollider.bounds.min.y - 0.1f, /* taille de notre "raycast" */
				playerCollider.bounds.center.z
			), 0.08f) ;
	}
	void Update () {
		bool action = false;
		if (Input.GetKey (inputFront)) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				transform.Translate (0, 0, runSpeed * Time.deltaTime);
				animations.SetTrigger("isRunning");
			} else {
				transform.Translate (0, 0, walkSpeed * Time.deltaTime);
				animations.SetTrigger("isWalking");
			}
			action = true;
		}
		if (Input.GetKey (inputBack)) {
			transform.Translate (0, 0, -(walkSpeed/2) * Time.deltaTime);
			animations.SetTrigger("isWalking");
			action = false;
		}
		if (Input.GetKey (inputLeft)) {
			transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
		}
		if (Input.GetKey (inputRight)) {
			transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
		}

		if (Input.GetKeyDown(KeyCode.Space) /*&& IsGrounded()*/) {
			Vector3 v = gameObject.GetComponent<Rigidbody> ().velocity;
			v.y = jumpSpeed.y;
			gameObject.GetComponent<Rigidbody>().velocity = jumpSpeed;
		}
	}
}
