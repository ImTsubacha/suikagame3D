using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public int DropNum;//落ちた順番、2つ生成を防ぐ
    public int Rank = 0;
    ItemListManager itemList;
    // Start is called before the first frame update
    void Start()
    {
        //ランク情報のリストを取得
        itemList = GameObject.Find("ItemListManager").GetComponent<ItemListManager>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            var item = collision.gameObject.GetComponent<ItemManager>();
            if (item.Rank != Rank) return;
            if (DropNum < item.DropNum)
            {
                var pos = collision.contacts[0].point;
                var next_item = Instantiate(itemList.ItemList[Rank + 1],pos,Quaternion.identity);
                itemList.DropNum++;

                next_item.GetComponent<ItemManager>().DropNum = itemList.DropNum;
            }

        }
    }
}
