using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_ball : MonoBehaviour
{
    public Transform target; // Hedef objenin referansı
    public float speed = 5f; // Uçuş hızı

    private void Update()
    {
        if (target != null)
        {
            // Hedefe doğru ilerle
            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);

            // Hedefe çarpışma kontrolü
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget < 0.5f) // Belirli bir mesafede hedefe çarparsa
            {
                // Hedefe çarptığında yapılacak işlemler
                Destroy(gameObject); // Kendi objeyi yok et
                 // Hedef objeyi yok et
            }
        }
    }
}
