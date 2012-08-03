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

	private UIManager uiManager;
	private Map map;

	public List<GameObject> Prefabs;
	/// <summary>
	/// The id of a building type is the index of the type in this list
	/// </summary>
	public List<XMLParser.Building> Buildings;
	
	public float InGameTime = 720.0f;

	// Use this for initialization
	void Start () 
	{
		// DO NOT DO THIS!!!! public variablen werden in unity automatisch initialisiert.
		//Prefabs = new List<GameObject>();
		Buildings = new List<XMLParser.Building>();
		//read game values xml data
		Parser parser = new Parser("gamevalues.xml");
		Buildings = parser.Buildings;

		uiManager = gameObject.GetComponent<UIManager>();
		if (uiManager == null)
		{
			Debug.LogError("There is no UIManager Script on the GameManager Object.");
		}

		map = gameObject.GetComponent<Map>();
		if (map == null)
		{
			Debug.LogError("There is no Map Script on the GameManager Object.");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		InGameTime += Time.deltaTime * 8.0f;
		if (InGameTime >= 1440) InGameTime -= 1440.0f;
	}
	
	
	
}
