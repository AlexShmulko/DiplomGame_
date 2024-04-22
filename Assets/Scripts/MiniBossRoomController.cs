using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossRoomController : MonoBehaviour
{
    private Transform[] childObjects;

    public GameObject newObjectPrefab;

    private MiniBossSpawnController minibossSpawnController;

    void Start()
    {
        Invoke("HideAnotherDirWall", 0.2f);
    }

    void HideAnotherDirWall()
    {
        childObjects = GetComponentsInChildren<Transform>();

        foreach (Transform child in childObjects)
        {
            if (child != null && child.CompareTag("MiniBossWall"))
            {
                minibossSpawnController = child.GetComponent<MiniBossSpawnController>();
                if (minibossSpawnController != null && minibossSpawnController.backroom == 0)
                {
                     ReplaceChildren(child);
                }
            }
        }
    } 

    void ReplaceChildren(Transform child)
    {
        Transform parent = child.parent;

        Vector3 position = child.position;
        Quaternion rotation = child.rotation;

        GameObject newObject = Instantiate(newObjectPrefab, position, rotation);

        newObject.transform.parent = parent;
        
        Destroy(child.gameObject);
    }
}
