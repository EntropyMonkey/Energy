using UnityEngine;
using System.Collections;

public class CustomCamera : MonoBehaviour 
{
	public const float speed = 100.0f;

	//the minimum mouse positon at which no scrolling happens
	public Vector2 minMousePositon = new Vector2();
	//the maximum mouse positon at which no scrolling happens
	public Vector2 maxMousePositon = new Vector2();
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
<<<<<<< HEAD
		Vector3 direction = new Vector3(0,0,0);
			
		if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A))
		{
			direction = new Vector3(0,0,1)*speed*Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D))
		{
			direction = new Vector3(0,0,-1)*speed*Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W))
		{
			direction = new Vector3(1,0,0)*speed*Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S))
		{
			direction = new Vector3(-1,0,0)*speed*Time.deltaTime;
		}
		else if (Input.mousePosition.x < 25)
		{
		direction = new Vector3 (0,0,1)*speed*Time.deltaTime;
		}
		else if (Input.mousePosition.x >= Screen.width - 25) 
		{
		  	direction = new Vector3(0,0,-1)*speed*Time.deltaTime;	
		}
		else if (Input.mousePosition.y < 25)
		{
		 	direction = new Vector3 (-1,0,0)*speed*Time.deltaTime;
		}
		else if (Input.mousePosition.y > Screen.height - 25)
		{
			direction = new Vector3(1,0,0)*speed*Time.deltaTime;
		}
		
		
		transform.position += direction * speed * Time.deltaTime;

	}

}
