using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Entity Settings")]
public class BasicEntitySettings : AEntitySettings
{
    [BHeader("Save Settings")]
    [SerializeField] private string entityPrefabName;
    [SerializeField] private bool savesPosition;
    [SerializeField] private bool savesRotation;
    [SerializeField] private bool savesScale;

    public override string EntityPrefabName => entityPrefabName;
    public override bool SavesPosition => savesPosition;
    public override bool SavesRotation => savesRotation;
    public override bool SavesScales => savesScale;
}
