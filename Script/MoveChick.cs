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
        transform.position = Vector2.Lerp(transform.position, new Vector2(x, transform.position.y), Time.deltaTime * 1f); // ���� ���۽� ������ ��ġ�� �̵�

		if (Goal == true)
			transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, transform.position.y+1), Time.deltaTime * 1f); // ¦�� ���� �� Ȱ��ȭ �Ǿ� ���� ���ư�
    }

	IEnumerator Open() // ���� ���۽� ��� ī�带 ������ ������ �˷���
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

	public void Hint() // ó�� �ѹ� �ƹ��͵� �������� �ʾ��� �� ��Ʈ
	{
		StartCoroutine(HintMove());
	}

	IEnumerator HintMove() //���Ʒ��� ������ ��Ʈ ǥ��
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
