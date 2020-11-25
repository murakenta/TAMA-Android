using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
 
public class GameSystem : MonoBehaviour {
 
	//　スタートボタンを押したら実行する
	public void StartGame() {
		SceneManager.LoadScene ("TrackingApp");
	}
	
	//　ゲーム終了ボタンを押したら実行する
	public void EndGame() {
		SceneManager.LoadScene ("Title");
	}


}