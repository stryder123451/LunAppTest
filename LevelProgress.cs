using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{

    public int blocksComplete;
    [SerializeField]
    private GameObject successWindow;
    [SerializeField]
    private MoveSystem block1;
    [SerializeField]
    private MoveSystem block2;
    [SerializeField]
    private MoveSystem block3;
    [SerializeField]
    private MoveSystem block4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (block1.complete==true && block2.complete == true && block3.complete == true && block4.complete == true)
        {
            successWindow.SetActive(true);
            DeleteBricks();
        }
        else
        {
            successWindow.SetActive(false);
        }
    }

    void DeleteBricks()
    {
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
        foreach (var x in bricks)
        {
            Destroy(x);
        }
    }
}
