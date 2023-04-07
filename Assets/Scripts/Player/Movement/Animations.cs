using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Movement PlayerMovement;

    // Update is called once per frame
    void Update()
    {
        WalkAnimations();
    }

    private void WalkAnimations()
    {
        float MaxSpeed = PlayerMovement.Speed * 3f;
        float PlayerSpeed = Mathf.Clamp(PlayerMovement.PlayerBody.velocity.sqrMagnitude, 0f, MaxSpeed);
        GetComponent<Animator>().SetFloat("IdleToRun", PlayerSpeed / MaxSpeed);
    }
}
