using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class Health : MonoBehaviour
    {
        public int health;
        public int maxHearts;

        public Image[] hearts;
        public Sprite fullHeart;
        public Sprite emptyHeart;

        // Update is called once per frame
        void Update()
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }

            if (health > maxHearts)
            {
                health = maxHearts;
            }

            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < health)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }

                if (i < maxHearts)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }
            }
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }
    }
}