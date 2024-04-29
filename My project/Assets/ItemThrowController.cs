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
        /* //�v���C���[��ʂő��삷��ꍇ�͂�����g���B�J�������������ꍇ�̓R�����g�A�E�g�̂܂܂ł悢
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
        //���������Ƃ��t���[�c����
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            var random = Random.Range(0, itemListManager.ItemList.Count-6);
            var item = Instantiate(itemListManager.ItemList[random], this.transform.position, Quaternion.identity);

            // �I�u�W�F�N�g��Rigidbody���Ȃ���Βǉ�����
            Rigidbody rb = item.GetComponent<Rigidbody>();
            if (!rb)
            {
                rb = item.AddComponent<Rigidbody>();
            }

            // �v���C���[�L�����N�^�[�̑O�����Ə�������擾���ē���������Ƃ��܂�
            Vector3 throwDirection = transform.forward + transform.up;

            // ������������
            rb.AddForce(throwDirection.normalized * forwardSpeed, ForceMode.VelocityChange);
            rb.AddForce(transform.up * upwardSpeed, ForceMode.VelocityChange); // ������ɂ��͂�������

            item.GetComponent<ItemManager>().ThrowNum = ThrowNum;
            ThrowNum++;
        }
    }
}
