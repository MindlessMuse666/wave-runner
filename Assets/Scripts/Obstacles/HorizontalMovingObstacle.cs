using UnityEngine;

namespace Obstacles
{
    public class HorizontalMovingObstacle : MonoBehaviour
    {
        [SerializeField] private float _speed = 10;
        [SerializeField] private float _movementDelta = 3;

        private Vector3 _left;
        private Vector3 _right;

        private float _currentTime;
        private float _oneWayTime;
        private bool _isMovingRight;

        private void Awake()
        {
            var position = transform.position;
            _left = new Vector3(position.x - _movementDelta, position.y, position.z);
            _right = new Vector3(position.x + _movementDelta, position.y, position.z);

            _oneWayTime = Vector3.Distance(_left, _right) / _speed;
        }

        private void Update()
        {
            _currentTime += _isMovingRight ? Time.deltaTime : -Time.deltaTime;
            var progress = Mathf.PingPong(_currentTime, _oneWayTime) / _oneWayTime;
            transform.position = Vector3.Lerp(_left, _right, progress);
        }
    }
}