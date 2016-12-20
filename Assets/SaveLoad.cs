using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SaveLoad : MonoBehaviour {

	static Game savedGames = new Game();

	//it's static so we can call it from anywhere
	public static void Save() {
		BinaryFormatter bf = new BinaryFormatter();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd"); //you can call it anything you want
		bf.Serialize(file, savedGames);
		file.Close();
	}

	public static void Load() {
		if (File.Exists(Application.persistentDataPath + "/savedGames.gd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
			savedGames = (Game)bf.Deserialize(file);
			file.Close();
		}
	}

	void Awake() {
		Load();
	}

	public static void UpdateNewScore(int newScore) {
		if (newScore > savedGames.HighestScore) {
			savedGames.HighestScore = newScore;
			Save();
		}
	}

	public static int GetHighestScore() {
		return savedGames.HighestScore;
	}
}

[Serializable]
public class Game {

	public int HighestScore;

}

//[Serializable]
//public class LeaderBoardElement {
//	public string PlayerName;
//	public int Score;
//	public DateTime Date;
//}