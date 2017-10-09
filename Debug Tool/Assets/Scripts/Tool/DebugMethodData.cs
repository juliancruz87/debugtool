using System;
using System.Reflection;

public class DebugMethodData
{
	private string name;
	private Action run;
	object instance;
	Type type;
	MethodInfo method;

	public Action Run 
	{
		get 
		{
			run = () => { method.Invoke (instance, null); };
			return run; 
		}
	}

	public string Name 
	{
		get { return name; }
	}
		
	public DebugMethodData (string name, object instance, MethodInfo method)
	{
		this.name = name;
		this.type = type;
		this.method = method;
		this.instance = instance;
	}
}