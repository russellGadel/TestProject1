using ECS.Components.EntityReference;
using ECS.CustomConvertToEntity;
using ECS.Pool;
using UnityEngine;

namespace ECS.Factory
{
    public sealed class ObjectsFactoryWithEntitiesPool : MonoBehaviour
        , IObjectsFactoryForPool
    {
        [SerializeField] private int _elementsAmount;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private EntitiesPool _pool;
        [SerializeField] private int _willCreateAdditionalElementsAmount;

        public void CreateElements()
        {
            _pool.SetCapacity(_elementsAmount);

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
            GameObject elementObject = Instantiate(_prefab, _pool.transform);

            MainPrefabConvertorToEntity mainPrefabConvertor = elementObject.GetComponent<MainPrefabConvertorToEntity>();
            mainPrefabConvertor.Convert();
            var monoEntity = AddEntityToEntitiesPool(elementObject, mainPrefabConvertor);
            monoEntity.gameObject.SetActive(false);
        }


        private MonoEntity AddEntityToEntitiesPool(in GameObject elementObject, in MainPrefabConvertorToEntity mainPrefabConvertor)
        {
            MonoEntity monoEntity = elementObject.GetComponent<MonoEntity>();
            monoEntity.Entity = mainPrefabConvertor.GetMainEntity();

            _pool.AddElement(monoEntity);
            return monoEntity;
        }
    }
}