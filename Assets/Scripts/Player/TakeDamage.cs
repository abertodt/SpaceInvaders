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
        if(collision.tag == "Bullet" && collision.gameObject.GetComponent<Bullet>().EnemyBullet)
        {
            GameManager.Instance.Lifes--;
            transform.position = _startingPosition;
            Destroy(collision.gameObject);
        }
    }
}
