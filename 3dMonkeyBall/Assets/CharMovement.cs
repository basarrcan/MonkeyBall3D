using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour {

	public Rigidbody CharRd;
	public Rigidbody ballRd;
	public int speed;
	int Xx;
	bool IsJumping;
	public GameObject ground;
	public GameObject ball;
	bool isOnPlayer;

	// Use this for initialization
	void Start () {
		CharRd = GetComponent<Rigidbody> ();
		ballRd = ball.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		Xx = 7;
		if (Input.GetKey (KeyCode.W)) {
			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D))
				Xx = 5;

		}
		else if (Input.GetKey (KeyCode.S)) {
			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D))
				Xx = 5;
		}

		if (Input.GetKey(KeyCode.W))
			CharRd.transform.position += new Vector3 (-1, 0, 0)*Time.deltaTime*speed*Xx;
		if (Input.GetKey(KeyCode.S))
			CharRd.transform.position += new Vector3 (1, 0, 0)*Time.deltaTime*speed*Xx;
		if (Input.GetKey(KeyCode.A))
			CharRd.transform.position += new Vector3 (0, 0, -1)*Time.deltaTime*speed*Xx;
		if (Input.GetKey(KeyCode.D))
			CharRd.transform.position += new Vector3 (0, 0, 1)*Time.deltaTime*speed*Xx;

		if (!IsJumping) {
			if (Input.GetKey (KeyCode.F)) {
				CharRd.AddForce (0, 500, 0, ForceMode.Force);
				IsJumping = true;
			}
		}
		if(isOnPlayer)
			ball.transform.position = CharRd.transform.position + new Vector3(0,4,0);
		if (Input.GetKey (KeyCode.T))
			ThrowBall ();
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == ground.tag)
			IsJumping = false;
		if (other.tag == ball.tag)
			isOnPlayer = true;
	}

	void ThrowBall(){
		ballRd.AddForce (-10, 60, 0, ForceMode.Force);
		isOnPlayer = false;
	}
}
