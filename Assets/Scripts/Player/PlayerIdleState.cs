using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerController player)
    {
        player.GetComponent<Animator>().SetBool("walking", false);
    }

    public override void OnCollisionEnter(PlayerController player, Collision2D collision)
    {
    }

    public override void Update(PlayerController player)
    {
        player.horzMove = Input.GetAxisRaw("Horizontal");
        if (player.horzMove != 0)
        {
            player.TransitionToState(player.WalkingState);
        }
    }
}
