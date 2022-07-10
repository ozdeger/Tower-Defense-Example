using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelBehaviour
{
    public bool IsActive { get; }
    public void Setup(LevelConfig config, LevelController.LevelSceneReferences sceneReferences);
    public void Start();
    public void Stop();
    public void Tick(float deltaTime);
}
