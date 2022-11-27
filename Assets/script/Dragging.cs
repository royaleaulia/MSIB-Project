using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragging : MonoBehaviour
{

    public GameObject item;
    public GameObject itemDrop;

    public int jarak;

    Vector3 itemPos;
    // Start is called before the first frame update
    void Start()
    {
        itemPos = item.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ItemDrag()
    {
        item.transform.position = Input.mousePosition;

    }


    public void ItemEndDrag()
    {
        float distance = Vector3.Distance(item.transform.localPosition, itemDrop.transform.localPosition);

        if (distance < jarak)
        {
            item.transform.localPosition = itemDrop.transform.localPosition;
        }
        else
        {
            item.transform.localPosition = itemPos;
        }
    }
}
