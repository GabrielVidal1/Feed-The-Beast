using UnityEngine;
using System.Collections;

public class Monster_lvl2 : MonoBehaviour {


	[SerializeField]
	private GameObject player;

	[SerializeField]
	private GameObject eyes;

	[SerializeField]
	private bool eyesOpen;

	[SerializeField]
	private GameObject bowl;

	public GameObject[] SoundsEmitters;


	private GameObject soundEmitter;
	private NavMeshAgent agent;

	private bool gotoBowl;

	void Start () 
	{
		soundEmitter = Instantiate (SoundsEmitters [0], transform.position, Quaternion.identity) as GameObject;
		soundEmitter.transform.SetParent (transform);
		gotoBowl = false;
		agent = GetComponent<NavMeshAgent> ();
	}
	
	void Update () 
	{
		eyes.transform.LookAt (player.transform);

		if (eyesOpen)
			eyes.SetActive (true);
		else
			eyes.SetActive (false);



		if (bowl.GetComponent<Bowl> ().isFull && !gotoBowl) {
			
			agent.SetDestination (bowl.transform.position);
			//eyesOpen = true;

			gotoBowl = true;

			Destroy (soundEmitter);
			soundEmitter = Instantiate (SoundsEmitters [1], transform.position, Quaternion.identity) as GameObject;



		}
	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player") {

			other.GetComponent<PlayerInteraction> ().Die ();
			Destroy (soundEmitter);
		}
	}

}
