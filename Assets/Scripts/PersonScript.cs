using UnityEngine;
using System.Collections;

public class PersonScript : MonoBehaviour {
	public float m_speed = 1;
	public GameObject m_Heros;

	protected Transform m_transform;
	private float m_rocketRate = 0;

	private GameObject m_NewHerosList;

//	public Base m_Base;

	// Use this for initialization
	void Start () {
		m_transform = this.transform;
//		m_NewHeros = Object.Instantiate (m_Heros) as GameObject;

		/*
		m_Base = new Base ();

		int nCost = 5;
		int nRow = 5, nCol = 5;
		int [,] nMapCost = new int[5,5]{
			{1, 2, 3, 2, 1},
			{1, 1, 1, 1, 1},
			{2, 2, 3, 1, 1},
			{3, 1, 2, 1, 1},
			{1, 1, 1, 1, 1}
		};
		int [,]nCostIntermediate = new int[nRow,nCol];
		bool [,] bReachable = new bool[nRow,nCol];
		int [,] nFromX = new int[nRow,nCol];
		int [,] nFromY = new int[nRow,nCol];

		m_Base.FindPath(nCost, 0, 0, nRow, nCol, nMapCost, bReachable, nFromX, nFromY, nCostIntermediate);

		for (int i = 0; i < nRow; ++i)
		{
			string s = "";
			for (int j = 0; j < nCol; ++j)
				s += (bReachable[i,j] ? 'Y' : 'N') + "[" + nCostIntermediate[i,j] + "] " + ", (" + nFromX[i,j] + "," + nFromY[i,j] + ")\t";

			Debug.Log (s);
		}
		*/
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
