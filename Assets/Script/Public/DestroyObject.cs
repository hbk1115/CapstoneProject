using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public void DestroyThisObject()//�ִϸ��̼� �ڿ��� ������Ʈ�� �ı�
    {
        Destroy(this.gameObject);
    }

    public void DestoyThisOnParent()
    {
        Destroy(transform.parent.parent.gameObject);
    }
}
