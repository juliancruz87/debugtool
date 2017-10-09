using System;
using System.Reflection;

public class AttributeUtil
{
	public T Find <T> (MethodInfo method) where T : Attribute
	{
		return Attribute.GetCustomAttribute (method, typeof(T)) as T;
	}
}