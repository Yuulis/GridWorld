using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapController : MonoBehaviour
{
    [SerializeField] private Tilemap fieldTlemap;
    [SerializeField] private List<Tile> fieldTiles;

    public GameObject CSVReaderObj;
    private CSVReader CSVReader;
    private List<List<int>> fieldData;

    void Start()
    {
        CSVReader = CSVReaderObj.GetComponent<CSVReader>();
        fieldData = CSVReader.ReadCSV();
        SetTiles();
    }

    void Update()
    {
        
    }

    void SetTiles()
    {
        int height = fieldData.Count;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < fieldData[y].Count; x++)
            {
                fieldTlemap.SetTile(new Vector3Int(x, height - y - 1, 0), fieldTiles[fieldData[y][x]]);
            }
        }
    }
}
