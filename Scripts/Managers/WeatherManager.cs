using UnityEngine;
using System.Collections;

public class WeatherManager : MonoBehaviour
{
	public ParticleSystem rain;
	public Light flash;

	float randomTimeToStartRain = 0;
	float rainDuration = 30;
	void Start()
	{
		SetRandomStartTime();
		flash.gameObject.SetActive(false);
		flash.intensity = 0;
	}

	void SetRandomStartTime()
	{
		randomTimeToStartRain = Time.time + Random.Range(30, 120) + rainDuration;

	}



	void Update()
	{
		if (Time.time > randomTimeToStartRain && !rainStormRunning)
		{
			SetRandomStartTime();
			StartCoroutine(RainStorm());
		}
	}


	bool rainStormRunning = false;
	IEnumerator RainStorm()
	{
		if (rainStormRunning)
			yield break;
		flash.gameObject.SetActive(true);
		rainStormRunning = true;
		rain.Play();

		float timer = 0;
		while (timer < rainDuration)
		{
			float randomDelay = Random.Range(0.25f, 8f);
			yield return new WaitForSeconds(randomDelay);
			StartCoroutine(Flash());
			timer += Time.deltaTime;
		}

		rain.Stop();
		rainStormRunning = false;
		flash.gameObject.SetActive(false);
	}

	IEnumerator Flash()
	{
		float timer = 0;
		float duration = 0.25f;
		float minIntesity = 0;
		float maxIntesity = 1.5f;
		float min = minIntesity;
		float max = maxIntesity;
		flash.enabled = true;
		while (timer < duration)
		{
			if (timer > duration / 2f)
			{
				min = maxIntesity;
				max = minIntesity;
			}
			flash.intensity = Mathf.Lerp(min, max, timer / (0.5f * duration));

			yield return new WaitForEndOfFrame();
			timer += Time.deltaTime;
		}
		flash.intensity = 0;
		flash.enabled = false;
	}
}
