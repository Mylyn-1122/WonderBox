using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;


[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    public Tilemap tile;
    public ItemType type;
    public ActionType actiontype;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Only UI")]
    public bool stackable = true;

    [Header("Both")]
    public Sprite image;


    public enum ItemType {
        Key,
        Puzzle

    }

    public enum ActionType {
        Unlock,
        JustStore
    }
    public string getType() {
        return type.ToString();
    }
    

}
