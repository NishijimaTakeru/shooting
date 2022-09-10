using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


	[SerializeField]
	private Bullet prefab_ = null;

	void Awake()
	{
		// リフレッシュレートに依存しない様に固定する
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
	}

	// Update is called once per frame
	void Update()
	{
		var pos = transform.position;
		if (Input.GetKey(KeyCode.RightArrow))
		{
			pos.x += 0.5f;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			pos.x -= 0.5f;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			pos.z += 0.5f;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			pos.z -= 0.5f;
		}
		transform.position = pos;


		if (Input.GetKeyDown(KeyCode.Z))
		{
			var bullet = Instantiate(prefab_);
			bullet?.emit(transform.position);
		}
	}
}

