using UnityEngine;
using System.Collections;

public class Monster_lvl1 : MonoBehaviour {


	[SerializeField]
	private GameObject player;

	[SerializeField]
	private GameObject eyes;

	[SerializeField]
	private bool eyesOpen;

	[SerializeField]
	private GameObject bowl;

	public GameObject[] SoundsEmitters;

	public bool canEat;

	private GameObject soundEmitter;
	private UnityEngine.AI.NavMeshAgent agent;

	private bool gotoBowl;

	void Start () 
	{
		soundEmitter = Instantiate (SoundsEmitters [0], transform.position, Quaternion.identity) as GameObject;
		soundEmitter.transform.SetParent (transform);
		gotoBowl = false;
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		canEat = false;
	}
	
	void Update () 
	{
		eyes.transform.LookAt (player.transform);

		if (eyesOpen)
			eyes.SetActive (true);
		else
			eyes.SetActive (false);


		if ( bowl.GetComponent<Bowl> ().isFull )
			agent.SetDestination (bowl.transform.position);
			

		if (bowl.GetComponent<Bowl> ().isFull && !gotoBowl) {
			
			//eyesOpen = true;

			gotoBowl = true;

			Destroy (soundEmitter);
			soundEmitter = Instantiate (SoundsEmitters [1], transform.position, Quaternion.identity) as GameObject;

		}

		if (Vector3.Distance (transform.position, bowl.transform.position) < 2) {

			Destroy (soundEmitter);
			soundEmitter = Instantiate (SoundsEmitters [2], transform.position, Quaternion.identity) as GameObject;

			canEat = true;
		}


	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player") {

			other.GetComponent<PlayerInteraction> ().Die ();
			Destroy (soundEmitter);
		}
	}

}
