using UnityEngine;
using System.Collections.Generic;

public class Textures : MonoBehaviour
{
	// textures which can be changed in the unity editor
	public Texture mountainTexture, riverTexture, grassTexture, desertTexture, seaTexture;
	// Map which maps the texture to the corresponding type
	private Dictionary<TileType, Texture> tileTextures;
	
	public void Start()
	{
		// Load all textures in the map
		this.tileTextures = new Dictionary<TileType, Texture>();
		tileTextures.Add(TileType.Mountain, this.mountainTexture);
		tileTextures.Add(TileType.River, this.riverTexture);
		tileTextures.Add(TileType.Grassland, this.grassTexture);
		tileTextures.Add(TileType.Desert, this.desertTexture);
		tileTextures.Add(TileType.Sea, this.seaTexture);	
		tileTextures.Add(TileType.Empty, this.grassTexture);
	}
	
	// Gets the texture by the type
	public Texture GetTextureByType(TileType inType)
	{
		if(this.tileTextures.ContainsKey(inType))
			return this.tileTextures[inType];
		
		// If we don't have a texture for this type we return nothing
		return null;
	}
}
