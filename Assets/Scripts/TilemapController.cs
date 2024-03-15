using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapController : MonoBehaviour
{
    [SerializeField] private Tilemap fieldTilemap;
    [SerializeField] private Tilemap agentFieldTilemap;
    [SerializeField] private List<Tile> tiles;

    public GameObject fieldDataControllerObj;
    private FieldDataController fieldDataController;
    private List<List<CellData>> fieldData;

    public GameObject agentFieldDataControllerObj;
    private AgentFieldDataController agentFieldDataController;
    private List<AgentData> agentfieldData;

    void Start()
    {
        fieldDataController = fieldDataControllerObj.GetComponent<FieldDataController>();
        this.fieldData = fieldDataController.fieldData;
        agentFieldDataController = agentFieldDataControllerObj.GetComponent<AgentFieldDataController>();
        this.agentfieldData = agentFieldDataController.agentFieldData;

        SetFieldTiles();
    }

    void Update()
    {
        UpdateAgentTiles();
    }

    /// <summary>
    /// Set fieldTilemap from information in fieldData.
    /// </summary>
    private void SetFieldTiles()
    {
        int height = fieldData.Count;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < fieldData[y].Count; x++)
            {
                fieldTilemap.SetTile(new Vector3Int(x, height - y - 1, 0), tiles[fieldData[y][x].cellType]);
            }
        }
    }

    /// <summary>
    /// Set agentFieldTilemap from information in agentFieldData.
    /// </summary>
    private void UpdateAgentTiles()
    {
        foreach (AgentData agentData in agentfieldData)
        {
            agentFieldTilemap.SetTile(new Vector3Int(agentData.position.x, fieldData.Count - agentData.position.y - 1, 0), tiles[3]);
        }
    }
}
