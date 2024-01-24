using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstacles;
    [SerializeField] private GameObject[] _coins;
    [SerializeField, Range(-5, 5)] private float _minX;
    [SerializeField, Range(-5, 5)] private float _maxX;
    [SerializeField, Range(0, 60)] private float _timeToSpawn;

    private float _timer = 0;

    private void Update() {
        if (!GameManager.isPlaying) return;

        if (_timer < _timeToSpawn) {
            _timer += Time.deltaTime;
            return;
        }

        if (Random.Range(0, 6) == 0)
            SpawnCoin();
        else
            SpawnObstacle();

        _timer = 0;
    }

    private void SpawnObstacle() {
        GameObject randObstacle = _obstacles[Random.Range(0, _obstacles.Length)];   
        float randX = Random.Range(_minX, _maxX);

        var obstacle = Instantiate(randObstacle, transform);
        obstacle.transform.position = new Vector3(randX, 0, transform.position.z);
    }

    private void SpawnCoin() {
        GameObject randCoin = _coins[Random.Range(0, _coins.Length)];
        float randX = Random.Range(_minX, _maxX);

        var coin = Instantiate(randCoin, transform);
        coin.transform.position = new Vector3(randX, 0.75f, transform.position.z);
    }
}
