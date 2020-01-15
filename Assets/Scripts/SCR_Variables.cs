using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default_Var", menuName = "Variables/Player Variables")]
public class SCR_Variables : ScriptableObject
{
	[Header("Movement")]
	public bool holdToRun = false;
	public float walkSpeed = 2;
	public float runSpeed = 5;
}
