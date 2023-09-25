using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class LoadCharacter : MonoBehaviour
{
    [SerializeField] private GameObject[] characterPrefabs;
    [SerializeField] private GameObject parentObj;
    
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPrefabs[selectedCharacter];
        Instantiate(prefab, parentObj.transform);
        Animator anim = parentObj.GetComponent<Animator>();
    }
}
