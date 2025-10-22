using UnityEngine;
using System.Collections;


[CreateAssetMenu(menuName = "Scene Data", fileName = "New Scene Data")]
public class SceneDataSO : ScriptableObject
{
    public string UniqueName;
    public int SceneIndex;
}
