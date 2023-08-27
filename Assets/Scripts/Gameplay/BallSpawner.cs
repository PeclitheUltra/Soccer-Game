using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private CollectableBall _ballPrefab;
    [SerializeField] private int _ballsOnAField;
    [SerializeField] private Vector4 _bounds;
    [SerializeField] private float _ballCheckSize;
    private List<CollectableBall> _balls = new List<CollectableBall>();
    private Collider2D[] _checkCache = new Collider2D[1];
    
    private async UniTaskVoid OnEnable()
    {
        while (_balls.Count < _ballsOnAField)
        {
            var ball = Instantiate(_ballPrefab, transform.position + Vector3.right * 10f, Quaternion.identity, transform);
            ball.BallFinishedCollecting += RepositionBall;
            _balls.Add(ball);
        }

        for (int i = 0; i < _balls.Count; i++)
        {
            RepositionBall(_balls[i]);
            await UniTask.DelayFrame(1);
        }
    }

    private void RepositionBall(CollectableBall ball)
    {
        var roll = GetRandomPosition();
        while (!CheckPosition(roll))
        {
            roll = GetRandomPosition();
        }

        ball.transform.position = roll;
        ball.Appear();
    }

    private bool CheckPosition(Vector2 pos)
    {
        if (Physics2D.OverlapCircleNonAlloc(pos, _ballCheckSize, _checkCache) > 0)
            return false;
        return true;
    }

    private Vector2 GetRandomPosition()
    {
        return new Vector2(Random.Range(_bounds.x, _bounds.y), Random.Range(_bounds.z, _bounds.w));
    }

    private void OnDrawGizmos()
    {
        Vector3 center = new Vector3((_bounds.x + _bounds.y) / 2, (_bounds.z + _bounds.w) / 2, 0);
        Vector3 size = new Vector3(_bounds.y - _bounds.x, _bounds.w - _bounds.z, 1);
        Gizmos.DrawWireCube(center, size);
    }
}
