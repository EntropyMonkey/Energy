using UnityEngine;
using System.Collections;

public class CustomCamera : MonoBehaviour 
{
	public const float maxspeed = 1000.0f;
	public const float acceleration = 200.0f;
	public const float deceleration = 0.1f;
		
	private Vector3 velocity;
	
	//the minimum mouse positon at which no scrolling happens
	public Vector2 minMousePositon = new Vector2(25,25);
	//the maximum mouse positon at which no scrolling happens
	public Vector2 maxMousePositon = new Vector2(Screen.width - 25,Screen.height - 25);
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 direction = new Vector3(0,0,0);
			
		if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A))
		{
			direction = new Vector3(0,0,1);
		}
		else if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D))
		{
			direction = new Vector3(0,0,-1);
		}
		else if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W))
		{
			direction = new Vector3(1,0,0);
		}
		else if (Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S))
		{
			direction = new Vector3(-1,0,0);
		}
		else if (Input.mousePosition.x < 25)
		{
			direction = new Vector3 (0,0,1);
		}
		else if (Input.mousePosition.x >=Screen.width -25) 
		{
		  	direction = new Vector3(0,0,-1);	
		}
		else if (Input.mousePosition.y < 25)
		{
		 	direction = new Vector3 (-1,0,0);
		}
		else if (Input.mousePosition.y >Screen.height -25)
		{
			direction = new Vector3(1,0,0);
		}
		else 
		{
			direction = -velocity * deceleration;
		}
		
		velocity += direction *acceleration *Time.deltaTime;
		//if the camera moves too fast, clamp its speed 
		if (velocity.sqrMagnitude> maxspeed * maxspeed)
			velocity =velocity.normalized * maxspeed;
		
		transform.position += velocity * Time.deltaTime;

	}

}
