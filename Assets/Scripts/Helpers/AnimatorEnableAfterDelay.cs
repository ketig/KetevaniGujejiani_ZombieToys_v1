using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class AnimatorEnableAfterDelay : MonoBehaviour
{
	public float delay = 0.25f;
	[SerializeField]
	Animator animator;
	
	void Reset()
	{
		animator = GetComponent<Animator>();
	}

	void Start ()
	{
		Invoke("EnableAnimator", delay);
	}

	void EnableAnimator()
	{
		animator.enabled = true;
	}
	
}
