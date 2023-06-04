using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oyuncu_1 : MonoBehaviour
{   
    public CharacterController cc;
    public string objectATag = "mermi"; // "A" tagli objenin etiketi
    public string objectBTag = "ObjectB"; // "B" tagli objenin etiketi

    private GameObject objectA; // "A" tagli objenin referansı
    public GameObject objectB; // "B" tagli objenin referansı

    public float pullSpeed = 5f; // Çekme hızı

    private void Start()
    {
      
        
    }

    private void Update()
    {
        


    }


    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag(objectATag))
        {
            Vector3 pullDirection =   objectB.transform.position - transform.position;

            cc.Move(pullDirection/10);
        }
    } 
        
    
}
