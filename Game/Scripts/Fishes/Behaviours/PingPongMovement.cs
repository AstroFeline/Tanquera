using Godot;
using System;

public partial class PingPongMovement : Node3D
{
	[Export]
	RayCast3D laser;

	[Export]
	RigidBody3D fishBody;

	[Export]
	float SwimSpeed = 2;

	// El ready es para asignar propiedades y subscribirse a eventos ya que solo se tira una vez.
	public override void _Ready()
	{
		// SETUP del pescado
		fishBody.LinearVelocity = Vector3.Back * SwimSpeed;

		// a que eventos estoy escuchando
		fishBody.BodyEntered += (choque) => { MeChocao(choque); };

	}

	// el _Process tira a todo lo que da el procesador, sin miramientos, depende de la maquina del user
	public override void _Process(double delta)
	{

	}

	// el physicsProcess tiene unos ticks marcados por defecto
	public override void _PhysicsProcess(double delta)
	{
		// EL LASER HA TOCADO ALGO
		if(laser.IsColliding()){
			GD.Print("EL LASER HA TOCAT COSES");
			fishBody.LinearVelocity = -fishBody.LinearVelocity;

			// Perform the rotation (same as before)
			Vector3 rotation = fishBody.Rotation;
			rotation.Y += Mathf.DegToRad(180);
			fishBody.Rotation = rotation;
		}
	}

	void MeChocao(Node choque){
		GD.Print("ME CHOCAO CON: ", choque.Name);
	}
}
