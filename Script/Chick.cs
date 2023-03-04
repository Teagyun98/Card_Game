using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chick : MonoBehaviour
{
	public Sprite heart;
	public Sprite tri;
	public Sprite quad;
	public Sprite star;

	public int shapeNum;

	public bool clickCheck = true;

	public void SetShape()
	{
		switch(shapeNum) // ���� �Ŵ������� �Ҵ�� ��ȣ�� �°� ���� �Ҵ�
		{
			case 1:
				transform.GetChild(1).transform.GetComponent<SpriteRenderer>().sprite = heart;
				break;
			case 2:
				transform.GetChild(1).transform.GetComponent<SpriteRenderer>().sprite = tri;
				break;
			case 3:
				transform.GetChild(1).transform.GetComponent<SpriteRenderer>().sprite = quad;
				break;
			case 4:
				transform.GetChild(1).transform.GetComponent<SpriteRenderer>().sprite = star;
				break;
		}
	}

	private void OnMouseDown() // ī�� ���ý� Ȱ��ȭ
	{
		if (GameManager.instance.count < 2 && !clickCheck)
		{
			clickCheck = true;
			GameManager.instance.firstCollect = true;

			transform.GetChild(0).transform.gameObject.SetActive(true);
			transform.GetChild(1).transform.gameObject.SetActive(true);

			if (GameManager.instance.count == 0)
				GameManager.instance.collect_1 = shapeNum;
			else
				GameManager.instance.collect_2 = shapeNum;

			GameManager.instance.count++;

			if (GameManager.instance.count == 2)
				GameManager.instance.CheckShape();
			else if (GameManager.instance.count == 1)
				GameManager.instance.Hint();
		}
	}

	public void Return() // Ʋ������ �ٽ� ������
	{
		transform.GetChild(0).transform.gameObject.SetActive(false);
		transform.GetChild(1).transform.gameObject.SetActive(false);
		clickCheck = false;
	}
}
