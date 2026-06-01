using Godot;
using System;

public partial class CameraController : Camera3D
{
	private CharacterBody3D _player;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_player = GetNode<CharacterBody3D>("/root/Main_world/main_player_character/BasicPlayerBody");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		// set camera position to match X and Z only
		var CurrentPosition = GlobalPosition;
		CurrentPosition.X = _player.GlobalPosition.X;
		CurrentPosition.Z = _player.GlobalPosition.Z;
		
		GlobalPosition = CurrentPosition;
		
	}
}
