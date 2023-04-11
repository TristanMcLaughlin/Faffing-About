using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace RPG.Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float Speed;
        [SerializeField] float TimeToDestroy;
        [SerializeField] bool HasPunchThrough;

        Vector3 StartPosition;
        float Range = 0f;
        float Damage = 0f;
        string Friendly = null;

        public void SetDamage(float damage)
        {
            Damage = damage;
        }

        public void SetFriendly(string tag)
        {
            Friendly = tag;
        }

        public void SetRange(float range)
        {
            Range = range;
        }

        private bool ShouldDespawn()
        {
            return Vector3.Distance(gameObject.transform.position, StartPosition) > Range;
        }

        private void DamageEnemiesInRange()
        {
            List<Target> closeTargets = Target.GetClosest(transform.position, 3f);
            foreach (Target target in closeTargets)
            {
                if (target.gameObject.tag != Friendly)
                {
                    target.Damage(Damage);

                    if (!HasPunchThrough)
                    {
                        Destroy(gameObject);
                        break;
                    }
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (ShouldDespawn()) {
                Destroy(gameObject);
            }

            // Refactor this, not all projectiles will act the same
            // For example some might not move forward but will instead be launched at a specific spot
            // Some might grow
            // Some might take on bullet 
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            transform.localScale += new Vector3(0.04f, 0f, 0f);

            DamageEnemiesInRange();
        }

        private void Start()
        {
            StartPosition = transform.position;
        }
    }
}