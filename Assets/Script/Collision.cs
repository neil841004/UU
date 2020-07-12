using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [Header("Layers")]
    public LayerMask groundLayer;

    [Space]

    public Collider2D[] onGround;

    [Space]
    
    [Header("Collision")]
    public Vector3 collisoinRadius;
    public Vector3 bottomOffset;

    private void FixedUpdate()
    {
        OnGround();
    }

    public bool OnGround()
    {
        onGround = Physics2D.OverlapBoxAll(transform.position + bottomOffset, collisoinRadius, 0, groundLayer);
        if (onGround.Length > 0)
        {
            return true;
        }
        else return false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position + bottomOffset, collisoinRadius * 2);
    }
}
