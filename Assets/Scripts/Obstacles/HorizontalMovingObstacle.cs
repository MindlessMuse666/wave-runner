using UnityEngine;

namespace Obstacles
{
    public class HorizontalMovingObstacle : MonoBehaviour
    {
        [SerializeField] private float _duration = 2f;

        private Vector3 _start;
        private Vector3 _end;
        private float _currentTime;

        private void Start()
        {
            var position = gameObject.transform.position;

            _start = new Vector3(position.x - 3, position.y, position.z);
            _end = new Vector3(position.x + 3, position.y, position.z);
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            var progress = (Mathf.Sin(_currentTime) + 1) / _duration;
            var newPosition = Vector3.Lerp(_start, _end, progress);
            transform.position = newPosition;
        }
    }
}