using ECS.CustomConvertToEntity;
using UnityEngine;

namespace ECS.Factory
{
    public class ObjectsFactory : MonoBehaviour
        , IObjectsFactoryForPool
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _elementsAmount;
        [SerializeField] private int _minBufferElementsAtPool;
        public int MinBufferElementsAtPool => _minBufferElementsAtPool;
        [SerializeField] private int _willCreateAdditionalElementsAmount;

        public void Initialize()
        {
            for (int i = 0; i < _elementsAmount; i++)
            {
                CreateNewElement();
            }
        }

        public void CreateAdditionalElements()
        {
            for (int i = 0; i < _willCreateAdditionalElementsAmount; i++)
            {
                CreateNewElement();
            }
        }


        private void CreateNewElement()
        {
            GameObject gameObject = Instantiate(_prefab, _transform);
            gameObject.SetActive(false);
            MainPrefabConvertorToEntity convertPrefabToEntity = gameObject.GetComponent<MainPrefabConvertorToEntity>();
            convertPrefabToEntity.Convert();
        }
    }
}