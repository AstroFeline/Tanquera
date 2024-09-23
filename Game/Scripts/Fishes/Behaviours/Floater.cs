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
				0,0,Body.LinearVelocity.Z
			);
		}
		if(currentHigh<HappyHigh-HappyHighMargin) {
			Body.LinearVelocity= new Vector3(
				0,HappySpeed,Body.LinearVelocity.Z
			);
		}

		if(currentHigh>HappyHigh+HappyHighMargin) {
			Body.LinearVelocity= new Vector3(
				0,-HappySpeed,Body.LinearVelocity.Z
			);
		}

		//MIRA HACIA DONDE VAS, HOMBRE
		Vector3 direction = Body.LinearVelocity.Normalized();

		Body.LookAt(Body.GlobalTransform.Origin + direction, Vector3.Up); // LookAt es un 'pon esto mirando palla' de godot, primer parametro es hacia donde, segundo parametro es en que eje* (*Vector3.Up)
		Body.RotateObjectLocal(Vector3.Up, System.MathF.PI); // Esto es una rareza de godot, que decidieron que hacia delante es con la flecha de Z mirando hacia atras

	}
}