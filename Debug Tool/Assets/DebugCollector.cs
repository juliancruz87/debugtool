using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class DebugCollector
{
	private bool isReady = false;
	private  List<DebugMethodData> methods = new List<DebugMethodData> ();

	public List<DebugMethodData> Methods 
	{
		get{ return methods; }
	}

	public bool IsReady 
	{
		get { return isReady; }
	}

	public void Load () 
	{
		if (IsReady)
			return;
		
		MonoBehaviour [] sceneActive = GameObject.FindObjectsOfType<MonoBehaviour>();

		foreach (MonoBehaviour mono in sceneActive)
		{
			Type monoType = mono.GetType();
			MethodInfo [] objectMethods = monoType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

			for (int i = 0; i < objectMethods.Length; i++)
			{
				DebugMethodAttribute attribute = Attribute.GetCustomAttribute(objectMethods[i], typeof(DebugMethodAttribute)) as DebugMethodAttribute;
				if (attribute != null)
					methods.Add (new DebugMethodData (attribute.label, objectMethods [i]));
			}
		}

		isReady = true;
	}
}