using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ItemThrowcontroller : MonoBehaviour
{
    public int ThrowNum=0;
    public float speed = 1;
    public float forwardSpeed=3;
    public float upwardSpeed=3;

    public ItemListManager itemListManager;
    // Start is called before the first frame update
    void Start()
    {
        itemListManager = GameObject.Find("ItemListManager").GetComponent<ItemListManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /* //プレイヤーを別で操作する場合はこれを使う。カメラ操作をする場合はコメントアウトのままでよい
        var pos = this.transform.position;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += speed;
        }

        this.transform.position = pos;
        */
        //↓押したときフルーツ生成
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            var random = Random.Range(0, itemListManager.ItemList.Count-6);
            var item = Instantiate(itemListManager.ItemList[random], this.transform.position, Quaternion.identity);

            // オブジェクトにRigidbodyがなければ追加する
            Rigidbody rb = item.GetComponent<Rigidbody>();
            if (!rb)
            {
                rb = item.AddComponent<Rigidbody>();
            }

            // プレイヤーキャラクターの前方向と上方向を取得して投げる方向とします
            Vector3 throwDirection = transform.forward + transform.up;

            // 初速を加える
            rb.AddForce(throwDirection.normalized * forwardSpeed, ForceMode.VelocityChange);
            rb.AddForce(transform.up * upwardSpeed, ForceMode.VelocityChange); // 上方向にも力を加える

            item.GetComponent<ItemManager>().ThrowNum = ThrowNum;
            ThrowNum++;
        }
    }
}
