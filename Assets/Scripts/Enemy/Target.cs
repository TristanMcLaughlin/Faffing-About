using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace RPG.Combat
{
    public class Target : MonoBehaviour
    {
        [SerializeField] Material MaterialOnHit;
        [SerializeField] SkinnedMeshRenderer CurrentMeshRenderer;

        private static List<Target> targets;
        private bool CurrentlyInvincible = false;
        private Material[] OriginalMaterial = null;

        public static List<Target> GetClosest(Vector3 Position, float MaxRange) { 
            List<Target> closeTargets = new List<Target>();

            foreach (Target target in targets)
            {
                if(Vector3.Distance(Position, target.transform.position) <= MaxRange)
                {
                    closeTargets.Add(target);
                } else
                {
                    closeTargets.Remove(target);
                }
            }

            return closeTargets;
        }

        private void Start()
        {
            OriginalMaterial = CurrentMeshRenderer.materials;
        }

        private void Awake()
        {
            if(targets == null)
            {
                targets = new List<Target>();
            }

            targets.Add(this);
        }

        public void Damage(float damage)
        {
            if (!CurrentlyInvincible)
            {
                Health TargetHealth = GetComponent<Health>();

                if (TargetHealth)
                {
                    TargetHealth.Damage(damage);
                    if(TargetHealth.CheckIfDead())
                    {
                        targets.Remove(this);
                    }
                }

                StartCoroutine(FlashRedOnHit());
                StartCoroutine(BecomeInvincible());
            }
        }

        private IEnumerator BecomeInvincible()
        {
            CurrentlyInvincible = true;
            yield return new WaitForSeconds(1f);
            CurrentlyInvincible = false;
        }

        private IEnumerator FlashRedOnHit()
        {
            Material[] newMaterials = { MaterialOnHit };
            CurrentMeshRenderer.materials = newMaterials;
            yield return new WaitForSeconds(0.2f);
            CurrentMeshRenderer.materials = OriginalMaterial;
        }
    }
}