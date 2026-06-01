using Godot;
using System;

public partial class CameraController : Camera3D
{
	[Export] public CharacterBody3D Player;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		// set camera position to match X and Z only
		var CurrentPosition = GlobalPosition;
		CurrentPosition.X = Player.GlobalPosition.X;
		CurrentPosition.Z = Player.GlobalPosition.Z;
		
		GlobalPosition = CurrentPosition;
		
	}
}
