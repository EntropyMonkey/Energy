using UnityEngine;
using System.Collections;

public class CustomCamera : MonoBehaviour 
{
	public const float speed = 100.0f;

	// the minimum mouse position at which no scrolling happens
	public Vector2 minMousePosition = new Vector2();

	// maximum mouse position at which no scrolling happens
	public Vector2 maxMousePosition = new Vector2();

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 direction = Vector3.zero;

		if (Input.GetKey(KeyCode.DownArrow))
		{
			direction = new Vector3(0, 0, -1);
		}
		else if (Input.GetKey(KeyCode.UpArrow))
		{
			direction = new Vector3(0, 0, 1);
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			direction = new Vector3(-1, 0, 0);
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			direction = new Vector3(1, 0, 0);
		}

		transform.position += direction * speed * Time.deltaTime;

		Debug.Log(Input.mousePosition);
	}

	void OnGUI()
	{
		if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button"))
		{
			print("You clicked the button!");
		}
	}
}
