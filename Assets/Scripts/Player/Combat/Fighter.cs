using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] Transform HandTransform = null;
        [SerializeField] Weapon EquippedWeapon = null;
        private Transform PlayerTransform;

        void Start()
        {
            PlayerTransform = GetComponent<Transform>();
            SpawnWeapon();
        }

        public void Attack()
        {
            if (Input.GetButtonDown("Fire3"))
            {
                if (EquippedWeapon && EquippedWeapon.HasProjectile())
                {
                    EquippedWeapon.LaunchProjectile(HandTransform, PlayerTransform);
                }
                Debug.Log("Attacking");
            }
        }

        public void SpawnWeapon()
        {
            if (EquippedWeapon == null) return;
            Animator CurrentAnimator = GetComponent<Animator>();
            EquippedWeapon.SpawnWeapon(HandTransform, CurrentAnimator);
        }

        // Update is called once per frame
        void Update()
        {
            Attack();
        }
    }
}