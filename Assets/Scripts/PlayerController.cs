using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public int jumpForce;

	public float lookSpeed;
	public float jumpRate;
	private float nextJump;
	private float yaw;
	public int ammo;
	public int health;
	public int score;

	Repainter canvas;

	private Animator anim;
	ObjectSpawner spawner;
	
	private float yawVelocity = 0f;

	void Awake() {
		DontDestroyOnLoad (gameObject);

	}

	void OnLevelWasLoaded() {
		gameObject.transform.position = GameObject.Find ("PlayerSpawnPoint").transform.position;
		spawner = GameObject.Find ("EnemySpawner").GetComponent<ObjectSpawner> ();
		canvas = GameObject.Find ("Canvas").GetComponent<Repainter> ();
		canvas.RepaintAmmo (ammo);
		canvas.RepaintHealth (health);
		canvas.RepaintScore (score);
	}

	void Start() {
		spawner = GameObject.Find ("EnemySpawner").GetComponent<ObjectSpawner> ();
		anim = GetComponent<Animator> ();
		canvas = GameObject.Find ("Canvas").GetComponent<Repainter> ();
		canvas.RepaintAmmo (ammo);
		canvas.RepaintHealth (health);
		canvas.RepaintScore (score);
	}
	

	void FixedUpdate() {
		float mouseX = Input.GetAxis ("Mouse X") * lookSpeed;
		yaw = Mathf.SmoothDamp (yaw, yaw + mouseX, ref yawVelocity, 0.1f);
		transform.rotation = Quaternion.Euler (0, yaw, 0);

		float vertical = Input.GetAxis ("Vertical");
		anim.SetFloat (Animator.StringToHash ("Speed"), vertical * speed);


		if (Input.GetButton ("Jump") && Time.time > nextJump) {
			rigidbody.AddForce(transform.up * jumpForce);
			nextJump = Time.time + jumpRate;
			audio.Play();
		}

	}

	void Update() {
		if (spawner.spawnAmount == 0 && GameObject.FindGameObjectsWithTag ("Enemy").Length == 0) {
			//killed all the enemies!
			Debug.Log ("killed enemies");
			if (Application.loadedLevel == 1)
				Application.LoadLevel(2);
			else if (Application.loadedLevel == 2) {
				Destroy(gameObject);
				Application.LoadLevel(3);
			}

		};
	}
	public void AddAmmo(int add) {
		ammo += add;
		canvas.RepaintAmmo (ammo);

	}

	public void AddScore(int add) {
		score += add;
		canvas.RepaintScore (score);
	}

	public void AddHealth(int add) {
		health += add;
		if (health > 100)
			health = 100; //max is 100
		else if (health <= 0) {
			Debug.Log ("died");
			Destroy (gameObject);
			Application.LoadLevel(4); //player died, game over
		}
			
		canvas.RepaintHealth (health);
	}
}
