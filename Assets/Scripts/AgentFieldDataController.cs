using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AgentFieldDataController : MonoBehaviour
{
    public GameObject settingsObj;
    private Settings settings;

    public GameObject fieldControllerObj;
    private FieldDataController fieldDataController;

    [HideInInspector] public List<AgentData> agentFieldData;


    void Start()
    {
        settings = settingsObj.GetComponent<Settings>();
        fieldDataController = fieldControllerObj.GetComponent<FieldDataController>();

        SetAgentsList();
    }

    void Update()
    {
        
    }

    /// <summary>
    /// Create a List of AgentData.
    /// </summary>
    private void SetAgentsList()
    {
        agentFieldData = new List<AgentData>();
        for (int i = 0; i < settings.agentNum; i++)
        {
            Vector2Int spawnPos = new(Random.Range(0, settings.fieldWidth), Random.Range(0, settings.fieldHeight));
            while (fieldDataController.fieldData[spawnPos.y][spawnPos.x].cellType != 0)
            {
                spawnPos = new(Random.Range(0, settings.fieldWidth), Random.Range(0, settings.fieldHeight));
            }

            agentFieldData.Add(new AgentData(i, spawnPos, true));
        }
    }
}
