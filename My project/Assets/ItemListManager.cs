using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemListManager : MonoBehaviour
{
    public int ThrowNum;
    public ItemThrowcontroller itemThrowController;
    //アイテムのランクを管理
    public List<GameObject> ItemList = new List<GameObject>();

}
