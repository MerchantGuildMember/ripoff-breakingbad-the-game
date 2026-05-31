extends CharacterBody3D

const SPEED = 5.0

func _physics_process(delta):
	var input_dir = Vector2.ZERO
	
	var side_axis = Input.get_axis("move_left", "move_right")
	var front_axis = Input.get_axis("move_front", "move_back")
	# you'll read Input.get_axis() here for WASD
	
	var move_dir = Vector3.ZERO
	# you'll transform input_dir into world-space here
	# hint: think about what the camera's basis vectors 
	# give you on the XZ plane
	
	velocity.x = move_dir.x * SPEED
	velocity.z = move_dir.z * SPEED
	move_and_slide()
