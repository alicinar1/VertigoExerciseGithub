using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TopDownShooter.Stat;

namespace TopDownShooter.Inventory
{
    
    public class PlayerInventory : MonoBehaviour, IPlayerStatHolder
    {
        [SerializeField] private AbstractBasePlayerInventoryItemData[] _playerInventoryItemDatas;
        private List<AbstractBasePlayerInventoryItemData> _createdDataList;
        public Transform BodyParent;
        public Transform CannonParent;

        public ReactiveCommand ReactiveShootCommand { get; private set; }


        public PlayerStat PlayerStat { get; private set; }

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

        public void SetStat(PlayerStat stat)
        {
            PlayerStat = stat;
        }
    }
}
