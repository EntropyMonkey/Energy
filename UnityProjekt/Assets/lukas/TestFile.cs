// C#
using UnityEngine;
using System.Collections;

public class TestFile : MonoBehaviour 
{
	public float stuff = 20;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	
	void OnGui()
	{
		if (GUI.Button (new Rect (10,10,150,100), "I am a button")) {
			print ("You clicked the button!");
		}
	}
}