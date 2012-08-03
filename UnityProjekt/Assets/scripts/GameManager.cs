using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XMLParser;

// The game manager is a singleton, which means that there can only be one
// instance at all
public class GameManager : MonoBehaviour 
{

	// There are three science steps, they are managed here and can be unlocked
	// by paying with workforce

	//ScienceStep currentScienceStep;

	//TODO add UI

	public List<GameObject> Prefabs;
	public List<XMLParser.Building> Buildings;
	
	public float InGameTime = 720.0f;
	
	//TODO add map

	// Use this for initialization
	void Start () 
	{
		// DO NOT DO THIS!!!!
		//Prefabs = new List<GameObject>();
		Buildings = new List<XMLParser.Building>();
		//read game values xml data
		Parser parser = new Parser("gamevalues.xml");
		Buildings = parser.Buildings;
		
		//TODO create UI

		//TODO create map
	}
	
	// Update is called once per frame
	void Update () 
	{
		//TODO update UI
		InGameTime += Time.deltaTime * 8.0f;
		if (InGameTime >= 1440) InGameTime -= 1440.0f;
	}
	
	
	
}
