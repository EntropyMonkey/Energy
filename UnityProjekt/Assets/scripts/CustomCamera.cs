using UnityEngine;
using System.Collections;

public class CustomCamera : MonoBehaviour 
{

	public const float maxspeed = 1000.0f;
	public const float acceleration = 250.0f;
	public const float deceleration = 0.1f;
	public float mapsize = 25f;

	private Vector3 velocity;

	//the minimum mouse position at which no scrolling happens
	public Vector2 minMousePositon = new Vector2();
	//the maximum mouse position at which no scrolling happens
	public Vector2 maxMousePositon = new Vector2();
	
	// Use this for initialization
	void Start () 
	{
		velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateMovement();
		UpdateScroll();
	}

	void UpdateMovement()
	{
		Vector3 direction = new Vector3(0,0,0);
		
		if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A))
		{
			direction = new Vector3(-1,0,0);
		}
		else if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D))
		{
			direction = new Vector3(1,0,0);
		}
		else if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W))
		{
			direction = new Vector3(0,0,1);
		}
		else if (Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S))
		{
			direction = new Vector3(0,0,-1);
		}
		else if (Input.mousePosition.x < 25)
		{
		direction = new Vector3 (-1,0,0);
		}
		else if (Input.mousePosition.x >=Screen.width -25) 
		{
		  	direction = new Vector3(1,0,0);	
		}
		else if (Input.mousePosition.y < 25)
		{
		 	direction = new Vector3 (0,0,-1);
		}
		else if (Input.mousePosition.y >Screen.height -25)
		{
			direction = new Vector3(0,0,1);
		}
		else 
		{
			direction = -velocity * deceleration;
		}
		
		velocity += direction *acceleration *Time.deltaTime;
		//if the camera moves too fast, clamp its speed 
		if (velocity.sqrMagnitude> maxspeed * maxspeed)
		{
			velocity =velocity.normalized * maxspeed;
		}
		transform.position += velocity * Time.deltaTime;
		Vector3 newPos = transform.position;
		if (transform.position.x > mapsize)
		{
			Debug.Log (1);
			//newPos.x = mapsize/2;
		}
		else if (transform.position.x < -mapsize)
		{
			Debug.Log (2);
			//direction = newPos;
		}
		else if (transform.position.z > mapsize)
		{
			Debug.Log (3);
			//direction = newPos;
		}
		else if (transform.position.z < -mapsize)
		{
			Debug.Log (4);
			//direction = newPos;
		}
		transform.position = newPos;
		
		}
	void UpdateScroll()
	{			
		Vector3 direction = new Vector3(0,0,0);
		float deltaScroll = Input.GetAxis("Mouse ScrollWheel");
		if (deltaScroll < 0 || Input.GetKey(KeyCode.KeypadMinus))
		{
			direction = new Vector3(0,200,0);
		}
		else if (deltaScroll > 0 || Input.GetKey(KeyCode.KeypadPlus))
		{
			direction = new Vector3 (0,-200,0);
		}
		//else 
		//{
		//	direction = -velocity * deceleration;
		//}
		
		//velocity += direction *acceleration *Time.deltaTime;
		//if the camera moves too fast, clamp its speed 
		//if (velocity.sqrMagnitude> maxspeed * maxspeed)
		//	velocity =velocity.normalized * maxspeed;
		

		transform.position += direction * Time.deltaTime;
	}

}
