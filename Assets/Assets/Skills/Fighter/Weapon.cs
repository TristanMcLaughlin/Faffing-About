using UnityEngine;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/New Weapon", order = 0)]
    public class Weapon: ScriptableObject
    {
        [SerializeField] GameObject WeaponPrefab = null;
        [SerializeField] AnimatorOverrideController WeaponOverride = null;
        [SerializeField] Projectile CurrentProjectile = null;
        [SerializeField] float AttackSpeed;
        [SerializeField] float Range;
        [SerializeField] float Damage;

        public void SpawnWeapon(Transform HandTransform, Animator animator)
        {
            if (WeaponPrefab != null) {
                Instantiate(WeaponPrefab, HandTransform);
            }

            if (WeaponOverride != null)
            {
                animator.runtimeAnimatorController = WeaponOverride;
            }
        }

        public float GetDamage()
        {
            return Damage;
        }

        public float GetRange()
        {
            return Range;
        }
        public float GetAttackSpeed()
        {
            return AttackSpeed;
        }

        public bool HasProjectile()
        {
            return CurrentProjectile != null;
        }

        public void LaunchProjectile(Transform HandTransform, Transform PlayerTransform, string tag)
        {
            Projectile projectileInstance = Instantiate(CurrentProjectile, HandTransform.position, PlayerTransform.rotation);
            projectileInstance.SetRange(Range);
            projectileInstance.SetDamage(Damage);
            projectileInstance.SetFriendly(tag);
        }
    }
}