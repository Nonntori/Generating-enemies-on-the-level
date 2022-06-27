using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Transform _point;
    [SerializeField] private int _countObject;
    [SerializeField] private float _time;

    private Transform[] _points;
    private int _currrentPoint;
    private int _currentCountObject;
    private float _runningTime;

    private void Start()
    {
        _points = new Transform[_point.childCount];

        for (int i = 0; i < _point.childCount; i++)
        {
            _points[i] = _point.GetChild(i);
        }
    }

    private void Update()
    {
        if (_countObject > _currentCountObject)
        {
            _runningTime += Time.deltaTime;

            if (_time <= _runningTime)
            {
                Instantiate(_gameObject, _points[_currrentPoint].position, Quaternion.identity);
                _currentCountObject++;
                _currrentPoint++;
                _runningTime = 0;
            }

            if (_currrentPoint >= _points.Length)
            {
                _currrentPoint = 0;
            }
        }
    }
}
