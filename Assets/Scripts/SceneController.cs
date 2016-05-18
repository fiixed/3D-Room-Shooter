using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab;
	private GameObject _enemy;

	public float speed = 3.0f;
	public const float baseSpeed = 3.0f;

	void Awake() {
		Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	void onDestroy() {
		Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	
	// Update is called once per frame
	void Update () {
		if (_enemy == null) {
			_enemy = Instantiate(enemyPrefab) as GameObject;
			_enemy.transform.position = new Vector3(0, 1, 0);

			float angle = Random.Range(0, 360);
			_enemy.transform.Rotate(0, angle, 0);
			speed = PlayerPrefs.GetFloat("speed");
			_enemy.transform.Translate(0, 0, speed * Time.deltaTime);
		}
	}

	private void OnSpeedChanged(float value) {
		speed = baseSpeed * value;
		PlayerPrefs.SetFloat("speed", speed);
	}

}
