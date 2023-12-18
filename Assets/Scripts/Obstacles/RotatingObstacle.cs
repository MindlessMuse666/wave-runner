using UnityEngine;

namespace Obstacles
{
    public class RotatingObstacle : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 50;

        private void Update()
        {
            transform.Rotate( _rotationSpeed * Time.deltaTime * Vector3.forward, Space.World);
        }
    }
}