using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//[Serializable]
public class JsonParse : MonoBehaviour
{
   
    public List<int> points = new List<int>();
    public List<int> block1 = new List<int>();
    public List<int> block2 = new List<int>();
    public List<int> block3 = new List<int>();
    public List<int> block4 = new List<int>();
    public List<int> mainBlock = new List<int>();
    [SerializeField]
    private TextAsset textAsset;
    [SerializeField]
    private BlockGenerator blockGen1;
    [SerializeField]
    private BlockGenerator blockGen2;
    [SerializeField]
    private BlockGenerator blockGen3;
    [SerializeField]
    private BlockGenerator blockGen4;
    [SerializeField]
    private GridManager mainBlockGrid;
    public int edgeUp;
    public int edgeMiddle;
    public int edgeBottom;
    public int edgeUpTemp;
    public int edgeMidTemp;
    void Start()
    {
        Initialization();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public class Root
    {
        [JsonProperty("template")]
        public int[,] template { get; set; }

        [JsonProperty("parts")]
        public int[,,] parts { get; set; }
    }
  

    private void Initialization()
    {
        // JSON parse
        Root items = JsonConvert.DeserializeObject<Root>(textAsset.text);
     
        edgeUp = items.parts.GetUpperBound(0);
        edgeMiddle = items.parts.GetUpperBound(1);
        edgeBottom = items.parts.GetUpperBound(2);
        edgeUpTemp = items.template.GetUpperBound(0);
        edgeMidTemp = items.template.GetUpperBound(1);

        for (int i = 0; i <= edgeUp; i++)
        {
            for (int k = 0; k <= edgeMiddle; k++)
            {
                for (int j = 0; j <= edgeBottom; j++)
                {
                    points.Add(items.parts[i,k,j]);
                }
            }
        }


        for (int i = 0; i <= edgeUpTemp; i++)
        {
            for (int k = 0; k <= edgeMidTemp; k++)
            {
                mainBlock.Add(items.template[i,k]);
            }
        }

        // Block creation

        for (int i = 0; i < 16; i++)
        {
            block1.Add(points[i]);
        }
        for (int i = 16; i < 32; i++)
        {
            block2.Add(points[i]);
        }
        for (int i = 32; i < 48; i++)
        {
            block3.Add(points[i]);
        }
        for (int i = 48; i < 64; i++)
        {
            block4.Add(points[i]);
        }
        

        if (block1.Count != 0 && block2.Count != 0 && block3.Count != 0 && block4.Count != 0&& mainBlock.Count!=0)
        {
            blockGen1.BlockCreate(0);
            blockGen2.BlockCreate(1);
            blockGen3.BlockCreate(2);
            blockGen4.BlockCreate(3);
            mainBlockGrid.Compare(mainBlock);
        }
    }

}
