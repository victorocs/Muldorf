using UnityEngine;
using System.Collections;

public class move_fluido : MonoBehaviour {
	private float speed = 400.0f;
	public bool vel = false;
	private Animator animator;
	private static Vector2 vectorMovimiento;
	void Awake(){
		animator = GetComponent<Animator>();
	}
	void Update () {
		if(Input.touchCount > 0){
			animator.SetBool("vel", true);
			Touch theTouch = Input.GetTouch (0);
			Vector3 coordenadaDestino = Camera.main.ScreenToWorldPoint (theTouch.position);
			Vector2 posicionPersonaje = new Vector2(transform.position.x,transform.position.y);
			Vector2 coordenadaDestino2D = new Vector2(coordenadaDestino.x,transform.position.y);

			vectorMovimiento = coordenadaDestino2D - posicionPersonaje;

			vectorMovimiento.Normalize();
			vectorMovimiento = vectorMovimiento * speed * Time.deltaTime;

			float distancia = Vector2.Distance (posicionPersonaje, coordenadaDestino2D);

			if(distancia < 1){
				vectorMovimiento = Vector2.zero;
			}
			rigidbody2D.velocity = vectorMovimiento;
			if(rigidbody2D.velocity.x > 0){
				transform.localScale = new Vector3(0.8f, 0.8f, 1f);
			}
			if(rigidbody2D.velocity.x < 0){
				transform.localScale = new Vector3(-0.8f, 0.8f, 1f);
			}
		}else{
			animator.SetBool("vel", false);
			rigidbody2D.velocity = Vector2.zero;
		}
	}
}