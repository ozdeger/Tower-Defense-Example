using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity 
{
    public IEntitySettings EntitySettings { get; }
    public int Id { get; set; }
    public Vector3 Position { get; }
    public Quaternion Rotation { get; }
    public Vector3 Scale { get; }

    public object[] GetAdditionalSaveData();
    public void StartEntityWithLoad(object[] data);
    public void StartEntityNoraml();
}
