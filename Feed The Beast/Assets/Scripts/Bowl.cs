using UnityEngine;
using System.Collections;

public class Bowl : MonoBehaviour {


	[SerializeField]
	private GameObject[] soundsEmitters;

	[SerializeField]
	private GameObject CroquetteSoundEmitter;

	[SerializeField] GameObject croquettes;

	public bool isFull;

	public bool onCross;

	
	void OnCollisionEnter( Collision collision )
	{
		ContactPoint contactPoint = collision.contacts [0];

		GameObject emitter = Instantiate (soundsEmitters [Random.Range (0, soundsEmitters.Length - 1)], contactPoint.point, Quaternion.identity) as GameObject;
		Destroy (emitter, 2.5f);
	}

	void Update() {
		
		if (isFull && !croquettes.activeSelf) {
			croquettes.SetActive (true);

			GameObject emitter = Instantiate (CroquetteSoundEmitter, transform.position, Quaternion.identity) as GameObject;
			Destroy (emitter, 2f);
		} else if (!isFull && croquettes.activeSelf) {
			croquettes.SetActive (false);
		}
	}


}
