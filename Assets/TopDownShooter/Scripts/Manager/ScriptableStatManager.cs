using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Stat
{
    [CreateAssetMenu(menuName = "Top Down Shooter/Manager/ScriptableStatManager")]
    public class ScriptableStatManager : AbstractScriptableManager<ScriptableStatManager>
    {
        public List<PlayerStat> playerStatList = new List<PlayerStat>();
        public void RegisterStats(PlayerStat stat)
        {
            playerStatList.Add(stat);
        }

        public  PlayerStat Find(int id)
        {
            for (int i = 0; i < playerStatList.Count; i++)
            {
                if (playerStatList[i].ID == id)
                {
                    return playerStatList[i];
                }
            }
            throw new System.Exception("Couldn't find player stat with id: " + id);
        }
    }
}
