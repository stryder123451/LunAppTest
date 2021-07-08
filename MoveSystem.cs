using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : MonoBehaviour
{
    public GameObject correctForm;
    private bool moving;
    private float startPosX;
    private float startPosY;
    [SerializeField]
    private GameObject pos;
    public bool complete;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, transform.localPosition.y);
        }
        else if (Mathf.Abs(transform.localPosition.x - correctForm.transform.localPosition.x) > 0.5f || Mathf.Abs(transform.localPosition.y - correctForm.transform.localPosition.y) > 0.5f)
        {
            transform.position = Vector2.Lerp(transform.position, pos.transform.position, 2.5f * Time.deltaTime);
        }

        if (transform.localPosition == new Vector3(correctForm.transform.localPosition.x, correctForm.transform.localPosition.y, correctForm.transform.localPosition.z))
        {
            complete = true;
        }
        else
        {
            complete = false;
        }
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            startPosX = mousePos.x - transform.localPosition.x;
            startPosY = mousePos.y - transform.localPosition.y;
            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;
        if (Mathf.Abs(transform.localPosition.x - correctForm.transform.localPosition.x) <= 0.1f && Mathf.Abs(transform.localPosition.y - correctForm.transform.localPosition.y) <= 0.1f)
        {
            transform.localPosition = new Vector3(correctForm.transform.localPosition.x, correctForm.transform.localPosition.y, correctForm.transform.localPosition.z);
        }
    }

    
}
