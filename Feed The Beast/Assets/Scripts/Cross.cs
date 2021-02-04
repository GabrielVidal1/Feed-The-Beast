using UnityEngine;
using System.Collections;

public class Cross : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter( Collider other ) {

		if (other.name == "Bowl")
			other.GetComponent<Bowl> ().onCross = true;
	}

	void OnTriggerExit( Collider other ) {

		if (other.name == "Bowl")
			other.GetComponent<Bowl> ().onCross = false;
	}
}
