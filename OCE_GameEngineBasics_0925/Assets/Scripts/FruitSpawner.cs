using UnityEngine;
public class FruitSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _fruitPrefab;

    [SerializeField]
    private float _offsetNegative;
    [SerializeField]
    private float _offsetPositive;

    [SerializeField]
    private float _spawnCooldown;

    private float _spawnRemainingCooldown;

    void Start()
    {
        
    }

    void Update()
    {
        _spawnRemainingCooldown -= Time.deltaTime;

        if(_spawnRemainingCooldown <= 0)
        {
            SpawnFruit();
            _spawnRemainingCooldown = _spawnCooldown;
        }

    }

    void SpawnFruit()
    {
        float offset = Random.Range(_offsetNegative, _offsetPositive);
        Vector3 spawnPos = transform.position;
        spawnPos.x += offset;

        Instantiate(_fruitPrefab, spawnPos, Quaternion.identity);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position + new Vector3(_offsetNegative, 0, 0), transform.position + new Vector3(_offsetPositive, 0, 0));
    }
}
