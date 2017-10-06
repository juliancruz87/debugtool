using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour 
{
	[SerializeField]
	private int number;

	[DebugMethod("Load Asset Bundles")]
	private void Load ()
	{
		Debug.Log (number);
	}

	[DebugMethod("Unload Asset Bundles")]
	private void Unload ()
	{
		Debug.Log (number);
	}
}