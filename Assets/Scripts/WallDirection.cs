using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDirection : MonoBehaviour
{   
    public bool isBackWall;

    public Direction direction;

    public enum Direction
    {
        SmallTop,
        SmallBottom,
        SmallLeft,
        SmallRight,
        //UpDoubleTop,
        //UpDoubleTop_Left,
        //UpDoubleTop_Right,
        //UpDoubleRight,
        //UpDoubleLeft,
        //UpDoubleBottom,
        //UpDoubleBottom_Left,
        //UpDoubleBottom_Right,
        None
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /*private void CheckRoomPoints(GameObject room)
    {
        RoomSpawner[] roomSpawners = room.GetComponentsInChildren<RoomSpawner>();

        foreach (RoomSpawner spawner in roomSpawners)
        {
            if (spawner.CompareTag("RoomPoint") || spawner.CompareTag("RoomPoint_40x20") && spawner.direction == GetOppositeDirection(direction))
            {
                spawner.gameObject.SetActive(false);
            }
        }
    }

    private Direction GetOppositeDirection(Direction dir)
    {
        switch (dir)
        {
            case Direction.Top:
                return Direction.Bottom;
            case Direction.Bottom:
                return Direction.Top;
            case Direction.Left:
                return Direction.Right;
            case Direction.Right:
                return Direction.Left;
            default:
                return Direction.None;
        }
    }*/
}