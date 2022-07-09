using ECS.Components.CameraSettings;
using ECS.Components.TransformComponent;
using ECS.Components.Weapon;
using ECS.Tags;
using ECS.Tags.CameraTag;
using ECS.Tags.Player;
using ECS.Tags.PlayerElementsTag;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class PlayerCameraRotationToMouseSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, TransformComponent>.Exclude<InactiveObjectTag> _event = null;

        private readonly EcsFilter<PlayerElementsTag, CameraTag, TransformComponent, CameraSettingsComponent> _camera =
            null;

        private float _xRotation;
        private float _yRotation;

        private float _xRotCurrent;
        private float _yRotCurrent;

        private float _currentVelocityX;
        private float _currentVelocityY;

        public void Run()
        {
            foreach (int idxEvent in _event)
            {
                ref TransformComponent playerTransform = ref _event.Get2(idxEvent);

                foreach (int idxCamera in _camera)
                {
                    ref TransformComponent cameraTransform = ref _camera.Get3(idxCamera);
                    ref CameraSettingsComponent cameraSettings = ref _camera.Get4(idxCamera);

                    _xRotation += (Input.GetAxis("Mouse X") * cameraSettings.sensivity);

                    _yRotation += (Input.GetAxis("Mouse Y") * cameraSettings.sensivity);
                    _yRotation = Mathf.Clamp(_yRotation, -45, 45);

                    _xRotCurrent = Mathf.SmoothDamp(_xRotCurrent, _xRotation, ref _currentVelocityX,
                        cameraSettings.smoothTime);
                    _yRotCurrent = Mathf.SmoothDamp(_yRotCurrent, _yRotation, ref _currentVelocityY,
                        cameraSettings.smoothTime);

                    cameraTransform.value.rotation = Quaternion.Euler(-_yRotCurrent, _xRotCurrent, 0);
                    playerTransform.value.rotation = Quaternion.Euler(0, _xRotCurrent, 0);

                    RotateWeapon();
                }
            }
        }

        
        private readonly EcsFilter<PlayerElementsTag, WeaponComponent, TransformComponent> _playerWeapon = null;

        private void RotateWeapon()
        {
            foreach (int weaponIdx in _playerWeapon)
            {
                ref TransformComponent weaponTransform = ref _playerWeapon.Get3(weaponIdx);
                
                weaponTransform.value.rotation =
                    Quaternion.Euler( -_yRotCurrent, _xRotCurrent, 0);
            }
        }
    }
}