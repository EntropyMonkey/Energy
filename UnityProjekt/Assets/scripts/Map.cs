using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
	public const int MapSize = 50;
	public Tile[,] Tiles = new Tile[MapSize, MapSize];
	public GameObject prefab;
	
	// Use this for initialization
	void Start () {
	
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
		Random r = new Random();
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
				
				GameObject buffer = Instantiate(prefab, new Vector3(x, 0, y), Quaternion.identity);
				Tile t = buffer.GetComponent<Tile>();
				t.Coords = new Vector2(x, y);
				t.Type = tt;
				this.Tiles[x, y] = t;
				
			}
		}
		
	}
	
	public List<Tile> GetEnvironmentTiles(Tile t) {
		Vector2 c = t.Coords;
		List<Tile> r;
		for (int x = c.X - this.environmentradius; x < c.X + this.environmentradius; x++) {
			for (int y = c.Y - this.environmentradius; y < c.Y + this.environmentradius; y++) {
				if (x >= 0 && y >= 0 && x < MapSize && y < MapSize) {
					r.Add(this.Tiles[x, y]);
				}
			}
		}
		return r;	
	}
	
}
