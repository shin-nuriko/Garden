using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    AttackerSpawner myLaneSpawner;

    private void Start()
    {
        SetLaneSpawner();
    }
    private void Update()
    {
        if(IsAttackerInLane())
        {
            gameObject.GetComponent<Animator>().Play("Attack");
        } 
        else
        {
            gameObject.GetComponent<Animator>().Play("Idle");
        }
    }
    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (
                Mathf.Abs(spawner.transform.position.y - transform.position.y) //get absolute value
                <= Mathf.Epsilon);
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
            return false;
        else        
            return true;
        
    }

    public void Fire()
    {
        Instantiate(
            projectile,
            transform.position,
            Quaternion.identity
            );    
    }
}
