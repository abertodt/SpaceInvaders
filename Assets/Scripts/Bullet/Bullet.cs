using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public bool EnemyBullet;
    [SerializeField] private float _speed;

    // Update is called once per frame
    void Update()
    {
        if (!EnemyBullet)
        {
            transform.position += transform.up * _speed * Time.deltaTime;
        }
        else
        {
            transform.position -= transform.up * _speed * Time.deltaTime;

        }
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!EnemyBullet && collision.tag == "Enemy") 
        {
            Destroy(gameObject);
            EnemyManager.Instance.RemoveFromList(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
