using UnityEngine;
using System.Collections;

public class FileLoader {
	public class SpawnData
	{
		public int wave = 1;
		public string enemyname = "";
		public int level = 1;
		public float wait = 1.0f;
	}

	ArrayList m_enemylist;

/*
	void LoadXML(){
		m_enemylist = new ArrayList();
		XMLParser xmlparse = new XMLParser();
		XMLNode node = xmlparse.Parse(xmldata.text);
		XMLNodeList list = node .GetNodeList( "ROOT>O>table");
		for (int i = 0; i < list.Count; i++)
		{
			string wave = node.GetValue("ROOT>O>table>" + i + ">@wave");
			string enemyname = node.GetValue("ROOT>O>table>" + i + ">@enemyname");
			string level = node.GetValue("ROOT>O>table>" + i + ">@level");
			string wait = node.GetValue( "ROOT>O>table>" + i + ">@wait") ;
			SpawnData data = new SpawnData () ;
			data.wave = int.Parse(wave);
			data.enemyname = enemyname;
			data.level = int.Parse(level);
			data.wait = float.Parse(wait); 
			m_enemylìst.Add(data);
		}
	}
*/
}
