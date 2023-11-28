using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField]
    private LevelConnection _connection;

    [SerializeField]
    private string _targetSceneName;

    [SerializeField]
    private Transform _spawnPoint;

    private void Start()
    {
        if (_connection == LevelConnection.ActiveConnection)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = _spawnPoint.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = GameObject.Find("Player").GetComponent<PlayerController>();
        if ( player != null )
        {
        LevelConnection.ActiveConnection = _connection;
        SceneManager.LoadScene(_targetSceneName);
        }
    }
}
