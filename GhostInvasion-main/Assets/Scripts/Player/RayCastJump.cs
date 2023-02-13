using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastJump : MonoBehaviour
{
    bool booler;
    public LayerMask mask;
    RaycastHit2D rchit;
    [SerializeField] float distance;


    public bool IsGrounded()
    {
        rchit = Physics2D.Raycast(gameObject.transform.position, Vector2.down, distance, mask);
        if (rchit.collider != null)
        {
            Debug.DrawRay(gameObject.transform.position, Vector2.down * distance, Color.green);
            booler = true;
        }

        if (rchit.collider == null)
        {
            Debug.DrawRay(gameObject.transform.position, Vector2.down * distance, Color.red);
            booler = false;
        }

        return booler;
    }

}
