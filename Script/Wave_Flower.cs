using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Flower : MonoBehaviour
{
	private void Start()
	{
		Wave();
	}

	void Wave()
	{
		StartCoroutine(WWave());
	}

	IEnumerator WWave() // ²É Èçµé¸²
	{
		yield return new WaitForSeconds(1);
		transform.position = new Vector2(transform.position.x-0.02f, transform.position.y);
		yield return new WaitForSeconds(1);
		transform.position = new Vector2(transform.position.x + 0.02f, transform.position.y);
		yield return new WaitForSeconds(1);
		transform.position = new Vector2(transform.position.x + 0.02f, transform.position.y);
		yield return new WaitForSeconds(1);
		transform.position = new Vector2(transform.position.x - 0.02f, transform.position.y);
		Wave();
	}
}
