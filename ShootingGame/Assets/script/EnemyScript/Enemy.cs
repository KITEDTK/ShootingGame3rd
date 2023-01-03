using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float health = 50f;

    public int damage = 1;

  
    public bool alreadyAttack;
    private float timeBetweenAttack = 0.5f ;
    public int score;

    [SerializeField]
    private InGameUI InGameUIScript;


    [SerializeField]
    private HeatlhBar healthBarScript;

    [SerializeField]
    private float lookRadius = 20f;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private Vector3 lookRadiusCube = new Vector3(0, 0, 0);
    [SerializeField]
    private float rotationSpeed = 20f;

    [SerializeField]
    private AsunaController player;


    private Animator animator;
    // Start is called before the first frame update

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        healthBarScript = GetComponentInChildren<HeatlhBar>();
        healthBarScript.SetMaxHealth(health);
    }
    // Update is called once per frame
    void Update()
    {
        InGameUIScript = GameObject.FindGameObjectWithTag("UI").GetComponent<InGameUI>();
        healthBarScript = GetComponentInChildren<HeatlhBar>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<AsunaController>();
        target = PlayerManager.instance.player.transform;
        agent = this.GetComponent<NavMeshAgent>();
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.transform.position);

            if (distance <= agent.stoppingDistance)
            {
                faceTarget();
                attackPlayer();
            }
        }
    }
    private void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
    public void takeDamage(float amout)
    {
        health -= amout;
        healthBarScript.setHeatlh(health);
        if (health <= 0f)
        {
            InGameUIScript.score += 20;
            Die();
        }
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }
    public float getHeatlh()
    {
        return this.health;
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    private void attackPlayer()
    {
        if(!alreadyAttack)
        {
            alreadyAttack = true;
            Invoke(nameof(resetAttack), timeBetweenAttack);
            player.takeDamage(damage);
            animator.SetBool("IsAttack", true);
            animator.SetBool("IsRunning", false);
        }
    }
    private void resetAttack()
    {
        alreadyAttack= false;
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsRunning", true);
    }
        
}
