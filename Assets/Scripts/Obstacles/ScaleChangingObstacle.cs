using UnityEngine;

namespace Obstacles
{
    public class ScaleChangingObstacle : MonoBehaviour
    {
        [SerializeField] private float _speed = 10;
        [SerializeField] private float _scalingDelta = 3;

        private Vector3 _up;
        private Vector3 _down;

        private float _currentTime;
        private float _oneWayTime;
        private bool _isIncreasing;

        private void Awake()
        {
            var localScale = transform.localScale;
            _up = new Vector3(localScale.x + _scalingDelta, localScale.y + _scalingDelta, localScale.z + _scalingDelta);
            _up = new Vector3(localScale.x, localScale.y, localScale.z);

            _oneWayTime = Vector3.Distance(_up, _down) / _speed;
        }

        private void Update()
        {
            _currentTime += _isIncreasing ? Time.deltaTime : -Time.deltaTime;
            var progress = Mathf.PingPong(_currentTime, _oneWayTime) / _oneWayTime;
            transform.localScale = Vector3.Lerp(_up, _down, progress);
        }
    }
}