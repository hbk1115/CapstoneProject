using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public void DestroyThisObject()//애니메이션 뒤에서 오브젝트를 파괴
    {
        Destroy(this.gameObject);
    }

    public void DestoyThisOnParent()
    {
        Destroy(transform.parent.parent.gameObject);
    }
}
