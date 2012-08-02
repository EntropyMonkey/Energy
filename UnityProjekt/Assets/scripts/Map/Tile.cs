using UnityEngine;
using System.Collections;
using System;


public class Tile : MonoBehaviour
{
	//Type of tile
	private TileType type;
	// Map instance to get tiles around it
	private Map map;
	
	// GameManager instance
	private GameManager gameManager;
	
	public TileType Type
	{
		get
		{
			return type;	
		}
		set
		{
			// Find the texture collection
			GameObject go = GameObject.Find("Textures");
			Textures textures = go.GetComponent<Textures>();
			this.type = value;
			// If we have a texture for this type
			if(textures.GetTextureByType(this.type) != null)
			{
				// Set the texture
				Transform cube = transform.Find("Cube");
				cube.renderer.material.mainTexture = textures.GetTextureByType(value);
			}
		}
	}
	
	// Coordinates for the tile
	public Vector2 Coords
	{
		get;
		set;
	}
	
	// Size of the tile
	public Vector2 Size
	{
		get;
		private set;
	}
	
	// Current building on this tile. Null if no building on it.
	public Building CurrentBuilding
	{
		get;
		private set;
	}
	
	// If the tile is free from a building or not
	public bool isFree
	{
		get;
		private set;
	}
	
	// The last pollution of this tile (incl. building and surroundings)
	public float Pullution
	{
		get;
		set;
	}
	
	
	
	// Initialization
	public void Start()
	{
		isFree = true;
		Pullution = 0;
		Vector3 size = transform.localScale;
		Size = new Vector2(size.x, size.z);
		//GameObject mapObject = GameObject.Find("Map");
		//map = mapObject.GetComponent<Map>();
		
		gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
	}
	
	public string Save()
	{
		string json = "{";
		json += "coords:[" +
			this.Coords.x + "," +
			this.Coords.y + "," +
			"]," +
			"type:" + Enum.GetName(typeof(TileType), this.Type) + "," +
			"currentBuilding:" +
				(this.CurrentBuilding == null ? "null" : this.getBuildingJson()) +				
			"}";
		return json;
	}

	private string getBuildingJson()
	{
		string building = "{";
		building += "type:" + this.CurrentBuilding.GetType().Name + "," +
			"updates:[" +
				this.getUpgradesString() +
			"]}";
		return building;
	}
	
	private void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			Build(0);	
		}
	}
	
	private string getUpgradesString()
	{
		string temp = "";
		foreach(Upgrade u in this.CurrentBuilding.Upgrades)
		{
			temp += "{" +
				"type:" + ((object)u).GetType().Name + "," +
				"level:" + 1 + //TODO get the actual level or name of the upgrade
				"},";
		}
		temp = temp.Substring(0, temp.Length - 1);
		return temp;
	}// Builds a building on this tile
	public void Build(int Id)
	{
		GameObject newBuilding = (
			Instantiate(gameManager.Prefabs[Id], transform.position, Quaternion.identity) 
			as Transform).gameObject;
		
		CurrentBuilding = newBuilding.GetComponent<Building>();
		isFree = false;
	}
	
	// Removes the current building from this tile
	public void RemoveBuilding()
	{
		// this.CurrentBuilding.Clear();
		this.CurrentBuilding = null;
		this.isFree = true;
	}
	
	// Updates the last pollution of this tile
	public void UpdatePollution()
	{
		//int tempPollution = this.Pollution + this.CurrentBuilding.CurrentOutput[ResourceType.Pollution];
	  
		//foreach(Tile t in this.map.GetEnvironmentTiles(this))
		//{
		//    if(t.CurrentBuilding is PollutionReducer)
		//    {
		//        tempPollution -= ((PollutionReducer)t.CurrentBuilding).ReductionAmount;
		//    }
		//}
		//this.Polluition = tempPollution;
	}
}
