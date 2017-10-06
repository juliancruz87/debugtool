using System;
using System.Reflection;

public class DebugMethodData
{
	private string name;
	//private MethodInfo method;
	private Action action;

	public string Name 
	{
		get { return name; }
	}

	public Action Method 
	{
		get { return action; }
	}

	public DebugMethodData (string name, MethodInfo method)
	{
		this.name = name;
		//this.method = method;
		action = () => { UnityEngine.Debug.Log (method.Name); };
	}
}