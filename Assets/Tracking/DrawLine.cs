using UnityEngine;
using UnityEngine.UI;

public class DrawLine : MonoBehaviour {

    /*
     * オブジェクトの軌跡を描画する
     */

    LineRenderer line; // LineRendererコンポーネントを受ける変数
    int count; // 線の頂点の数

    void Start () 
    {
        line = GetComponent<LineRenderer>(); // LineRendererコンポーネントを取得
        Time.fixedDeltaTime = InputFieldManager.sampling_rate;
	}

    void FixedUpdate() // updateでもいいけど，fixedのほうが今回都合がいい
    {
        count += 1; // 頂点数を１つ増やす
        line.positionCount = count; // 頂点数の更新
        line.SetPosition(count - 1, new Vector3(transform.position.x,-1.0f, transform.position.z)); // オブジェクトの位置情報をセット
    }
}