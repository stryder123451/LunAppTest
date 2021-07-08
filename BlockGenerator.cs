using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    [SerializeField]
    private int rows = 4;
    [SerializeField]
    private int col = 4;
    [SerializeField]
    private float tileSize = 1;
    [SerializeField]
    private JsonParse json;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    
    void Update()
    {
      
    }

    private void GenerateBlock()
    {
        GameObject gridTile = (GameObject)Instantiate(Resources.Load("Brick"));
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < col; j++)
            {
                GameObject tile = (GameObject)Instantiate(gridTile, transform);
                float posX = j * tileSize;
                float posY = i * -tileSize;
                tile.transform.position = new Vector2(posX, posY);
            }
        }
        Destroy(gridTile);
        float gridW = col * tileSize;
        float gridH = rows * tileSize;
        transform.position = new Vector2(-gridW / 2 + tileSize / 2, gridH / 2 + tileSize / 2);
    }

    private void Compare(List<int> list)
    {
        if (list.Count != 0)
        {
            Transform[] ts = GetComponentsInChildren<Transform>();
            List<Transform> children = new List<Transform>();
            for (int i = 0; i < ts.Length; i++)
            {
                if (ts[i].CompareTag("Brick"))
                {
                    children.Add(ts[i]);
                }
            }
            for (int i = 0; i < children.Count; i++)
            {
                if (children[i] != null)
                {

                    Color tmp = children[i].GetComponent<SpriteRenderer>().color;
                    switch (list[i])
                    {
                        case 0:
                            tmp.a = 0f;
                            children[i].GetComponent<SpriteRenderer>().color = tmp;
                            break;
                        case 1:
                            tmp.a = 1f;
                            children[i].GetComponent<SpriteRenderer>().color = tmp;
                            break;
                    }
                }

            }
        }
    }

    public void BlockCreate(int number)
    {
        switch (number)
        {
            case 0:
                GenerateBlock();
                Compare(json.block1);
                break;
            case 1:
                GenerateBlock();
                Compare(json.block2);
                break;
            case 2:
                GenerateBlock();
                Compare(json.block3);
                break;
            case 3:
                GenerateBlock();
                Compare(json.block4);
                break;
        }
    }
}
