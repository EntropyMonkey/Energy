using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// The game manager is a singleton, which means that there can only be one
// instance at all
public class GameManager : MonoBehaviour 
{
	// translates names to ids for the prefab list
	private static Dictionary<string,int> BuildingNameTranslator;
	
	// There are three science steps, they are managed here and can be unlocked
	// by paying with workforce

	//ScienceStep currentScienceStep;

	//TODO add UI

	// prefabs for instantiating buildings, string->identifier from xml
	public List<Transform> Prefabs;
	
	//TODO add map

	// Use this for initialization
	void Start () 
	{
		
		//TODO create name/id dictionary
		
		//TODO create UI

		//TODO create map
	}
	
	// Update is called once per frame
	void Update () 
	{
		//TODO update UI
	}
	
	public static int BNameToId(string name)
	{
		return BuildingNameTranslator[name];
	}
}
