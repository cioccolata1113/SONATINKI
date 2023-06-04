using UnityEngine;

public class Mermi : MonoBehaviour
{
    public Transform target;
    public float speed = 50f;
    public float stoppingDistance = 1f;

    private int sayac= 0;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {   
        
        GameObject target = GameObject.FindGameObjectWithTag("Hedef");
        transform.LookAt(target.transform);
        if (target != null)
        {
            Vector3 direction = target.transform.position -transform.position  ;
            rb.AddForce(direction.normalized * speed);
            
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(sayac == 0)
        {
          Destroy(gameObject, 0f);  
        } else{
            sayac += 1;
        }
        
    }
}
