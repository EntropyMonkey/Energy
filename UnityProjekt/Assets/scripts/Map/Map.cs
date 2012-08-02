using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

public class Map : MonoBehaviour {
	public const int MapSize = 50;
	private const int environmentRadius = 3;
	public Tile[,] Tiles = new Tile[MapSize, MapSize];
	public GameObject prefab;
	private StreamReader fileReader;
	private StreamWriter fileWriter;
	
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
	
	
	public void LoadMap() {
		
		
	}
	
	public void SaveMap() {
		string jsonMap = "";
		string fileName = "energysave_" + DateTime.Now.ToShortDateString() + ".json";
		
		
		try{
			for(int y = 0; y < MapSize; y++)
			{
				for(int x = 0; x < MapSize; x++)
				{
					jsonMap += Tiles[x, y].Save();
				}
			}
			Debug.Log(fileName);
			Debug.Log(jsonMap);
			
		}catch(Exception e){
			Debug.Log("Map Save failed!");	
		}
		
		
		
	}
	
	
	public void CreateMap() {
		System.Random r = new System.Random(); //Zufallsgenerator initialisieren
		double sizeDivisor = 1 / (double)MapSize;
		TileType[,] tmpTileArr = new TileType[MapSize, MapSize]; //temporäres Map-Array definieren
		bool goodMap = false; //Flag für gute Map / schlechte Map
		
		while(!goodMap){
			PerlinNoise perlinNoise = new PerlinNoise(r.Next(1,99)); //Noisegenerator mit Random Seed initialisieren
			
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
						
						
						// !!! Werte sind alle experimentell ermittelt, NICHT ÄNDERN !!!
						if (b <= 18) { 						//Berg
							tt = TileType.Mountain;
						}else if (b >= 19 && b <= 21){ 		//Wüste
							tt = TileType.Desert;
						}else if (b >= 22 && b <= 23){		//Grassland
							tt = TileType.Grassland;
						}else if (b >= 25 && b <= 29){ 		//Grassland
							tt = TileType.Grassland;
						}else if (b >= 30 && b <= 34){ 		//Meer
							tt = TileType.Sea;
						}else{ 								//Fluss
							tt = TileType.River;
						}
					}
					tmpTileArr[x, y] = tt; //TileType in temporäres Maparray schreiben
				}
			}
			
			//LINQ zum Zählen aller Tiles vom Typ Mountain
			int mountainCount = (from TileType item in tmpTileArr
	        	where item == TileType.Mountain
	        	select item).Count();
			Debug.Log("Mountain Count: " + mountainCount);
			
			//LINQ zum Zählen aller Tiles vom Typ Sea
			int seaCount = (from TileType item in tmpTileArr
	        	where item == TileType.Sea
	        	select item).Count();
			Debug.Log("Sea Count: " + seaCount);
			
			//LINQ zum Zählen aller Tiles vom Typ River
			int riverCount = (from TileType item in tmpTileArr
	        	where item == TileType.River
	        	select item).Count();
			Debug.Log("River Count: " + riverCount);
			
			//Wenn eine Mindestanzahl von Bergen/Flüssen/Meer auf der Karte vorhanden ist (gute Karte), erstelle Karte
			if(mountainCount >= 4 && riverCount >= 4 && seaCount >= 4){
				Debug.Log("Good Map found");
				goodMap = true;	
			}else{
				Debug.Log("Bad Map"); //Wenn nicht, generiere neue Karte (while)
			}
		}
		
		//Tiles in das Game einfügen
		for(int y = 0; y < MapSize; y++)
		{
			for(int x = 0; x < MapSize; x++)
			{
				GameObject buffer = (GameObject)Instantiate(prefab, new Vector3(x, 0, y), Quaternion.identity);
				buffer.name = "Tile_" + x + "_" + y;
				Tile t = buffer.GetComponent<Tile>();
				t.Coords = new Vector2(x, y);
				t.Type = tmpTileArr[x, y];
				this.Tiles[x, y] = t;
			}
		}
		
	}
	
	
	public Tile GetTileFromPosition(int x, int y) {
		return this.Tiles[x, y];
	}
	
	public List<Tile> GetEnvironmentTiles(Tile t) {
		Vector2 c = t.Coords;
		List<Tile> r = new List<Tile>();
		for (int x = (int)c.x - environmentRadius; x < (int)c.x + environmentRadius; x++) {
			for (int y = (int)c.y - environmentRadius; y < (int)c.y + environmentRadius; y++) {
				if (x >= 0 && y >= 0 && x < MapSize && y < MapSize && (int)c.x != x && (int)c.y != y) { //check if it is not outside of the array borders
					r.Add(this.Tiles[x, y]);
				}
			}
		}
		return r;	
	}
	
	public List<Tile> GetEnvironmentTiles(int tx, int ty) {
		Vector2 c = new Vector2(tx, ty);
		List<Tile> r = new List<Tile>();
		for (int x = (int)c.x - environmentRadius; x < (int)c.x + environmentRadius; x++) {
			for (int y = (int)c.y - environmentRadius; y < (int)c.y + environmentRadius; y++) {
				if (x >= 0 && y >= 0 && x < MapSize && y < MapSize && (int)c.x != x && (int)c.y != y) { //check if it is not outside of the array borders
					r.Add(this.Tiles[x, y]);
				}
			}
		}
		return r;	
	}
	
}
