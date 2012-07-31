using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
	private TileType type;
	private Map map;
	
	public TileType Type
	{
		get
		{
			return type;	
		}
		set
		{
			GameObject go = GameObject.Find("Textures");
			Textures textures = go.GetComponent<Textures>();
			this.type = value;
			Transform cube = transform.Find("Cube");
			cube.renderer.material.mainTexture = textures.GetTextureByType(value);
		}
	}
	
	public Vector2 Coords
	{
		get;
		set;
	}
	
	public Vector2 Size
	{
		get;
		private set;
	}
	
	/*public Building CurrentBuilding
	{
		get;
		private set;
	}*/
	
	public bool isFree
	{
		get;
		private set;
	}
	
	public float Pullution
	{
		get;
		set;
	}
	
	/*public void Build(Building inBuilding)
	{
		this.CurrentBuilding = inBuilding;
		this.isFree = false;
	}*/
	
	public void RemoveBuilding()
	{
		// this.CurrentBuilding.Clear();
		// this.CurrentBuilding = null;
		this.isFree = true;
	}
	
	public void UpdatePollution()
	{
		/* int tempPollution = this.Pollution + this.CurrentBuilding.CurrentOutput[ResourceType.Pollution];
		 * 
		 * for(Tile t : <map>.GetEnvironmentTiles(this))
		 * {
		 * 		if(t.CurrentBuilding is PollutionReducer)
		 * 		{
		 * 			tempPollution -= ((PollutionReducer)t.CurrentBuilding).ReductionAmount;
		 * 		}
		 * }
		 * this.Polluition = tempPollution;
		 */
	}
	
	public void Start()
	{
		this.isFree = true;
		this.Pullution = 0;
		Vector3 size = transform.localScale;
		this.Size = new Vector2(size.x, size.z);
		GameObject mapObject = GameObject.Find("Map");//TODO: check if right name
		this.map = mapObject.GetComponent<Map>();
	}
}
