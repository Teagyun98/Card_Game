using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	public int count;
	public int collect_1;
	public int collect_2;

	public GameObject[] chick = new GameObject[8];

	public GameObject EndMenu;
	private int goal = 0;

	public ParticleSystem effect;

	public AudioSource heart;
	public AudioSource tri;
	public AudioSource quad;
	public AudioSource star;

	public bool firstCollect = false;

	IEnumerator corutine;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		ShuffleArray(chick);

		for (int i = 1; i < 5; i++) //모양 할당
		{
			chick[i-1].transform.GetChild(0).GetComponent<Chick>().shapeNum = i;
			chick[i-1].transform.GetChild(0).GetComponent<Chick>().SetShape();
			chick[i+3].transform.GetChild(0).GetComponent<Chick>().shapeNum = i;
			chick[i+3].transform.GetChild(0).GetComponent<Chick>().SetShape();
		}

		corutine = FiveSecHint();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) // 게임종료
			Application.Quit();
	}

	public void CheckShape() //선택한 카드가 같은 카드인지 확인
	{
		for (int i = 0; i < chick.Length; i++)
		{
			chick[i].transform.GetChild(0).GetComponent<Chick>().clickCheck = true;
		}

		if (collect_1 == collect_2)
		{
			switch(collect_1)
			{
				case 1:
					heart.Play();
					break;
				case 2:
					tri.Play();
					break;
				case 3:
					quad.Play();
					break;
				case 4:
					star.Play();
					break;
			}

			for (int i = 0; i < chick.Length; i++)
			{
				if (chick[i].transform.GetChild(0).GetComponent<Chick>().shapeNum == collect_1)
				{
					Instantiate(effect, chick[i].transform.position, Quaternion.identity);
					chick[i].GetComponent<MoveChick>().Goal = true;
				}
				chick[i].transform.GetChild(0).GetComponent<Chick>().clickCheck = false;
			}
			count = 0;
			goal++;
			if (goal == 4)
			{
				EndMenu.SetActive(true);
			}
			collect_1 = 0;
			collect_2 = 0;
		}
		else
		{
			StartCoroutine(CardCheckFalse());
		}
	}

	IEnumerator CardCheckFalse()
	{
		yield return new WaitForSeconds(0.5f);
		for (int i = 0; i < chick.Length; i++)
		{
			if (chick[i].transform.GetChild(0).GetComponent<Chick>().shapeNum == collect_1)
				chick[i].transform.GetChild(0).GetComponent<Chick>().Return();
			if (chick[i].transform.GetChild(0).GetComponent<Chick>().shapeNum == collect_2)
				chick[i].transform.GetChild(0).GetComponent<Chick>().Return();
			chick[i].transform.GetChild(0).GetComponent<Chick>().clickCheck = false;
		}
		collect_1 = 0;
		collect_2 = 0;
		count = 0;
	}

	private T[] ShuffleArray<T>(T[] array) // 셔플 로직
	{
		int random1, random2;
		T temp;

		for (int i = 0; i < array.Length; ++i)
		{
			random1 = Random.Range(0, array.Length);
			random2 = Random.Range(0, array.Length);

			temp = array[random1];
			array[random1] = array[random2];
			array[random2] = temp;
		}

		return array;
	}

	

	public void Hint() // 카드를 선택하고 5초 후 힌트
	{
		StopCoroutine(corutine);
		corutine = FiveSecHint();
		StartCoroutine(corutine);
	}

	IEnumerator FiveSecHint()
	{
		yield return new WaitForSeconds(5f);
		if (collect_1 != 0 && collect_2 == 0)
		{
			for (int i = 0; i < chick.Length; i++)
			{
				if (chick[i].transform.GetChild(0).GetComponent<Chick>().shapeNum == collect_1 && !chick[i].transform.GetChild(0).GetComponent<Chick>().clickCheck)
					chick[i].GetComponent<MoveChick>().Hint();
			}
		}
	}
}
