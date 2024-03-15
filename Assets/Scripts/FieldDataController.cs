using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldDataController : MonoBehaviour
{
    public GameObject csvReaderObj;
    private CSVReader csvReader;

    [HideInInspector] public List<List<CellData>> fieldData;


    void Start()
    {
        csvReader = csvReaderObj.GetComponent<CSVReader>();
        fieldData = csvReader.ReadCSV();
    }

    void Update()
    {
        
    }
}
