using Player;
using UnityEngine;

namespace Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        public Health playerHealth;             // Reference to the player's heatlh.
        public GameObject donutEnemy;                // The enemy prefab to be spawned.
        public float donutEnemySpawnTime = 3f;            // How long between each spawn.
        private Vector2 _donutSpawnPosition;
        
        public GameObject suicideEnemy;                // The enemy prefab to be spawned.
        public float suicideEnemySpawnTime = 2f;            // How long between each spawn.
        private Vector2 _suicideSpawnPosition;
        
        public GameObject spawnEffect;

        public float minX;
        public float maxX;
        public float minY;
        public float maxY;
        
        void Start ()
        {
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            InvokeRepeating ("SpawnDonutEnemy", donutEnemySpawnTime, donutEnemySpawnTime);
            InvokeRepeating ("SpawnSuicideEnemy", suicideEnemySpawnTime, suicideEnemySpawnTime);
        }


        void SpawnDonutEnemy ()
        {
            // If the player has no health left...
            if(playerHealth.health <= 0 || GameObject.FindGameObjectsWithTag("DonutEnemy").Length >= 3)
            {
                // ... exit the function.
                return;
            }

            _donutSpawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

            // Create an instance of the enemy prefab at the randomly selected position and rotation.
            Instantiate(spawnEffect, _donutSpawnPosition, Quaternion.identity);
            Invoke("SpawnDonutObject", 1f);
        }
        
        void SpawnSuicideEnemy ()
        {
            // If the player has no health left...
            if(playerHealth.health <= 0 || GameObject.FindGameObjectsWithTag("SuicideEnemy").Length >= 5)
            {
                // ... exit the function.
                return;
            }

            _suicideSpawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

            // Create an instance of the enemy prefab at the randomly selected position and rotation.
            Instantiate(spawnEffect, _suicideSpawnPosition, Quaternion.identity);
            Invoke("SpawnSuicideObject", 1f);
        }
        
        void SpawnDonutObject()
        {
            Instantiate (donutEnemy, _donutSpawnPosition, Quaternion.identity);
        }

        void SpawnSuicideObject()
        {
            Instantiate (suicideEnemy, _suicideSpawnPosition, Quaternion.identity);
        }
    }
}
