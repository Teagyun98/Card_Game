using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSoundManager : MonoBehaviour
{
	public AudioSource playgame;
	private void Start()
	{
		StartCoroutine(startPlay());
	}

	IEnumerator startPlay()
	{
		yield return new WaitForSeconds(2f);
		playgame.Play();
	}
}
