using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.UpArrow) && !Input.GetKey (KeyCode.DownArrow)) {
			if ((rb.velocity.x > 0.0f) && (rb.velocity.y != 0.0f)) {
						rb.velocity = new Vector2 (0.0f, 0.0f);
				}
				if (rb.velocity.x > -3.0f) {
				rb.velocity = new Vector2 (-6.0f, 0.0f);
				}
			}
		else if (Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.UpArrow) && !Input.GetKey (KeyCode.DownArrow)) {
			if ((rb.velocity.x < 0.0f) && (rb.velocity.y != 0.0f)) {
						rb.velocity = new Vector2 (0.0f, 0.0f);
					
				}
				if (rb.velocity.x < 3.0f) {
				rb.velocity = new Vector2 (6.0f, 0.0f);
				}
			}
		else if (Input.GetKey (KeyCode.DownArrow) && !Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.UpArrow) && !Input.GetKey (KeyCode.LeftArrow)) {
			if ((rb.velocity.y > 0.0f) && (rb.velocity.x != 0.0f)) {
						rb.velocity = new Vector2 (0.0f, 0.0f);
					
				}
				if (rb.velocity.y > -3.0f) {
				rb.velocity = new Vector2 (0.0f, -6.0f);
				}
			}
		else if (Input.GetKey (KeyCode.UpArrow) && !Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.DownArrow)) {
			if ((rb.velocity.y < 0.0f) && (rb.velocity.x != 0.0f)) {
						rb.velocity = new Vector2 (0.0f, 0.0f);
				}
				if (rb.velocity.y < 3.0f) {
				rb.velocity = new Vector2 (0.0f, 6.0f);
				}
		}else {
			rb.velocity = new Vector2 (0.0f, 0.0f);
		}
	}

}
