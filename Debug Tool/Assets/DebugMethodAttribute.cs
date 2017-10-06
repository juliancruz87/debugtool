using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[AttributeUsage(AttributeTargets.Method)]
public class DebugMethodAttribute : Attribute 
{
	public readonly string label;

	public DebugMethodAttribute (string label)
	{
		this.label = label;
	}
}
