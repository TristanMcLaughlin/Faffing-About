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
        float Damage = 0;

        void Start()
        {
            Destroy(gameObject, TimeToDestroy);
        }


        public void SetDamage(float damage)
        {
            Damage = damage;
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            transform.localScale += new Vector3(0.04f, 0f, 0f);

            List<Target> closeTargets = Target.GetClosest(transform.position, 3f);
            foreach (Target target in closeTargets)
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
}