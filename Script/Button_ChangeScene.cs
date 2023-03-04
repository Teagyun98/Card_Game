using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_ChangeScene : MonoBehaviour
{
	public string nextSceneName;

    public void OnClickEvent()
	{
		SceneManager.LoadScene(nextSceneName);
	}
}
