using UnityEngine;
using System.Collections;

public class HexMapSpawner : MonoBehaviour {

    private HexMapTile baseTileObject;
    private bool mapDirty = true;
    private int totalTilesX = 5;
    private int totalTilesZ = 15;
    private float tileWidth = 2.0f;
	private bool isKeyDown = false;

	public Camera mainCamera;

	// Use this for initialization
	void Start () {
        Debug.Log("Start Hex Map");
        baseTileObject = GameObject.FindObjectOfType<HexMapTile>();
	}

    private void DrawMapTiles()
    {
		float startX = 0;//((tileWidth * totalTilesX) / 2) * -1;
		float startZ = 0;//((tileWidth * totalTilesZ) / 2) * -1;

        baseTileObject.gameObject.SetActive(true);
		for (var x = -totalTilesX; x < totalTilesX; x++)
        {
			for (var z = -totalTilesZ; z < totalTilesZ; z++)
            {
				int rowNum = (z < 0) ? -z : z;
				Debug.Log(rowNum);
				//float currX = startX + ((tileWidth * (tileWidth * 0.75f)) * x) + ((rowNum%2!=1) ? (tileWidth*0.75f) : 0);
				//float currZ = startZ + ((tileWidth / 2.3f) * z);
				HexMapTile tempTile = Instantiate(baseTileObject, new Vector3(0, 0, 0), Quaternion.identity) as HexMapTile;
				tempTile.SetTileCoords(new Vector3(x, 0f, z));
				//tempTile.SetTilePos(new Vector3(-currX, 0, -currZ));

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

		if(Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.D)
		    || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.LeftArrow) 
		    || Input.GetKeyDown (KeyCode.RightArrow) ) {

			isKeyDown = true;
		}

		if(Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.S) || Input.GetKeyUp (KeyCode.D)
		    || Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp (KeyCode.DownArrow) || Input.GetKeyUp (KeyCode.LeftArrow) 
		    || Input.GetKeyUp (KeyCode.RightArrow) ) 
		{
			
			isKeyDown = false;
		}


		if (isKeyDown) {

			if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
				mainCamera.transform.localPosition = new Vector3((mainCamera.transform.localPosition.x-0.2f), mainCamera.transform.localPosition.y, mainCamera.transform.localPosition.z);
			} 
			if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
				mainCamera.transform.localPosition = new Vector3((mainCamera.transform.localPosition.x+0.2f), mainCamera.transform.localPosition.y, mainCamera.transform.localPosition.z);

			}

			if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
				mainCamera.transform.localPosition = new Vector3((mainCamera.transform.localPosition.x), mainCamera.transform.localPosition.y, mainCamera.transform.localPosition.z+0.2f);
			} 
			if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
				mainCamera.transform.localPosition = new Vector3((mainCamera.transform.localPosition.x), mainCamera.transform.localPosition.y, mainCamera.transform.localPosition.z-0.2f);
				
			}
		}

	}
}
