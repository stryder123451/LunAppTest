using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private int rows = 4;
    [SerializeField]
    private int col = 4;
    [SerializeField]
    private float tileSize = 1;

    // Start is called before the first frame update
    void Start()
    {
      GenerateGrid();
    }


    private void GenerateGrid()
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

    public void Compare(List<int> list)
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
                            tmp.a = 0.5f;
                            children[i].GetComponent<SpriteRenderer>().color = tmp;
                            break;
                    }
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Camera.main.transform.position.x+1, Camera.main.transform.position.y+1.8f, -2.993164f);
    }
}
