using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SkeletonAI : MonoBehaviour
{
    private NavMeshAgent nav;
    public GameObject player;
    //private float updateTime = 0;
    public Animator anim;
    private PlayerData data;
    private bool isAttacking = false;

    public float minDamage;
    public float maxDamage;

    public void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        data = FindObjectOfType<PlayerData>();

    }
    public void update()
    {
        //updateTime += Time.deltaTime;
        //Debug.Log(updateTime);
        
        //float dist = Vector3.Distance(this.transform.position, player.transform.position);
        
        //if (dist <= 4)
        //{
        //    anim.SetBool("Attack", true);
        //}
        //    if (!isAttacking)
        //  {
        //     StartCoroutine(Attack());
        //   }
        // }
        //else
        //{
            //walk
            //anim.SetBool("Attack", false);
            // isAttacking = false;
            //}


        //}
    }
    IEnumerator Attack()
    {   
        if(!isAttacking)
        {
            isAttacking = true;
            anim.SetBool("Attack", true);
            yield return new WaitForSeconds(1.2f);
            data.TakeDamage(Random.Range(minDamage, maxDamage));
            isAttacking = false;
        }


   
    }

    private void LateUpdate()
    {
        transform.LookAt(player.transform);
        nav.destination = player.transform.position;
        float dist = Vector3.Distance(this.transform.position, player.transform.position);
        if (dist <= 4)
        {   
            if(!isAttacking)
            {
                StartCoroutine(Attack());
            }
        }
        else
        {
            //Debug.Log("hey");
            //walk
            //anim.SetBool("Attack", false);
            isAttacking = false;
            //}


        }
        //updateTime = 0;






    }
}
