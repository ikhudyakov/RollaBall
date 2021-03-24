using UnityEngine;

namespace RollABall
{
    public class InputController : IExecute
    {
        private readonly Player _player;
        private readonly SaveDataRepository _saveDataRepository;
        private readonly InteractiveObject[] _bonuses;
        public InputController(Player player, InteractiveObject[] bonuses)
        {
            _player = player;
            _bonuses = bonuses;
            _saveDataRepository = new SaveDataRepository();
        }

        public void Execute()
        {
            _player.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (Input.GetKeyDown(KeyCode.C))
            {
                _saveDataRepository.Save(_player);
                _saveDataRepository.Save(_bonuses);
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                _saveDataRepository.Load(_player);
                _saveDataRepository.Load(_bonuses);
            }
        }
    }
}