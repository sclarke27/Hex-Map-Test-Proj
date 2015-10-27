using UnityEngine;
using System.Collections;

public class HexMapSpawner : MonoBehaviour {

    private HexMapTile baseTileObject;
    private bool mapDirty = true;
    private int totalTilesX = 14;
    private int totalTilesZ = 28;
    private float tileWidth = 2.0f;

	public Camera mainCamera;

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
				float currX = startX + ((tileWidth * (tileWidth * 0.75f)) * x) + ((z%2!=1) ? (tileWidth*0.75f) : 0);
				float currZ = startZ + ((tileWidth / 2.3f) * z);

                Instantiate(baseTileObject, new Vector3(-currX, 0, -currZ), Quaternion.identity);



            }

        }
            
        baseTileObject.gameObject.SetActive(false);
    }

	
	// Update is called once per frame
	void Update () {
        if (mapDirty)
        {
            mapDirty = false;
            DrawMapTiles();
            
        }
		if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.D)) {
			if(Input.GetKeyDown(KeyCode.A)) {
				mainCamera.transform.localPosition = new Vector3((mainCamera.transform.localPosition.x-0.2f), mainCamera.transform.localPosition.y, mainCamera.transform.localPosition.z);
			} else {
				mainCamera.transform.localPosition = new Vector3((mainCamera.transform.localPosition.x+0.2f), mainCamera.transform.localPosition.y, mainCamera.transform.localPosition.z);

			}
		}
	}
}
