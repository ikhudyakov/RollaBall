using UnityEngine;

namespace RollABall
{
	public sealed class MiniMapController : IExecute, ILateExecute
	{
		private Transform _player;
		private Transform _camera;

        public MiniMapController(Transform player, Transform camera)
        {
			_player = player;
			_camera = camera;

		}

        public void Execute()
        {
			_player = Camera.main.transform;
			_camera.parent = null;
			_camera.rotation = Quaternion.Euler(90.0f, 0, 0);
			_camera.position = _player.position + new Vector3(0, 5.0f, 0);

			var rt = Resources.Load<RenderTexture>("Map/Map");

			_camera.GetComponent<Camera>().targetTexture = rt;
		}

        public void LateExecute()
		{
			var newPosition = _player.position;
			newPosition.y = _camera.position.y;
			_camera.position = newPosition;
			_camera.rotation = Quaternion.Euler(90, 0, 0);
		}
	}

}