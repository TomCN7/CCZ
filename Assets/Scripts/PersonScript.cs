using UnityEngine;
using System.Collections;

public class PersonScript : MonoBehaviour {
	public float m_speed = 1;
	public GameObject m_Heros;

	protected Transform m_transform;
	private float m_rocketRate = 0;

	private GameObject m_NewHerosList;

	// Use this for initialization
	void Start () {
		m_transform = this.transform;
//		m_NewHeros = Object.Instantiate (m_Heros) as GameObject;
	}

	// Update is called once per frame
	void Update () {
		float movev = 0, moveh = 0;
		if (Input.GetKey (KeyCode.UpArrow)) {
			movev -= m_speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			movev += m_speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			moveh += m_speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			moveh -= m_speed * Time.deltaTime;
		}
		m_transform.Translate (new Vector2 (moveh, movev));

		m_rocketRate -= Time.deltaTime;
		if (m_rocketRate <= 0) {
			m_rocketRate = 0.1f;
			if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) {
				//m_NewHeros1 = Object.Instantiate (m_Heros) as GameObject;
				Instantiate (m_Heros, new Vector3(m_transform.position.x, m_transform.position.y, 0), m_transform.rotation);
			}
		}
	}

	void OnGUI()
	{
		GUI.skin.label.fontSize = 48;
		GUI.skin.label.alignment = TextAnchor.LowerCenter;
		GUI.Label (new Rect (0, 30, Screen.width, 100), "太空大战");
	}
}
