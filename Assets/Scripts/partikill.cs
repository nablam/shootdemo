using UnityEngine;
using System.Collections;

public class partikill : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		Waitup();

  //      Destroy(this.gameObject);
	}

	IEnumerator Waitup() {
		yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
	}
}
