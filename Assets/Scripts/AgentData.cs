using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentData
{
    // Agent identification number
    public int id;

    // Current position of the agent (index of fieldData)
    public Vector2Int position;

    // Flag if the agent is operational or not
    public bool active;


    public AgentData(int id, Vector2Int position, bool active)
    {
        this.id = id;
        this.position = position;
        this.active = active;
    }
}
