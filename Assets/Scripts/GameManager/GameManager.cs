using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Lifes = 3;
    public int Points = 0;

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemies;
    [SerializeField] private TextMeshProUGUI _textLifes;
    [SerializeField] private GameObject _gameOverText;
    [SerializeField] private GameObject _restartText;
    [SerializeField] private TextMeshProUGUI _pointsText;

    private bool _courutineStarted;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _textLifes.text = "Lifes: " + Lifes.ToString();
        _pointsText.text = "Points: " + Points.ToString();


        if (Lifes == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Lifes = 0;
        Destroy(_player);
        _enemies.GetComponent<EnemyManager>().enabled = false;
        _enemies.transform.position = new Vector3(0, -1f, 0);
        
        if(!_courutineStarted) StartCoroutine(GameOver());

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _courutineStarted = false;
            RestartGame();
        }
    }

    private IEnumerator GameOver()
    {
        _courutineStarted = true;
        while (_courutineStarted)
        {
            _gameOverText.SetActive(true);
            _restartText.SetActive(true);
            yield return new WaitForSeconds(0.8f);
            _gameOverText.SetActive(false);
            _restartText.SetActive(false);
            yield return new WaitForSeconds(0.8f);
        }   
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
