using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public bool _enemyBullet;
    [SerializeField] private float _speed;

    // Update is called once per frame
    void Update()
    {
        if (!_enemyBullet)
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
        if (!_enemyBullet && collision.tag == "Enemy") 
        {
            Destroy(gameObject);
            EnemyManager.Instance.RemoveFromList(collision.gameObject);
            Destroy(collision.gameObject);
        }

        if(_enemyBullet && collision.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("au");
        }
    }
}
