using System;
using UnityEngine;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

public class DebugCollector
{
	private bool isReady = false;
	private AttributeUtil util = new AttributeUtil();
	private List<DebugMethodData> methods = new List<DebugMethodData> ();

	public List<DebugMethodData> Methods 
	{
		get{ return methods; }
	}

	public bool IsReady 
	{
		get { return isReady; }
	}

	private BindingFlags BindingFlags
	{
		get { return BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic; }
	}

	public void Load () 
	{
		if (IsReady)
			return;
		
		MonoBehaviour [] sceneActive = GameObject.FindObjectsOfType<MonoBehaviour>();

		foreach (MonoBehaviour mono in sceneActive)
		{
			MethodInfo [] objectMethods = mono.GetType ().GetMethods(BindingFlags);
			AddMethodsToRun (mono as object, objectMethods);
		}

		isReady = true;
	}

	private void AddMethodsToRun (object obj, MethodInfo[] objectMethods)
	{
		for (int i = 0; i < objectMethods.Length; i++) 
		{
			DebugMethodAttribute attribute = util.Find<DebugMethodAttribute>(objectMethods[i]);
			if(attribute != null)
				methods.Add (new DebugMethodData (attribute.label, obj, objectMethods [i]));
		}
	}

}