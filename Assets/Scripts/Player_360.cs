


using UnityEngine;
using System.Collections;

public class Player_360 : MonoBehaviour {
	public GameObject[] arra;

	public float PlayerSpeed;
	public GameObject ProjectilePrefab;
	public float smooth = 11.0F;
	public float tiltAngle = 50.0F;

	public GameObject playerExplosion;

	// Update is called once per frame
	void Update () {
		float rotation = Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime;
		this.transform.Rotate(Vector3.forward * rotation * -20);
		float amtToMove = Input.GetAxis("Vertical") * PlayerSpeed * Time.deltaTime;

		transform.Translate(Vector3.up * amtToMove);
		//rigidbody.AddForce(Vector3.up * amtToMove);

		if (transform.position.x <= -6.5f)
			transform.position = new Vector3 (6.4f, transform.position.y, transform.position.z);
		else if (transform.position.x >= 6.5f)
			transform.position = new Vector3 (-6.4f, transform.position.y, transform.position.x);

		if (transform.position.y <= -4f)
			transform.position = new Vector3 (transform.position.x, 9.5f, transform.position.z);
		else if (transform.position.y >= 9.5f)
			transform.position = new Vector3 (transform.position.x, -4f, transform.position.z);


		/*
		// Amount to move
		float amtToMove = Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime;
		float moveZ = Input.GetAxis("Vertical") * PlayerSpeed * Time.deltaTime;

		float tiltAroundz = Input.GetAxis("Horizontal") * tiltAngle;
		Quaternion target = Quaternion.Euler(0, -tiltAroundz, 0);
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
		

		// Move the player
		//transform.Translate(Vector3.right * amtToMove);
		transform.Translate(Vector3.right * amtToMove, Space.World);
		transform.Translate(Vector3.up * moveZ);
		// ScreenWrap
		if (transform.position.x <= -7.5f)
			transform.position = new Vector3 (7.4f, transform.position.y, transform.position.z);
		else if (transform.position.x >= 7.5f)
			transform.position = new Vector3 (-7.4f, transform.position.y, transform.position.x);

		*/

		if (Input.GetKeyDown("space")) {
			// Fire projectile
			Vector3 position = new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2);
			Instantiate(ProjectilePrefab, position, Quaternion.identity);
		}
	}

/*
	void OnTriggerEnter(Collider otherObj)
	{
		if (otherObj.tag == "Letter_and_shellTag" && otherObj.GetComponent<OneLeterShipObject>().IsItDeadly()  ) {

			Debug.Log("touched");
			StartCoroutine (destroyShip());
		}


	}
*/
	public IEnumerator destroyShip() 
		{
			Debug.Log("inside destroy");
			Instantiate(playerExplosion, gameObject.transform.position, Quaternion.identity);
			this.gameObject.renderer.enabled = false;
			this.transform.position = new Vector3(0f, -4.0f , 0f);

			yield return new WaitForSeconds(1.0f);			  
			}
}
