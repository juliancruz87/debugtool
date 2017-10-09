using UnityEngine;

public class DebugUGUI : MonoBehaviour
{
	[SerializeField]
	private Vector2 buttonSize = new Vector2(200, 80);
	[SerializeField]
	private Vector2 maxGrid = new Vector2 (5, 4);
	[SerializeField]
	private Vector2 padding = new Vector2 (5, 4);

	private DebugCollector collector = new DebugCollector ();
	private int buttonsNumber = 50;

	private void OnEnable ()
	{
		collector.Load ();
		buttonsNumber = collector.Methods.Count;
	}

	private void OnGUI ()
	{
		if (!collector.IsReady)
			return;

		int index = 0;
		for (int i = 0; i < maxGrid.x; i++) 
		{
			if (index >= buttonsNumber)
				break;
			
			for (int j = 0; j < maxGrid.y; j++) 
			{
				if (index >= buttonsNumber)
					break;
				
				if (GUI.Button (CreateRect (i, j), collector.Methods [index].Name))
					collector.Methods [i].Run ();
		
				index++;
			}
		}
	}

	private Rect CreateRect (int column, int row)
	{
		float columnPosition = column * (buttonSize.x + padding.x);
		float rowPosition = row * (buttonSize.y + padding.y);
		return new Rect (padding.x + columnPosition, padding.y + rowPosition, buttonSize.x, buttonSize.y);
	}
}