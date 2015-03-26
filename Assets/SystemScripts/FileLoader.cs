using UnityEngine;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class TabFileLoader {
	public string this[string id, string col]
	{
		get
		{
			return GetValue(id + col);
		}
	}

	public bool LoadTabFile(string path)
	{
		string inputline;

		bool bFirstLine = true, bRetCode = false;
		StreamReader sr = new StreamReader (path, Encoding.Default);

		m_Keywords = new Dictionary<int, string> ();
		m_DataDictionary = new Dictionary<string, string> ();

		while ((inputline = sr.ReadLine()) != null)
		{
			if (bFirstLine)
			{
				bFirstLine = false;

				bRetCode = ProcessKeywords(inputline);
				if (!bRetCode) return false;
			}

			bRetCode = ProcessContent(inputline);
			if (!bRetCode) return false;
		}

		return true;
	}

	private bool ProcessKeywords(string line)
	{
		char[] delim = {' ', '\t'};
		string[] keys = line.Split (delim);

		m_KeywordNum = 0;
		foreach (string s in keys)
			m_Keywords[m_KeywordNum++] = s;

		return m_KeywordNum > 0 ? true : false;
	}

	private bool ProcessContent(string line)
	{
		char[] delim = {' ', '\t'};
		string[] data = line.Split (delim);

		int nCounter = 0;
		string prefix = "";

		foreach (string s in data)
		{
			if (nCounter == 0)
			{
				prefix = s;
				++nCounter;
				continue;
			}

			if (!m_Keywords.ContainsKey(nCounter))
				return false;

			m_DataDictionary[prefix + m_Keywords[nCounter]] = s;
			++nCounter;
		}

		return true;
	}

	private string GetValue(string key)
	{
		if (m_DataDictionary.ContainsKey(key))
			return m_DataDictionary[key];
		else
			return "";
	}

	private Dictionary<string, string> m_DataDictionary;
	private Dictionary<int, string> m_Keywords;
	private int m_KeywordNum;
}
