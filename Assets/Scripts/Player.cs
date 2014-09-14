using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float PlayerSpeed;
	public GameObject ProjectilePrefab;

	// Update is called once per frame
	void Update () {
		// Amount to move
		float amtToMove = Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime;

		// Move the player
		transform.Translate(Vector3.right * amtToMove);

		// ScreenWrap
		if (transform.position.x <= -7.5f)
			transform.position = new Vector3 (7.4f, transform.position.y, transform.position.z);
		else if (transform.position.x >= 7.5f)
			transform.position = new Vector3 (-7.4f, transform.position.y, transform.position.x);

		if (Input.GetKeyDown("space")) {
			// Fire projectile
			Vector3 position = new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2);
			Instantiate(ProjectilePrefab, position, Quaternion.identity);
		}
	}
}
