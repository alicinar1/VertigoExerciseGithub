using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class ManagerInitializerMono : MonoBehaviour
    {
        [SerializeField] private AbstractBaseScriptableManager[] _abstractBaseScriptableManagers;
        private List<AbstractBaseScriptableManager> _instandiatedAbstractBaseScriptableManagers;
        [SerializeField] private bool _dontDestroyOnLoad = true;
        private void Start()
        {
            _instandiatedAbstractBaseScriptableManagers = new List<AbstractBaseScriptableManager>(_abstractBaseScriptableManagers.Length);
            for (int i = 0; i < _abstractBaseScriptableManagers.Length; i++)
            {
                var instantiated = Instantiate(_abstractBaseScriptableManagers[i]);
                instantiated.Initialize();
                _instandiatedAbstractBaseScriptableManagers.Add(instantiated);
                
            }

            if (_dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        private void OnDestroy()
        {
            if (_instandiatedAbstractBaseScriptableManagers != null)
            {
                for (int i = 0; i < _instandiatedAbstractBaseScriptableManagers.Count; i++)
                {
                    _instandiatedAbstractBaseScriptableManagers[i].Destroy();
                }
            }
        }
    }
}
