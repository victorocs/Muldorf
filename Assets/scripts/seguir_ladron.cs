using UnityEngine;
using System.Collections;

public class seguir_ladron : MonoBehaviour {
	public GameObject player;
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player.transform.position.x,transform.position.y, transform.position.z);
	}
}
