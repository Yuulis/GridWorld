using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellData
{
    /// <summary>
    /// cellType
    /// - 0 : empty (white)
    /// - 1 : obstacle (brown)
    /// - 2 : exit (green)
    /// - 3 : agent (red)
    /// - 9 : null
    /// </summary>
    public int cellType;

    
    public CellData(int cellType)
    {
        this.cellType = cellType;
    }
}
