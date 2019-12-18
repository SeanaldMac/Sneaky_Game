using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float MaxUp;
    public float MaxDown;
    public float MaxLeft;
    public float MaxRight;
    public float LOSrange;
    public float LOSangle;

    public GameObject Player;

    public Vector3 CurrentSpace;
    public Vector3 LOSdist(float degrees, bool Global)
    {
        if (!Global)
        {
            degrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(degrees * Mathf.Deg2Rad), 0, Mathf.Cos(degrees * Mathf.Deg2Rad));
    }

    public LayerMask SeePlayer;
    public LayerMask BlockPlayer;

    private Vector3 startingspace;

    private bool lineofSight;


    // Start is called before the first frame upda
    void Start()
    {
        lineofSight = false;
    }

    void DetectPlayer()
    {
        Collider[] Sight = Physics.OverlapSphere(transform.position, LOSrange, SeePlayer);

        for (int i = 0; i < Sight.Length; i++)
        {
            Transform Player = Sight[i].transform;
            Vector3 whereplayer = (Player.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, whereplayer) < LOSangle / 2)
            {
                float lengthToPlayer = Vector3.Distance(transform.position, Player.position);
                if (!Physics.Raycast(transform.position, whereplayer, lengthToPlayer, BlockPlayer))
                {
                    lineofSight = true;
                }
            }

        }
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        //one to move up and down
        if (tag == "vertical")
        {
            if (CurrentSpace.z > startingspace.z + MaxUp)
            {
                //Transform.forward = speed * -1;
            }
            if (CurrentSpace.z < startingspace.z - MaxDown)
            {
                //Transform.forward = speed * 1;
            }
            else
            {
                //Transform.forward = speed * 1;
            }
        }
        if (tag == "horizontal")
        {
            if (CurrentSpace.x > startingspace.x - MaxLeft)
            {
                //Transform.right  = speed * 1;
            }
            if (CurrentSpace.x < startingspace.x + MaxRight)
            {
                // Transform.right = speed * -1;
            }
            else
            {
                //Transform.right = speed * 1;
            }
        }
        if (lineofSight == true)
        {

        }
    }



    public void Gameover()
    {
        if (lineofSight)
        {

        }


    }
}



