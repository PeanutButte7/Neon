using UnityEngine;

namespace Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        public Health playerHealth;             // Reference to the player's heatlh.
        public GameObject donutEnemy;                // The enemy prefab to be spawned.
        public float donutEnemySpawnTime = 3f;            // How long between each spawn.
        public GameObject spawnEffect;
        private Vector2 _donutSpawnPosition;

        public float minX;
        public float maxX;
        public float minY;
        public float maxY;
        
        void Start ()
        {
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            InvokeRepeating ("SpawnDonutEnemy", donutEnemySpawnTime, donutEnemySpawnTime);
        }


        void SpawnDonutEnemy ()
        {
            // If the player has no health left...
            if(playerHealth.health <= 0f || GameObject.FindGameObjectsWithTag("DonutEnemy").Length >= 3)
            {
                // ... exit the function.
                return;
            }

            _donutSpawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

            // Create an instance of the enemy prefab at the randomly selected position and rotation.
            Instantiate(spawnEffect, _donutSpawnPosition, Quaternion.identity);
            Invoke("SpawnDonutObject", 1f);
        }
        
        void SpawnDonutObject()
        {
            Instantiate (donutEnemy, _donutSpawnPosition, Quaternion.identity);
        }
    }
}
