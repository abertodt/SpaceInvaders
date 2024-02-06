using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private Vector3 _startingPosition;

    private void Start()
    {
        _startingPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject col = collision.gameObject;

        if(collision.tag == "Bullet" && col.GetComponent<Bullet>().EnemyBullet)
        {
            GameManager.Instance.Lifes--;
            transform.position = _startingPosition;
        }
    }
}
