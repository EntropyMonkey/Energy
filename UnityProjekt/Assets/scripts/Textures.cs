using UnityEngine;
using System.Collections.Generic;

public class Textures : MonoBehaviour {

	public Texture mountainTexture, riverTexture, grassTexture, desertTexture, seaTexture;
	private Dictionary<TileType, Texture> tileTextures;
	
	public void Start()
	{
		this.tileTextures = new Dictionary<TileType, Texture>();
		tileTextures.Add(TileType.Mountain, this.mountainTexture);
		tileTextures.Add(TileType.River, this.riverTexture);
		tileTextures.Add(TileType.Grassland, this.grassTexture);
		tileTextures.Add(TileType.Desert, this.desertTexture);
		tileTextures.Add(TileType.Sea, this.seaTexture);		
	}
	
	public Texture GetTextureByType(TileType inType)
	{
		return this.tileTextures[inType];
	}
}
