using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default_PlayerVar", menuName = "Variables/Player Variables")]
public class SCR_PlayerVar : ScriptableObject
{
	[Header("Movement")]
	public bool holdToRun = true;
	public float walkSpeed = 4;
	public float runSpeed = 8;

	[Header("Smoothing")]
	public float smoothTurning = 0.1f;
	public float Acceleration = 0.1f;
}
