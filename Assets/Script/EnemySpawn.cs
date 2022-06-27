using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _point;
    [SerializeField] private int _countObject;
    [SerializeField] private float _delay;

    private Transform[] _points;
    private int _currrentPoint;
    private int _currentCountObject;

    private void Start()
    {
        _points = new Transform[_point.childCount];

        for (int i = 0; i < _point.childCount; i++)
        {
            _points[i] = _point.GetChild(i);
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (_countObject > _currentCountObject)
        {
            Instantiate(_enemy, _points[_currrentPoint].position, Quaternion.identity);
            _currentCountObject++;
            _currrentPoint++;

            if (_currrentPoint >= _points.Length)
            {
                _currrentPoint = 0;
            }

            yield return new WaitForSeconds(_delay);
        }
    }
}
