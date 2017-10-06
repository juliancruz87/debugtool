using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class TextureFormatValidator : MonoBehaviour 
{
	private List<TextureFormat> availableFormats = new List<TextureFormat> ();
	private string log = "The number of texture formats available for this graphics card on {0} are {1}";
	private string availableFormatsList;

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
		Debug.Log (availableFormatsList);
	}

	private void OnGUI ()
	{
		if (GUI.Button (new Rect (10, 10, 250, 90), "Get All Available Texture Formats"))
			GetAllAvailableFormatsByPlatform ();

		if (availableFormats.Count > 0)
			GUI.Label (new Rect (10, 120, 250, 90), string.Format (log, Application.platform, availableFormats.Count) );
	}
}