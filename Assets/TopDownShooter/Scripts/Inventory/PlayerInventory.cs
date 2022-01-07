using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private AbstractBasePlayerInventoryItemData[] _playerInventoryItemDatas;
        private List<AbstractBasePlayerInventoryItemData> _createdDataList;
        [SerializeField] public Transform parent;

        private void Start()
        {
            InitializeInventory(_playerInventoryItemDatas);
        }

        private void OnDestroy()
        {
            ClearInventory();
        }

        public void InitializeInventory(AbstractBasePlayerInventoryItemData[] playerInventoryItemDatas)
        {
            ClearInventory();            
            _createdDataList = new List<AbstractBasePlayerInventoryItemData>(_playerInventoryItemDatas.Length);
            for (int i = 0; i < playerInventoryItemDatas.Length; i++)
            {
                var instantiated = Instantiate(playerInventoryItemDatas[i]);
                instantiated.CreateIntoInventory(this);
                _createdDataList.Add(instantiated);
            }
        }

        private void ClearInventory()
        {
            if (_createdDataList != null)
            {
                for (int i = 0; i < _createdDataList.Count; i++)
                {
                    _createdDataList[i].Destroy();
                }
            }
        }


    }
}
