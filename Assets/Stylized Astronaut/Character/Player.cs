using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	private Animator anim;
	private CharacterController controller;
	public GameManager gameManager;
	public float speed = 600.0f;
	public float jumpSpeed = 600.0f;
	public float turnSpeed = 400.0f;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;
	private Vector3 impact = Vector3.zero;
	private float mass = 40.0f;
	public AudioClip crashSound;
	private AudioSource playerAudio;

	void Start()
	{
		controller = GetComponent<CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();
		playerAudio = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (Input.GetKey("w"))
        {
			anim.SetInteger("AnimationPar", 1);
        }
        else
        {
			anim.SetInteger("AnimationPar", 0);
        }

		if (controller.isGrounded)
		{
			moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;

			if (Input.GetKey(KeyCode.Space))
            {
				moveDirection.y += jumpSpeed * Time.deltaTime;
			}
		}

		float turn = Input.GetAxis("Horizontal");
		transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
		controller.Move(moveDirection * Time.deltaTime);
		moveDirection.y -= gravity * Time.deltaTime;
		if (impact.magnitude > 0.2) controller.Move(impact * Time.deltaTime);
		impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);

		if (transform.position.y < 40)
		{
			Debug.Log("Ground touch");
			gameManager.GameOver();
		}
	}

	void AddImpact(Vector3 dir, float force)
		{
			dir.Normalize();
			if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
			impact += dir.normalized * force / mass;
		}
	private void OnCollisionEnter(Collision col)
		{
			if(col.gameObject.tag == "Sphere")
			{
				AddImpact(col.gameObject.GetComponent<Rigidbody>().velocity , 3000);
				playerAudio.PlayOneShot(crashSound, 1.0f);
			}

			if(col.gameObject.tag == "Sun")
			{
				AddImpact(col.gameObject.GetComponent<Rigidbody>().velocity, 5000);
				playerAudio.PlayOneShot(crashSound, 1.0f);
			}
		}
}
