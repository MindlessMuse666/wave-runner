using UnityEngine;

namespace Obstacles
{
    public class RotatingObstacle : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 45f;

        private void Update()
        {
            transform.Rotate(Vector3.forward, _rotationSpeed * Time.deltaTime);
        }
    }
}