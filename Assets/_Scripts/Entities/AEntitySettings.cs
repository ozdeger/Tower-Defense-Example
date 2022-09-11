using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "ScriptableObjects/Entity Settings")]
public abstract class AEntitySettings : ScriptableObject, IEntitySettings
{
    public abstract string EntityPrefabName { get; }
    public abstract bool SavesPosition { get; }
    public abstract bool SavesRotation { get; }
    public abstract bool SavesScales { get; }
}
