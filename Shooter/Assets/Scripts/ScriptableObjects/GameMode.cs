using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "GameMode", menuName = "GameMode/newMode")]
public class GameMode : ScriptableObject
{
	public enum gameModes {normal = 1, infinite = 2};
	public gameModes gameMode = gameModes.normal;
    public enum difficulty {easy = 1, normal = 2, hard = 3};
	public difficulty gameDifficulty = difficulty.easy;

	public bool lives = true;
}
