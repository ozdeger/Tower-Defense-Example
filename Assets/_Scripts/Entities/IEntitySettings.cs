using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntitySettings 
{
    public string EntityPrefabName { get; }
    public bool SavesPosition { get; }
    public bool SavesRotation { get; }
    public bool SavesScales { get; }
}
