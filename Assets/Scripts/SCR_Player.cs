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
	public SCR_Variables variables;
	InputControls controls;
	#endregion

	#region Local Variables
	float movementSpeed = 3;
	bool running;
	#endregion

	private void Awake()
	{
		//REF:
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
		Vector2 input = controls.Player.Movement.ReadValue<Vector2>();

		if (input != Vector2.zero)
		{
			transform.eulerAngles = Vector3.up * Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
		}

		movementSpeed = running ? variables.runSpeed : variables.walkSpeed;
		movementSpeed *= input.magnitude;

		transform.Translate(transform.forward * movementSpeed * Time.deltaTime, Space.World);
	}

	void Jump()
	{
		print("I am Jumping");
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
