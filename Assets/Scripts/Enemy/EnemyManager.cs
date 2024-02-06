using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _EnemyList;
    [SerializeField] private float _limitXP;
    [SerializeField] private float _limitXN;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _limitY;
    public bool _isGoingRight = true;
    private float _shootCounter;

    public static EnemyManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            Destroy(this);
        }
    }

    private void Start()
    {
        FillList();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGoingRight)
        {
            transform.position += transform.right * _speed * Time.deltaTime;
        }
        else
        {
            transform.position -= transform.right * _speed * Time.deltaTime;

        }

        foreach (GameObject enemy in _EnemyList)
        {
            if (enemy.transform.position.x > _limitXP)
            {
                ChangeDirections();
            }

            if (enemy.transform.position.x < _limitXN)
            {
                ChangeDirections();
            }

            if(enemy.transform.position.y <= _limitY)
            {
               GameManager.Instance.Die();
            }
        }

       
        if (_shootCounter < 1)
        {
            _shootCounter += Time.deltaTime;
        }else if(_shootCounter >= 1) 
        {
            Shoot();
            _shootCounter = 0;
        }

        if (_EnemyList.Any())
        {
            Debug.Log("ganaste");
        }
    }

    private void Shoot()
    {
        int index = Random.Range(0, _EnemyList.Count);
        GameObject enemy = _EnemyList[index];

        Instantiate(_bullet, enemy.transform.position, enemy.transform.rotation);
    }
    
    private void ChangeDirections()
    {
        if (_isGoingRight)
        {
            transform.position += new Vector3(-0.1f, -0.1f, 0);
            _isGoingRight = false;
            return;
        }
        else
        {
            transform.position += new Vector3(0.1f, -0.1f, 0);
            _isGoingRight = true;
            return;
        }
    }

    private void FillList()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            _EnemyList.Add(transform.GetChild(i).gameObject);
        }
    }

    public void RemoveFromList(GameObject _enemy)
    {
        _EnemyList.Remove(_enemy);
        _speed += 0.1f;
    }

}
