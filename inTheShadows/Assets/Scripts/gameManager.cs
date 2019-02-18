using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

	public static bool classicMode;
	public bool mode;
	public static int level;
	public int lvl;
	public static bool sound;
	public bool son;
	public selectLevel select;
	public List<GameObject> puzzle;

	void Awake () {
		lvl = level;
		mode = classicMode;
		if (GetInts("puzzleLock").Count == 0)
			resetProgress();
		son = sound;
	}

	void Start () {
		if (puzzle.Count > 0)
			puzzle[level].SetActive(true);
	}
	
	void Update () {
		if (select)
			level = select.level;
		son = sound;
	}

	public void setSound ()
	{
		if (sound)
			sound = false;
		else
			sound = true;
	}

	public void chooseMode(bool classic)
	{
		level = 0;
		classicMode = classic;
	}

	public void resetProgress()
	{
		List<int> puzzleLock = new List<int> {2,0,0,0,0,0,0};
		SetInts("puzzleLock", puzzleLock);
		List<string> puzzleTime = new List<string> {"--","--","--","--","--","--","--"};
		SetStrings("puzzleTime", puzzleTime);
	}

	public void saveProgress(float timer)
	{
		List<string> puzzleTime = GetStrings("puzzleTime");
		timer = Mathf.Floor(timer * 100) / 100;
		if (puzzleTime[level] == "--" || float.Parse(puzzleTime[level]) > timer)
		{
			puzzleTime[level] = timer.ToString();
			SetStrings("puzzleTime", puzzleTime);
		}
		List<int> puzzleLock = GetInts("puzzleLock");
		puzzleLock[level] = 3;
		if (puzzle.Count > level + 1 && puzzleLock[level + 1] == 0)
		{
			puzzleLock[level + 1] = 1;
			level++;
		}
		SetInts("puzzleLock", puzzleLock);
	}

	public void SetInts(string key, List<int> collection)
	{
		// Delete Old Collection
		int count = PlayerPrefs.GetInt(key + ".Count", 0);
		for (int i = 0; i < count; i++)
			PlayerPrefs.DeleteKey(key + "[" + i + "]");
		// Create New Collection
		PlayerPrefs.SetInt(key + ".Count", collection.Count);
		for (int i = 0; i < collection.Count; i++)
			PlayerPrefs.SetInt(key + "[" + i + "]", collection[i]);
		// Save Collection
		PlayerPrefs.Save();
	}

	public List<int> GetInts(string key)
	{
		int count = PlayerPrefs.GetInt(key + ".Count", 0);
		List<int> list = new List<int>(new int[count]);
		for (int i = 0; i < count; i++)
			list[i] = PlayerPrefs.GetInt(key + "[" + i + "]");
		return list;
	}

	public void SetStrings(string key, List<string> collection)
	{
		// Delete Old Collection
		int count = PlayerPrefs.GetInt(key + ".Count", 0);
		for (int i = 0; i < count; i++)
			PlayerPrefs.DeleteKey(key + "[" + i + "]");
		// Create New Collection
		PlayerPrefs.SetInt(key + ".Count", collection.Count);
		for (int i = 0; i < collection.Count; i++)
			PlayerPrefs.SetString(key + "[" + i + "]", collection[i]);
		// Save Collection
		PlayerPrefs.Save();
	}

	public List<string> GetStrings(string key)
	{
		int count = PlayerPrefs.GetInt(key + ".Count", 0);
		List<string> list = new List<string>(new string[count]);
		for (int i = 0; i < count; i++)
			list[i] = PlayerPrefs.GetString(key + "[" + i + "]");
		return list;
	}
}