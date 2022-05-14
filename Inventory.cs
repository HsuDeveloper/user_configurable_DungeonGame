using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<Dictionary<string,object>> data = CSVReader.Read("inventory");

        for(int i=0;i<data.Count;i++)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
