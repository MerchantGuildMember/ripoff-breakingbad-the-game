using Godot;
using System;


public partial class BasicPlayerBody : CharacterBody3D
{
	[Export] public Camera3D Camera;
	
	public const float Speed = 5.0f;
	public const float JumpVelocity = 4.5f;
	
	private const int RayLength = 200;

	// runs every frame
	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions. -- Already done
		Vector2 inputDir = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		Vector3 camForward = -Camera.Transform.Basis.Z;
		camForward.Y = 0;
		camForward = camForward.Normalized();

		Vector3 camRight = Camera.Transform.Basis.X;
		camRight.Y = 0;
		camRight = camRight.Normalized();

		Vector3 direction = (camRight * inputDir.X + camForward * -inputDir.Y).Normalized();
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
		
		// Handle rotation
		if (Input.IsActionPressed("aim"))
		{
			HandleRotation();
		}
	}

	public override void _Ready() // Basically like a constructor for nodes when they first enter the scene before anything else happens
	{
		
	}

	private void HandleRotation()
	{
		var from = Camera.ProjectRayOrigin(GetViewport().GetMousePosition());
		var normal = Camera.ProjectRayNormal(GetViewport().GetMousePosition());
		
		var t = -from.Y /  normal.Y;
		Vector3 groundPoint = from + normal * t;
		
		LookAt(groundPoint, Vector3.Up);
		
		// Vector3 worldPosMousePos = new Vector3(mousePos.X, mousePos.Y, 0);
		// double angleRadians = Math.Atan2(worldPosMousePos.X, worldPosMousePos.Y);
		// 	
		// BasicPlayerBody
			
	}
}
