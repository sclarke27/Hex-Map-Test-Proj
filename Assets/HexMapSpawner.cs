using UnityEngine;
using System.Collections;

public class HexMapSpawner : MonoBehaviour {

    private HexMapTile baseTileObject;
    private bool mapDirty = true;
    private int totalTilesX = 8;
    private int totalTilesZ = 6;
    private int tileWidth = 2;

	// Use this for initialization
	void Start () {
        Debug.Log("Start Hex Map");
        baseTileObject = GameObject.FindObjectOfType<HexMapTile>();
        

        
	}

    private void DrawMapTiles()
    {
        float startX = ((tileWidth * totalTilesX) / 2) * -1;
        float startZ = ((tileWidth * totalTilesZ) / 2) * -1;

        baseTileObject.gameObject.SetActive(true);
        for (var x = 0; x < totalTilesX; x++)
        {
            for (var z = 0; z < totalTilesZ; z++)
            {
                float currX = startX + (tileWidth * x);
                float currZ = startZ + (tileWidth * z);
                Instantiate(baseTileObject, new Vector3(currX, 0, currZ), Quaternion.identity);
            }

        }
            
        baseTileObject.gameObject.SetActive(false);
    }

	
	// Update is called once per frame
	void Update () {
        if (mapDirty)
        {
            mapDirty = false;
            Debug.Log("Update Hex Map");
            DrawMapTiles();
            
        }
	}
}
