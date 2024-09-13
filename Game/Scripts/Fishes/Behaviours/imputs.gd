extends Node3D



# Called every frame. 'delta' is the elapsed time since the previous frame.
func _physics_process(delta: float) -> void:
	if(Input.is_action_pressed("Up")):
		print("Up")
	if(Input.is_action_pressed("Down")):
		print("Down")
