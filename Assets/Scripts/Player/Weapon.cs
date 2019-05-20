using UnityEngine;

namespace Player
{
    public class Weapon : MonoBehaviour
    {
        public float offset;

        public GameObject projectile;
        public Transform shotPoint;
    
        private float _timeBtwShots;
        public float startTimeBtwShots;

        private PlayerController _playerController;
        private Camera _camera;

        void Start()
        {
            _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            _camera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            if (_camera != null)
            {
                Vector3 difference = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position; // Gets position of cursor and subtracts object position thus gets difference
                float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; // Transfers angle to radians and then transfers it to degrees
                transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset); // Applies rotation to the object
            }

            if (_timeBtwShots <= 0)
            {
                if (Input.GetMouseButtonDown(0) && !_playerController.isCrouching)
                {
                    Instantiate(projectile, shotPoint.position, transform.rotation);
                    _timeBtwShots = startTimeBtwShots;
                }
            }
            else
            {
                _timeBtwShots -= Time.deltaTime;
            }
        }
    }
}