using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingState : PlayerBaseState
{
    public override void EnterState(PlayerController player)
    {
        player.GetComponent<Animator>().SetBool("walking", true);
    }

    public override void OnCollisionEnter(PlayerController player, Collision2D collision)
    {
    }

    public override void Update(PlayerController player)
    {
        player.horzMove = Input.GetAxisRaw("Horizontal");
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.horzMove * player.speed, 0);
        if(player.horzMove < 0)
            player.GetComponent<SpriteRenderer>().flipX = true;
        if(player.horzMove > 0)
            player.GetComponent<SpriteRenderer>().flipX = false;
        if (player.horzMove == 0)
            player.TransitionToState(player.IdleState);        
    }
}
