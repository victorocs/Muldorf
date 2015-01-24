using UnityEngine;
using System.Collections;

public class follow_camera : MonoBehaviour {
	public float Margenx = 1f;
	public float Margeny = 1f;
	public float Movx = 8f;
	public float Movy = 8f;
	public Vector2 maxXandY;
	public Vector2 minXandY;

	private Transform player;
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	bool CheckXMargin() {
		return Mathf.Abs(transform.position.x - player.position.x) > Margenx;
	}
	bool CheckYMargin() {
		return Mathf.Abs(transform.position.y - player.position.y) > Margeny;
	}
	void FixedUpdate(){
		SeguirPlayer();
	}
	void SeguirPlayer(){
		float TargetX = transform.position.x;
		float TargetY = transform.position.y;
		if(CheckXMargin())
			TargetX = Mathf.Lerp(transform.position.x, player.transform.position.x, Movx*Time.deltaTime);
		if(CheckYMargin())
			TargetY = Mathf.Lerp(transform.position.y, player.position.y, Movy * Time.deltaTime);
		TargetX = Mathf.Clamp(TargetX, minXandY.x, maxXandY.x);
		TargetY = Mathf.Clamp(TargetY, minXandY.y, maxXandY.y);
		transform.position = new Vector3 ( TargetX,TargetY,transform.position.z);
	}
}
