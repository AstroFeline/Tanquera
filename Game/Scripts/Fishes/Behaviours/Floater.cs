using Godot;
using System;

public partial class Floater : Node3D
{

	[Export]
	RigidBody3D Body;

	[Export]
	float HappyHigh=7;
	float HappyHighMargin=0.5F;

	[Export]
	float HappySpeed=0.5F;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		if(Input.IsActionPressed("Up")) {
			GD.Print("Up");
		}
		if(Input.IsActionPressed("Down")) {
			GD.Print("Down");
		}
	}
	public override void _PhysicsProcess(double delta)
	{
		float currentHigh=Body.GlobalPosition.Y;
		if(currentHigh>HappyHigh-HappyHighMargin && currentHigh<HappyHigh+HappyHighMargin){
			Body.LinearVelocity= new Vector3(
				Body.LinearVelocity.X,0,0
			);
			GD.Print("Soyfelissss");
		}
		if(currentHigh<HappyHigh-HappyHighMargin) {
			Body.LinearVelocity= new Vector3(
				Body.LinearVelocity.X,HappySpeed,0
			);
			GD.Print("AMUUUUNT");
		}

		if(currentHigh>HappyHigh+HappyHighMargin) {
			Body.LinearVelocity= new Vector3(
				Body.LinearVelocity.X,-HappySpeed,0
			);
			GD.Print("ABAIXXXXXX");
		}

	}
}
// extends Node3D



// # Called every frame. 'delta' is the elapsed time since the previous frame.
// func _physics_process(delta: float) -> void:
// 	if(Input.is_action_pressed("Up")):
// 		print("Up")
// 	if(Input.is_action_pressed("Down")):
// 		print("Down")
