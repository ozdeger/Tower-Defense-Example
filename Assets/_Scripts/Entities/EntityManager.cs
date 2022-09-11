using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System;
using Utilities;

public class EntityManager : MonoBehaviour
{
    List<IEntity> AllEntities = new List<IEntity>();

    private int nextEntityId = 0;
    
    public T GetEntity<T>(int entityId) where T : IEntity
    {
        return (T) AllEntities.FirstOrDefault(e => e.Id == entityId);
    }
    
    public void RegisterEntity(IEntity entity)
    {
        AllEntities.Add(entity);
        entity.Id = nextEntityId;
        nextEntityId++;
    }
    
    public void RegisterLoadedEntity(IEntity entity, int loadedId)
    {
        AllEntities.Add(entity);
        entity.Id = loadedId;
    }

    public void RemoveEntity(IEntity entity)
    {
        AllEntities.Remove(entity);
    }
    
    public void SaveAllEntities()
    {
        EntitiesSaveData saveData = new EntitiesSaveData();
        foreach (var entity in AllEntities)
        {
            saveData.SaveEntity(entity);
        }
        SaveManager.Save(SaveManager.ENTITYMANAGER_SAVE_NAME, saveData);
    }

    public void LoadAllEntities()
    {
        EntitiesSaveData loadedData = SaveManager.Load<EntitiesSaveData>(SaveManager.ENTITYMANAGER_SAVE_NAME);

        foreach (var entityData in loadedData.EntityDatas)
        {
            // register all entities
            IEntity entitySpawned = ObjectPooler.Instance.Spawn(entityData.PrefabName, entityData.Position, entityData.Rotation).GetComponent<IEntity>();
            RegisterLoadedEntity(entitySpawned, entityData.Id);
        }

        for (int i = 0; i < AllEntities.Count; i++)
        {
            AllEntities[i].StartEntityWithLoad(loadedData.EntityDatas[i].AdditionalData);
        }
    }


    public void OnApplicationQuit()
    {
        SaveAllEntities();
    }
}

[System.Serializable]
public class EntitiesSaveData
{
    private List<EntityData> entityDatas = new List<EntityData>();

    public List<EntityData> EntityDatas => entityDatas;

    public void SaveEntity(IEntity entity)
    {
        var entityData = new EntityData();
        entityData.PrefabName = entity.EntitySettings.EntityPrefabName;
        entityData.Id = entity.Id;
        entityData.Position = entity.Position;
        entityData.Rotation = entity.Rotation;
        entityData.Scale = entity.Scale;
        entityData.AdditionalData = entity.GetAdditionalSaveData();
        entityDatas.Add(entityData);
    }

    [System.Serializable]
    public struct EntityData
    {
        public int Id;
        public string PrefabName;
        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Scale;
        public object[] AdditionalData;
    }
}
