using UnityEngine;
using System.Collections;

public class OneLeterShipObject : MonoBehaviour {


	private GameObject theA;
	private GameObject theShell;
    private float speed = 0.8f;

    private bool willKillPlayer = true;
   
   public  enum State { Shellon, Shelloff, collected }
    private State state ;
    public bool IsItDeadly() { return willKillPlayer; }


	//state 0 = shell on | letter on | no collision 
	//state 1 = shell off | letter on | has been shot  
	//int state = 0;
   
	void Start () {
        state = State.Shellon;
		theA = this.transform.FindChild("A_3d").gameObject;
		theShell = this.transform.FindChild("A_shell").gameObject;
	}
	
	// Update is called once per frame
	void Update()
	{
        if(state == State.Shellon)
        transform.Translate(Vector3.down * Time.deltaTime * speed);

	   //theA.transform.Rotate(Vector3.right * Time.deltaTime);
		theA.transform.Rotate(Vector3.up * Time.deltaTime * 100);
	}

	void OnTriggerEnter(Collider otherObject)
	{
        if (otherObject.tag == "bulletTag")
        {
            if (state == State.Shellon)
            {
                state = State.Shelloff;
                Debug.Log("shelloff");
                theShell.renderer.enabled = false;
                Destroy(otherObject.gameObject);
                
            }
        }

        if (otherObject.tag == "Player") Debug.Log("PLAYERHIT");

        if (otherObject.tag == "Player" && state == State.Shellon )
        {
            Debug.Log("player entered");
                //   theShell.renderer.enabled = false;
            state = State.Shelloff;
                StartCoroutine(otherObject.GetComponent<Player>().destroyShip());
               
        }
        else
        if (otherObject.tag == "Player" && state == State.Shelloff)
            {
                Debug.Log("delet A");
                theA.transform.renderer.enabled = false;
            }
        
	}
}

// Enemy enemy = (Enemy)otherObject.gameObject.GetComponent("Enemy");
// Instantiate(ExplosionPrefab, enemy.transform.position, enemy.transform.rotation);
//enemy.SetPositionAndSpeed();

//Destroy(ExplosionPrefab.transform.GetComponent<ParticleSystem>());
//Destroy(gameObject);


/*
 
 if (otherObject.tag == "bulletTag")
		{
			if (state == State.Shellon) {
				theShell.renderer.enabled = false;
				Destroy(otherObject.gameObject);
				state = State.Shelloff;
                Debug.Log("shelloff");
			}
		}

        if (otherObject.tag == "player") {
            Debug.Log("player entered");
            if (state == State.Shellon)
            {
             //   theShell.renderer.enabled = false;
               StartCoroutine( otherObject.GetComponent<Player>().destroyShip());
                state = State.Shelloff;
            }
          

                if (state == State.Shelloff) {
                    Debug.Log("delet A");
                    theA.transform.renderer.enabled = false;
                }
        }
 
 
 
 */