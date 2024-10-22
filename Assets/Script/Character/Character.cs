using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.VolumeComponent;

public abstract class Character : MonoBehaviour
{
    public abstract void Dead();
    public abstract void Hit(int damage, Character attacker);
    public abstract void Act();
}
