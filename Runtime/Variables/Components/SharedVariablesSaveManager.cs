using GameCreator.Runtime.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace GameCreator.Runtime.SharedVariables
{
    public class SharedVariablesSaveManager : Singleton<SharedVariablesSaveManager>
    {
        List<IGameSave> _saveReferences = new();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void OnSubsystemsInit()
        {
            Instance.WakeUp();
        }

        protected override void OnCreate()
        {
            _saveReferences = new List<IGameSave>();
        }

        public void Add(IGameSave reference)
        {
            _saveReferences.Add(reference);
            _ = LoadItem(reference);
        }

        public void Remove(IGameSave reference)
        {
            if (ApplicationManager.IsExiting) return;
            _saveReferences.Remove(reference);
        }

        public async void SaveAll()
        {
            foreach (var reference in _saveReferences)
            {
                await SaveItem(reference);
            }
        }

        public async Task SaveItem(IGameSave reference)
        {
            if (reference == null) return;
            var key = DatabaseKey(reference.SaveID);
            await SaveLoadManager.Instance.DataStorage.Set(key, reference.GetSaveData(false));
            await SaveLoadManager.Instance.DataStorage.Commit();
        }

        public async void LoadAll()
        {
            foreach (var reference in _saveReferences)
            {
                await LoadItem(reference);
            }
        }

        public async Task LoadItem(IGameSave reference)
        {
            if (reference == null) return;
            var key = DatabaseKey(reference.SaveID);
            var blob = await SaveLoadManager.Instance.DataStorage.Get(key, reference.SaveType);
            await reference.OnLoad(blob);
        }

        static string DatabaseKey(string key)
        {
            return $"shared--{key}";
        }
    }
}
