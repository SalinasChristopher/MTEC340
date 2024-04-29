using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int enemyHP = 100;
    private Animator anim;

    private UnityEngine.AI.NavMeshAgent navAgent;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;

        if (enemyHP <= 0)
        {
            anim.SetTrigger("Die");
        }
        else{
            anim.SetTrigger("Damage");
        }
    }

    // private void Update()
    // {
    //     if (navAgent.velocity.magnitude > 0.1f)
    //     {
    //         anim.SetBool("IsWalking", true);
    //     }
    //     else
    //     {
    //         anim.SetBool("IsWalking,", false);
    //     }
    // }

    public void ClearEnemy()
    {
        Debug.Log("Enemy defeated!");
        Destroy(gameObject);
    }

}
