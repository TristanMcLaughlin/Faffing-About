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
        private Animator CurrentAnimator;
        private bool CanAttack = true;

        void Start()
        {
            CurrentAnimator = GetComponent<Animator>();
            PlayerTransform = GetComponent<Transform>();
            SpawnWeapon();
        }

        public void Attack()
        {
            if (!EquippedWeapon) return;

            if (Input.GetButtonDown("Fire3"))
            {
                AutoAttack();
            }
        }

        public void AutoAttack()
        {
            if (CanAttack)
            {
                StartCoroutine(SetAttackCooldown());
                CurrentAnimator.SetTrigger("Attacking");
            }
        }

        public void SpawnWeapon()
        {
            if (EquippedWeapon == null) return;
            EquippedWeapon.SpawnWeapon(HandTransform, CurrentAnimator);
        }

        // Update is called once per frame
        void Update()
        {
            Attack();
        }

        private IEnumerator SetAttackCooldown()
        {
            CanAttack = false;
            yield return new WaitForSeconds(EquippedWeapon.GetAttackSpeed());
            CanAttack = true;
        }

        void Hit()
        {
            if (EquippedWeapon.HasProjectile())
            {
                EquippedWeapon.LaunchProjectile(HandTransform, PlayerTransform, gameObject.tag);
            }
        }

        public float GetRange()
        {
            return EquippedWeapon.GetRange();
        }
    }
}