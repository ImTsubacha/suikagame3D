using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ItemThrowcontroller : MonoBehaviour
{
    public int ThrowNum;
    public float speed;

    public ItemListManager itemListManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = this.transform.position;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += speed;
        }
        this.transform.position=pos;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var random = Random.Range(0, itemListManager.ItemList.Count-6);
            Instantiate(itemListManager.ItemList[random], this.transform.position, Quaternion.identity);
            itemListManager.GetComponent<ItemManager>().ThrowNum = ThrowNum;
            ThrowNum++;
        }
    }
}
