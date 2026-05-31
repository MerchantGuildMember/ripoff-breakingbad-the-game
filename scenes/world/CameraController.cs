using Godot;
using System;

public partial class CameraController : Camera3D
{
	private CharacterBody3D _player;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// get player positions
		_player = GetNode<CharacterBody3D>("BasicPlayerBody");
		
		// set camera position to match X and Z only
		
		
		
		// leave y and rotation alone
		
	}
}
