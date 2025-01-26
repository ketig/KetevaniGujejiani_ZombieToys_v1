using UnityEngine;
using System.Collections;

public class SetaActive : MonoBehaviour
{
	public void Deactivate()
	{
		gameObject.SetActive(false);
	}

	public void SetTimeScaleOff()
	{
		Time.timeScale = 0f;
	}
}
