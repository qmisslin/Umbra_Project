using UnityEngine;

public class SCR_Player : MonoBehaviour
{
	public float walkSpeed = 4f;	// Vietesse du joueur en marche
	public float runSpeed = 8f;     // Vitesse du joueur en course
	public float turnSpeed = 50f;	// Vitesse de rotation du joueur
	public Vector3 jumpSpeed = new Vector3(0,10f,0);

	public string inputFront = "z";
	public string inputBack = "s";
	public string inputLeft = "q";
	public string inputRight = "d";

    Vector3 movement;

    Animator anim;
    Rigidbody playerRigidbody;

	// Rotation de la camera
	GameObject playerCamera;

	Animation animations;
	CapsuleCollider playerCollider;

	// Demarre avant la methode start
    void Awake (){
        anim = GetComponent <Animator> ();
        playerRigidbody = GetComponent <Rigidbody> ();
		playerCollider = gameObject.GetComponent<CapsuleCollider> ();

		// Rotation de la camera
		playerCamera = GameObject.FindWithTag ("MainCamera");
    }

	// Update pour les elements physiques
    void FixedUpdate (){

		// Reccupération de la rotation de la camera
		Vector3 eulerRotation = transform.rotation.eulerAngles;
		eulerRotation.y = playerCamera.transform.rotation.eulerAngles.y;



        // Store the input axes.
		int action = 0;
		Vector3 translation = new Vector3 (0, 0, 0);

		// Rotation de la camera en free ou non
		if(!Input.GetMouseButton(1)){
			transform.eulerAngles = eulerRotation;
		}


		// Lancement d'un attaque
		if (Input.GetMouseButton (0)) {
			action = 4;
		} else {
			
			// Si on avance
			if (Input.GetKey (inputFront)) {
				if (Input.GetKey (KeyCode.LeftShift)) {
					translation.z = runSpeed * Time.deltaTime;
					action = 2;
				} else {
					translation.z = walkSpeed * Time.deltaTime;
					action = 1;
				}

			// Si on recule
			} else if (Input.GetKey (inputBack)) {
				translation.z = walkSpeed * Time.deltaTime;
				translation.z = -(walkSpeed/2) * Time.deltaTime;
				action = 3;
			}


			// Si on avance à Gauche
			if (Input.GetKey (inputLeft)) {
				translation.x = (walkSpeed) * Time.deltaTime;
				//transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
			}

			// Si on avance à Droite
			if (Input.GetKey (inputRight)) {
				//transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
				translation.x = -(walkSpeed) * Time.deltaTime;
			}

			// Si on saute
			if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
				Vector3 v = gameObject.GetComponent<Rigidbody> ().velocity;
				v.y = jumpSpeed.y;
				gameObject.GetComponent<Rigidbody>().velocity = jumpSpeed;
			}
		}

		// Translation du joueur
		transform.Translate (translation.x, translation.y, translation.z);

		anim.SetBool ("IsWalking", false);
		anim.SetBool ("IsRunning", false);
		anim.SetBool ("IsAttack", false);

        // Animation du personnage
		switch (action) {
			case 1: 
				anim.SetBool ("IsWalking", true);
				break;
			case 2:
				anim.SetBool ("IsRunning", true);
				break;
			case 3:
				// Animation de recul du personnage
				break;
			case 4:
				// Animation d'une attaque
				anim.SetBool ("IsAttack", true);
				break;
			default:
			break;
		}
    }

	// Test si le personnage touche le sol
	bool IsGrounded(){
		return Physics.CheckCapsule (
			playerCollider.bounds.center,
			new Vector3(
				playerCollider.bounds.center.x, /* centre x */
				playerCollider.bounds.min.y - 0.1f, /* taille de notre "raycast" */
				playerCollider.bounds.center.z
			), 0.08f);
	}
}