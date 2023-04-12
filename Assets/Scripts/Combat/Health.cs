using System.Collections;
using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float MaxHealth;

        private float CurrentHealth;
        private Animator CurrentAnimator = null;

        // Use this for initialization
        void Start()
        {
            CurrentAnimator = GetComponent<Animator>();
            CurrentHealth = MaxHealth;
        }

        public bool CheckIfDead()
        {
            if(CurrentHealth <= 0)
            {
                if (CurrentAnimator != null)
                {
                    CurrentAnimator.SetTrigger("Death");
                }

                Destroy(gameObject, 20f);
                return true;
            }

            return false;
        }

        public bool IsDead()
        {
            return CurrentHealth <= 0;
        }

        public void Damage(float damage)
        {
            CurrentHealth -= damage;
        }
    }
}