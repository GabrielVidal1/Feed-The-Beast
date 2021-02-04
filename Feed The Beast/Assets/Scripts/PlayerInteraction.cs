using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

	[SerializeField] private GameObject camera;
	[SerializeField] private GameObject hand;
	[SerializeField] private float reachingDistance;

	[SerializeField] private GameObject dogFoodCan;

	[SerializeField] private GameObject masterDoor;

	[SerializeField] private GameObject deathSoundEmitter;

	[SerializeField] private Transform deathPos;

	[SerializeField] private GameObject dayNumberText;

	public bool dead;


	[SerializeField] private GameObject deathText;


	[SerializeField] private int level;


	private Animator animator;

	private GameObject holdObject;

	void Start()
	{
		animator = masterDoor.GetComponent<Animator> ();
		dead = false;
		Destroy (dayNumberText, 2.5f);
	}




	void Update () 
	{

		if (!dead) {

			if (Input.GetKeyDown (KeyCode.E)) {

				Ray ray = new Ray (camera.transform.position, (hand.transform.position - camera.transform.position).normalized);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, reachingDistance)) {


					GameObject obj = hit.collider.gameObject;

					if (obj.tag == "Door" && animator.GetBool ("LookThruJudas") == false) {
					

						if (animator.GetBool ("OpenDoor") == false && animator.GetCurrentAnimatorStateInfo (0).IsName ("Idle")) {
							animator.SetBool ("OpenDoor", true);
						} else if (animator.GetBool ("OpenDoor") == true && animator.GetCurrentAnimatorStateInfo (0).IsName ("PorteOuverte")) {
							animator.SetBool ("OpenDoor", false);
						}
					} else if (obj.tag == "Judas" && animator.GetBool ("OpenDoor") == false) {


						if (animator.GetBool ("LookThruJudas") == false && animator.GetCurrentAnimatorStateInfo (0).IsName ("Idle")) {
							animator.SetBool ("LookThruJudas", true);
						} else if (animator.GetBool ("LookThruJudas") == true && animator.GetCurrentAnimatorStateInfo (0).IsName ("JudasOuvert")) {
							animator.SetBool ("LookThruJudas", false);
						}
					} else if (obj.tag == "MovingObject" && obj.name == "Bowl") {
						Bowl bowl = obj.GetComponent<Bowl> ();
						if (!bowl.isFull) {
							bowl.isFull = true;
							dogFoodCan.SetActive (false);

						}
					}

				}

			}

			if (Input.GetMouseButtonDown (0) && !holdObject) {
				
				
				Ray ray = new Ray (camera.transform.position, (hand.transform.position - camera.transform.position).normalized);
				RaycastHit hit;
				
				if (Physics.Raycast (ray, out hit, reachingDistance)) {
					
					if (hit.collider.tag == "MovingObject") {
						holdObject = hit.collider.gameObject;
						
						HingeJoint ho = holdObject.AddComponent<HingeJoint> () as HingeJoint;
						JointMotor motor = ho.motor;
						ho.useMotor = true;
						motor.freeSpin = true;
						ho.anchor = Vector3.forward * 0.75f;
						ho.axis = Vector3.forward;
						ho.connectedBody = hand.GetComponent<Rigidbody> ();
					}
				}
				
				
			} else if (Input.GetMouseButtonUp (0) && holdObject) {
				
				Destroy (holdObject.GetComponent<HingeJoint> ());
				holdObject = null;
			}


		}



	}


	public void Die()
	{
		if (!dead) {

			GameObject dse = Instantiate (deathSoundEmitter, deathPos.transform.position, Quaternion.identity) as GameObject;
			dse.transform.SetParent (deathPos.transform);
			Destroy (dse, 16);
			dead = true;

			gameObject.SetActive (false);

			Destroy (deathPos.GetComponent<DeathAnima> ().eyes, 0.3f);

			deathText.SetActive (true);

		}


	}



}
