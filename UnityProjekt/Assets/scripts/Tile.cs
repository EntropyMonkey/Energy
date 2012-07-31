using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
	private TileType type;
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
			//set texture with this = textures.GetTextureByType(value);
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
		this.isFree = true;
	}
	
	public void UpdatePollution()
	{
		
	}
	
	public void Start()
	{
		this.isFree = true;
		this.Pullution = 0;
		Vector3 size = transform.localScale;
		this.Size = new Vector2(size.x, size.z);
	}
	
	/*
	 * <instantiation>
	 * Tile t = <go>.GetComponent<Tile>();
	 * t.Type = TileType.Mountain;
	 * t.Coords = new Vector2(1, 1);
	 * t.UpdatePollution();
	 */
}
