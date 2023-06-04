using UnityEngine;


public class Uzakci_1 : MonoBehaviour
{   
    public bool farkEdilme = false;
    public GameObject ucan_bomba;
    public GameObject kalkan;
    public Transform player;
    
    public string mermitagi;
    //Stats
    public int health1 = 100;
    public int health2 = 125;
    public int health3 = 150;

    public int dalga = 1;

    //Check for Ground/Obstacles
    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public GameObject body;
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //Attack Player
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public bool isDead;
    private bool kalkanKapali = true;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
  
    public Material green, red, yellow;
    public GameObject projectile;
    private void Awake()
    {
    
    }
    private void Update()
    {   
        DalgaKontrol();
        if (!isDead && kalkanKapali)
        {                        
             AttackPlayer();
        } else if(isDead)
        {

        }
    }

   
    private void AttackPlayer()
    {
        if (isDead) return;

        transform.LookAt(player);
        
        if (!alreadyAttacked){

            int randomInt = Random.Range(0, 20);
            

            //Attack
            GameObject mermi = Instantiate(projectile, transform.position, Quaternion.identity);
            Rigidbody rb = mermi.GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 15f, ForceMode.Impulse);
            rb.AddForce(transform.up * 1f, ForceMode.Impulse);

            Destroy(mermi, 3f);

            if (randomInt % 5 != 0)
            {
                alreadyAttacked = true;
                Invoke("ResetAttack", timeBetweenAttacks);
            } else
            //Tutukluk
            {
                alreadyAttacked = true;
                Invoke("ResetAttack", timeBetweenAttacks * 2);
            }
            
            
        }

        //GetComponent<MeshRenderer>().material = red;
    }
    private void ResetAttack()
    {
        if (isDead) return;

        alreadyAttacked = false;
    }
    public void TakeDamage(int damage)
    {
       if (dalga == 1)
       {
        health1 -= damage;
        if( health1 < 0)
        {
            
            dalga += 1;
        }

       } else if (dalga == 3)
       {
        health2 -= damage;
        if( health2 < 0)
        {
            
            dalga += 1;
        }

       } else if (dalga == 5)
       {
        health3 -= damage;
        if( health3 < 0)
        {
            isDead = true;
        }

       }
       
    }
    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
    private void OnTriggerEnter(Collider other) {

        if(other.tag == mermitagi)
        {
            TakeDamage(Random.Range(20,30));
        }
    }
    private void KorumaModuAc()
    {
        kalkan.SetActive(true);
        kalkanKapali = false;
    }
    private void KorumaModuKapa()
    {
        
    }public void DalgaKontrol()
    {
        if(dalga == 1 || dalga ==3||dalga ==5 )
        {
            kalkan.SetActive(false);
            kalkanKapali = true;
        }else if (dalga == 2 || dalga == 4)
        {
            kalkan.SetActive(true);
            kalkanKapali = false;
            for(int i = 0; i<5 ; i++)
                Instantiate(ucan_bomba,transform.position,Quaternion.identity);
        }
    }

    
}