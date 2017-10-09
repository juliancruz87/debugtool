using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class TextureFormatValidator : MonoBehaviour 
{
	[SerializeField]
	private int value = 10;

	private List<TextureFormat> availableFormats = new List<TextureFormat> ();
	private string availableFormatsList;

	[DebugMethod("Get all textures available for Platform")]
	private void GetAllAvailableFormatsByPlatform ()
	{
		availableFormats.Clear ();
		availableFormatsList = string.Empty;
		foreach (TextureFormat value in Enum.GetValues(typeof(TextureFormat)).Cast<TextureFormat>()) 
		{
			if (value.ToString () == "PVRTC_4BPP_RGB") // obsolete format, use PVRTC_RGB4 instead
				continue;
			
			if (SystemInfo.SupportsTextureFormat (value))
				availableFormats.Add (value);
		}

		availableFormats.ForEach (t => availableFormatsList+= t.ToString () +"\n" );
		Debug.Log (availableFormats.Count + " - " + value);
	}

	private void NewMethod ()
	{
		
	}

	private static void NewMethod2 ()
	{

	}
}