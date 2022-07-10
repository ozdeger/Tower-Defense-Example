using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Level Config")]
public class LevelConfig : ScriptableObject
{
    [BHeader("Level Behaviours")]
    public List<ALevelBehaviourSO> LevelBehaviours = new List<ALevelBehaviourSO>();

    [Space(50)]
    [Group] public ScenePoolLevelBehaviour.ScenePoolLevelBehaviourSettings ScenePoolSettings;
}
