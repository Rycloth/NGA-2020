using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Player : MonoBehaviour
{
	#region Enable & Disable
	private void OnEnable()
	{
		controls.Enable();
	}
	private void OnDisable()
	{
		controls.Disable();
	}
	#endregion
	#region References
	[Header("Variables:")]
	public SCR_PlayerVar variables;
	InputControls controls;
	#endregion

	#region Local Variables
	bool running;
	float currentSpeed;
	float rotationVelocity, speedVelocity;
	Transform camT;
	#endregion

	private void Awake()
	{
		//REF:
		camT = Camera.main.transform;
		controls = new InputControls();

		//Functions:
		InputActions();
	}

	private void Update()
	{
		//Functions
		Move();
	}

	void Move()
	{
		//Get Player Input:
		Vector2 input = controls.Player.Movement.ReadValue<Vector2>();

		//If Input then set Target Rotation & Smoothly Rotate in Degrees:
		if (input != Vector2.zero)
		{
			float targetRotation = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + camT.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref rotationVelocity, variables.smoothTurning);
		}

		//Check if Running & Set Speed Accordingly:
		float targetSpeed = (running ? variables.runSpeed : variables.walkSpeed) * input.magnitude;
		currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedVelocity, variables.Acceleration);

		//Move the Player:
		transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
	}

	void Jump()
	{
		
	}

	void InputActions()
	{
		//Set Jump:
		controls.Player.Jump.performed += ctx => Jump();

		//Check and Set Running:
		if (variables.holdToRun)
			controls.Player.HoldtoRun.performed += ctx => running = !running;
		else
			controls.Player.PresstoRun.performed += ctx => running = !running;
	}
}
