using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CSVReader : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    /// <summary>
    /// Read field data from a CSV file.
    /// </summary>
    /// <returns>2D List containing CellData</returns>

    public List<List<CellData>> ReadCSV()
    {
        List<List<CellData>> fieldData = new();
        TextAsset fieldDataCSV = Resources.Load("fieldData") as TextAsset;

        StringReader reader = new(fieldDataCSV.text);
        List<string[]> csvData = new();
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            csvData.Add(line.Split(','));
        }

        foreach (string[] strs in csvData)
        {
            List<CellData> list = new();
            foreach (string str in strs)
            {
                if (int.TryParse(str, out var s)) 
                { 

                    list.Add(new CellData(Int32.Parse(str)));
                }
                else
                {
                    Debug.LogError($"{s} cannnot parse to Int32.");
                }
            }

            fieldData.Add(list);
        }

        return fieldData;
    }
}
