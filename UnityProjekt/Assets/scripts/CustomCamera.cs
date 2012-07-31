using UnityEngine;
using System.Collections;

public class CustomCamera : MonoBehaviour 
{

	Camera camera;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			//Move();
		}
	}
}
