using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _limitXP;
    [SerializeField] private float _limitXN;
    float _horizontalInput;

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");

        gameObject.transform.position += new Vector3(_horizontalInput, 0, 0) * _speed * Time.deltaTime;

        if(transform.position.x < _limitXN)
        {
            transform.position = new Vector2(_limitXN, transform.position.y);
        }

        if (transform.position.x > _limitXP)
        {
            transform.position = new Vector2(_limitXP, transform.position.y);
        }
    }
}
