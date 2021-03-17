using System.IO;
using UnityEngine;

namespace RollABall
{
    public sealed class SaveDataRepository
    {
        private readonly IData<SavedData> _data;
        private const string _folderName = "dataSave";
        private const string _fileNamePlayer = "player_data.save";
        private const string _fileNameBonus = "bonus_data.save";
        private readonly string _path;

        public SaveDataRepository()
        {
            _data = new XMLData();
            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public void Save(Player player)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var savePlayer = new SavedData
            {
                Position = player.transform.position,
                Name = player.name,
                IsEnabled = true
            };

            _data.Save(savePlayer, Path.Combine(_path, _fileNamePlayer));
        }

        public void Load(Player player)
        {
            var file = Path.Combine(_path, _fileNamePlayer);
            if (!File.Exists(file)) return;
            var newPlayer = _data.Load(file);
            player.transform.position = newPlayer.Position;
            player.name = newPlayer.Name;
            player.gameObject.SetActive(newPlayer.IsEnabled);
        }
        
        public void Save(InteractiveObject[] interactiveObject)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var saveBonus = new SavedData[interactiveObject.Length];
            for (int i = 0; i < interactiveObject.Length; i++)
            {
                saveBonus[i] = new SavedData
                {
                    Position = interactiveObject[i].transform.position,
                    Name = interactiveObject[i].name,
                    IsEnabled = interactiveObject[i].IsInteractable
                };
            }
            _data.SaveArr(saveBonus, Path.Combine(_path, _fileNameBonus));
        }

        public void Load(InteractiveObject[] interactiveObject)
        {
            var file = Path.Combine(_path, _fileNameBonus);
            if (!File.Exists(file)) return;
            var newBonuses = _data.LoadArr(file);
            for (int i = 0; i < interactiveObject.Length; i++)
            {
                if (newBonuses.ContainsKey(interactiveObject[i].name))
                {
                    interactiveObject[i].transform.position = newBonuses[interactiveObject[i].name].Position;
                    interactiveObject[i].IsInteractable = newBonuses[interactiveObject[i].name].IsEnabled;
                }
            }
        }
    }
}