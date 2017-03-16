using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour {


	public float speed;
	public int jumpPower;
	int Xx;
	bool IsJumping;
	public GameObject ground;
	public GameObject ball;
	bool isOnPlayer;
	Rigidbody ballRd;
	Rigidbody CharRd;
	CharacterController CharCr;

	// Use this for initialization
	void Start () {
		CharRd = GetComponent<Rigidbody> ();
		ballRd = ball.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

		transform.Translate (speed * Input.GetAxis ("Horizontal") * Time.deltaTime, 0f, speed * Input.GetAxis ("Vertical") * Time.deltaTime);

		if(Input.GetKeyDown("space")){
			if (!IsJumping) {
				//transform.Translate (Vector3.up * jumpPower * Time.deltaTime, Space.World);
				//transform.position += transform.up * jumpPower * Time.deltaTime;
				CharRd.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
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
