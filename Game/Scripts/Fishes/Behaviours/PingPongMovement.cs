using Godot;
using System;

public partial class PingPongMovement : Node3D
{

	[Export]
	RigidBody3D fishBody;

	[Export]
	float SwimSpeed = 2;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// SETUP del pescado
		fishBody.LinearVelocity = Vector3.Back * SwimSpeed;

		// a que eventos estoy escuchando
		fishBody.BodyEntered += (choque) => { MeChocao(choque); };

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	void MeChocao(Node choque){
		//GD.Print("ME CHOCAO CON: ", choque.Name); PARAMONTSE GD.Print para pintar cosicas

		fishBody.LinearVelocity = -fishBody.LinearVelocity;
		fishBody.GlobalRotation = fishBody.GlobalRotation + new Vector3(0,180,0);



	}
}
