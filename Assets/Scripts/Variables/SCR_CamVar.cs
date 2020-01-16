using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default_CamVar", menuName = "Variables/Camera Variables")]
public class SCR_CamVar : ScriptableObject
{
	[Header("Controls:")]
	public float sensitivity = 1;
	public float distanceFromTarget = 3;
	public Vector2 pitchMinMax = new Vector2(-40, 85);

	[Header("Smoothing")]
	public float smoothTurning = 0.1f;
}
