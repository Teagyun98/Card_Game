using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChick : MonoBehaviour
{ 
    public float x;
	public bool Goal = false;

	private void Start()
	{
		StartCoroutine(Open());
	}

	void Update()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(x, transform.position.y), Time.deltaTime * 1f); // 게임 시작시 지정된 위치로 이동

		if (Goal == true)
			transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, transform.position.y+1), Time.deltaTime * 1f); // 짝이 맞을 시 활성화 되어 위로 날아감
    }

	IEnumerator Open() // 게임 시작시 잠깐 카드를 뒤집어 정답을 알려줌
	{
		yield return new WaitForSeconds(2f);
		transform.GetChild(0).GetChild(0).transform.gameObject.SetActive(true);
		transform.GetChild(0).GetChild(1).transform.gameObject.SetActive(true);
		yield return new WaitForSeconds(3f);
		transform.GetChild(0).GetChild(0).transform.gameObject.SetActive(false);
		transform.GetChild(0).GetChild(1).transform.gameObject.SetActive(false);
		transform.GetChild(0).GetComponent<Chick>().clickCheck = false;
		FirstHint();
	}

	public void Hint() // 처음 한번 아무것도 선택하지 않았을 시 힌트
	{
		StartCoroutine(HintMove());
	}

	IEnumerator HintMove() //위아래로 움직여 힌트 표시
	{
		for (int i = 0; i < 2; i++)
		{
			transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y - 0.2f), 1);
			yield return new WaitForSeconds(0.5f);
			transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y + 0.2f), 1);
			yield return new WaitForSeconds(0.5f);
		}
	}

	void FirstHint()
	{
		StartCoroutine(FirstHitCor());
	}

	IEnumerator FirstHitCor()
	{
		yield return new WaitForSeconds(5f);
		if(transform.GetChild(0).GetComponent<Chick>().shapeNum==1&& !GameManager.instance.firstCollect)
			StartCoroutine(HintMove());
	}
}
