using UnityEngine;
using System.Collections.Generic;
using System;

public class Map : MonoBehaviour {
	public const int MapSize = 50;
	private const int environmentRadius = 3;
	public Tile[,] Tiles = new Tile[MapSize, MapSize];
	public GameObject prefab;
	
	// Use this for initialization
	void Start () {
		this.CreateMap();
	}
	
	// Update is called once per frame
	void Update () {
		//For uncommenting in the future .... :)
		/*for (int x = 0; x < MapSize; x++) {
			for (int y = 0; y < MapSize; y++) {
				this.Tiles[x, y].UpdatePollution();
			}
		}*/
	}
	
	public void CreateMap() {
		System.Random r = new System.Random();
		PerlinNoise perlinNoise = new PerlinNoise(r.Next(1,99));
		double sizeDivisor = 1 / (double)MapSize;
		
		for(int y = 0; y < MapSize; y++)
		{
			for(int x = 0; x < MapSize; x++)
			{
				TileType tt;
				
				//Wenn Feld am Rand liegt, mache es unbebaubar (TileType.Empty)
				if(x == 0 || x == MapSize-1 || y == 0 || y == MapSize-1){
					tt = TileType.Empty;
				}else{ //Wenn nicht, setze generierten TileType
					double v =
			     	(perlinNoise.Noise(2 * x * sizeDivisor, 2 * y * sizeDivisor, -0.5) + 1) / 2 * 0.7 +
			     	(perlinNoise.Noise(4 * x * sizeDivisor, 4 * y * sizeDivisor, 0) + 1) / 2 * 0.2 +
			        (perlinNoise.Noise(8 * x * sizeDivisor, 8 * y * sizeDivisor, +0.5) + 1) / 2 * 0.1;
			
			        v = Math.Min(1, Math.Max(0, v));
					double b = Math.Round((v*50));
					
					if (b <= 18) { 						//Berg
						tt = TileType.Mountain;
					}else if (b >= 19 && b <= 21){ 		//Wüste
						tt = TileType.Desert;
					}else if (b >= 22 && b <= 29){ 		//Grassland
						tt = TileType.Grassland;
					}else if (b >= 30 && b <= 34){ 		//Meer
						tt = TileType.Sea;
					}else{ 								//Fluss
						tt = TileType.River;
					}
				}
				
				GameObject buffer = (GameObject)Instantiate(prefab, new Vector3(x, 0, y), Quaternion.identity);
				buffer.name = "Tile_" + x + "_" + y;
				Tile t = buffer.GetComponent<Tile>();
				t.Coords = new Vector2(x, y);
				t.Type = tt;
				this.Tiles[x, y] = t;
				
			}
		}
		
	}
	
	public List<Tile> GetEnvironmentTiles(Tile t) {
		Vector2 c = t.Coords;
		List<Tile> r = new List<Tile>();
		for (int x = (int)c.x - environmentRadius; x < (int)c.x + environmentRadius; x++) {
			for (int y = (int)c.y - environmentRadius; y < (int)c.y + environmentRadius; y++) {
				if (x >= 0 && y >= 0 && x < MapSize && y < MapSize) { //check if it is not outside of the array borders
					r.Add(this.Tiles[x, y]);
				}
			}
		}
		return r;	
	}
	
}
