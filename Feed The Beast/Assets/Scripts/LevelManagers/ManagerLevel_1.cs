using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ManagerLevel_1 : MonoBehaviour {

	public GameObject door;
	public GameObject bowl;
	public GameObject player;

	[SerializeField] private GameObject winText;
	[SerializeField] private GameObject helpText;

	[SerializeField] private Text dayText;

	public GameObject monster;


	[SerializeField] private int level;

	[SerializeField]
	private string[] scenesNames;

	private Door doorScript;
	private Bowl bowlScript;

	private bool win;

	void Start()
	{
		dayText.text = "day " + (level).ToString ();
		print( "day " + (level + 1).ToString () );
	}



	void Update () 
	{

		if (!win) {

			if (player.GetComponent<PlayerInteraction> ().dead) {

				if (Input.GetKeyDown (KeyCode.R)) {

					print ("vous appuyez sur 'R'");


					SceneManager.LoadScene (scenesNames [level - 1]);
				}
			}
		} else {
			if (Input.GetKey (KeyCode.R)) {

				SceneManager.LoadScene (scenesNames [level - 1]);




			}



		}
	
	}

	void OnTriggerStay( Collider other )
	{
		if (other.tag == "Player") {
			PlayerInteraction player = other.GetComponent<PlayerInteraction> ();

			if (!player.dead
			    && monster.GetComponent<Monster_lvl1> ().canEat
			    && !door.GetComponent<Animator> ().GetBool ("OpenDoor")
			    && bowl.GetComponent<Bowl> ().onCross) {

				Win ();
			} else {

				helpText.SetActive (true);

			}


		}
	}

	void OnTriggerExit( Collider other ) {
		if (other.tag == "Player") {
			helpText.SetActive (false);
		}

	}


	void Win() {

		winText.SetActive (true);

		win = true;




	}


}
