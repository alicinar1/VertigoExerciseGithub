using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace TopDownShooter.Inventory
{
    
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private AbstractBasePlayerInventoryItemData[] _playerInventoryItemDatas;
        private List<AbstractBasePlayerInventoryItemData> _createdDataList;
        [SerializeField] public Transform parent;

        public ReactiveCommand ReactiveShootCommand { get; private set; }
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
            if (ReactiveShootCommand != null)
            {
                ReactiveShootCommand.Dispose();
            }
            ReactiveShootCommand = new ReactiveCommand();

            ClearInventory();
            _createdDataList = new List<AbstractBasePlayerInventoryItemData>(_playerInventoryItemDatas.Length);

            for (int i = 0; i < playerInventoryItemDatas.Length; i++)
            {
                var instantiated = Instantiate(playerInventoryItemDatas[i]);
                instantiated.Initialize(this);
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
