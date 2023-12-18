using UnityEngine;

namespace Obstacles
{
    public class VerticalMovingObstacle : MonoBehaviour
    {
        [SerializeField] private float _speed = 10;
        [SerializeField] private float _movementDelta = 3;

        private Vector3 _up;
        private Vector3 _down;
        
        private float _currentTime;
        private float _oneWayTime;
        private bool _isMovingUp;

        private void Awake()
        {
            var position = transform.position;
            _up = new Vector3(position.x, position.y + _movementDelta, position.z);
            _down = new Vector3(position.x, position.y - _movementDelta, position.z);

            _oneWayTime = Vector3.Distance(_up, _down) / _speed;
        }

        private void Update()
        {
            _currentTime += _isMovingUp ? Time.deltaTime : -Time.deltaTime;
            var progress = Mathf.PingPong(_currentTime, _oneWayTime) / _oneWayTime;
            transform.position = Vector3.Lerp(_up, _down, progress);
        }
    }
}