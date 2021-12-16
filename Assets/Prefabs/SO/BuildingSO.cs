using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingSO", menuName = "ScriptableObject/BuildingSO")]
public class BuildingSO : ScriptableObject
{
    [SerializeField] private Transform transform;
}
