using UnityEngine;

namespace Player
{
    public class ScoreManager : MonoBehaviour
    {
        public int score;
        public int multiplayer;
        
        // Start is called before the first frame update
        void Start()
        {
            score = 0;
            multiplayer = 1;
        }

        // Update is called once per frame
        void Update()
        {
            if (score > 5)
            {
                multiplayer = 2;
                //set different sprite
            } else if (score > 15)
            {
                multiplayer = 3;
            } else if (score > 30)
            {
                multiplayer = 4;
            }
            
            Debug.Log(score);
        }
    }
}
