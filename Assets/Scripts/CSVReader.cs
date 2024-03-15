using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CSVReader : MonoBehaviour
{
    public GameObject settingsObj;
    private Settings settings;


    void Start()
    {
        settings = settingsObj.GetComponent<Settings>();
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
            // If the description of fieldData in settings.cs and the format of the read data do not match, an error is returned.
            if (csvData.Count != settings.fieldHeight)
            {
                Debug.LogError($"The height of fieldData ({csvData.Count}) is different from the value in setting.cs ({settings.fieldHeight}).");
                break;
            }
            if (strs.Length != settings.fieldWidth)
            {
                Debug.LogError($"The width of fieldData ({strs.Length}) is different from the value in setting.cs ({settings.fieldWidth}).");
                break;
            }

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
