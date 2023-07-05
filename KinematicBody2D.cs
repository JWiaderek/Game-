using Godot;
using System;

public class KinematicBody2D : Godot.KinematicBody2D
{
    [Export] public int playerIndex = 0;
	[Export] public int runSpeed = 120;
    [Export] public int jumpSpeed = -400;
    [Export] public int gravity = 1300;

    Vector2 velocity = new Vector2();
    bool jumping = false;

    public void GetInput(){
        velocity.x = 0;
        float leftRight = Input.GetJoyAxis(playerIndex, 0);
        float jump = Input.GetJoyAxis(playerIndex, 1);
        bool dash = Input.IsActionJustPressed("dash");

        if (jump < -0.5 && IsOnFloor()){
            jumping = true;
            velocity.y = jumpSpeed;
        }

        if (leftRight != 0){
            velocity.x += runSpeed*leftRight;
        } 

        if(dash){
            
        }
    }

    public override void _PhysicsProcess(float delta){
        GetInput();
        velocity.y += gravity * delta;
        if (jumping && IsOnFloor()){
            jumping = false;
        }
        velocity = MoveAndSlide(velocity, Vector2.Up);
    }
}
