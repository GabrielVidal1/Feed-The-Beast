using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public GameObject innerLamp;

	public GameObject door;
	public GameObject judas;
	public GameObject poignee;

	private Animator animator;
	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("PorteOuvrir"))
			innerLamp.SetActive (true);
		else if (animator.GetCurrentAnimatorStateInfo (0).IsName ("PorteFermer"))
			innerLamp.SetActive (false);
	
	}

	public void PlayDoorOpening()
	{
		door.GetComponent<AudioSource> ().Play ();
	}

	public void PlayJudasOpening()
	{
		judas.GetComponent<AudioSource> ().Play ();
	}

	public void PlayPoigneeOpening()
	{
		poignee.GetComponent<AudioSource> ().Play ();
	}


}
