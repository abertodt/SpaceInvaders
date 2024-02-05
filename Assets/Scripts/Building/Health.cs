using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health = 15;

    // Update is called once per frame
    void Update()
    {
        if(_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void TakeDamage()
    {
        _health--;
        transform.localScale -= new Vector3(0.07f, 0,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }
}
