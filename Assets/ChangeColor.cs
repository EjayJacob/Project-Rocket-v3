using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

	public Material[] material;
	Renderer rend;

	GameObject RocketShip;

	Vector3 RocketShipLoc;

	bool collide = false;

	[SerializeField]int dist = 1;
	
	void Start () {
		rend = GetComponent<Renderer>();
		rend.enabled = true;
		rend.sharedMaterial.color = Color.red;

		RocketShip = GameObject.FindWithTag("Player");
	}

	void Update(){
		RocketShipLoc = RocketShip.transform.position;
       
		if(collide){
			rend.sharedMaterial.color = Color.green;
		}else if((Vector3.Distance(transform.position, RocketShipLoc) < dist) && !collide){
			rend.sharedMaterial.color = Color.blue;
		}else if (!collide)
        {
          rend.sharedMaterial.color = Color.red;
        }
	}

	
	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Player"){
			collide = true;
		}
	}

	void OnCollisionExit (Collision col) {
		if (col.gameObject.tag == "Player"){
			collide = false;
		}
	}
}
