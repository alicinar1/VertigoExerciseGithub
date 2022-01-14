using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace TopDownShooter
{
    public class AbstractScriptableManager<T> : AbstractBaseScriptableManager where T: AbstractScriptableManager<T>
    {
        protected CompositeDisposable _disposable = null;

        private static volatile T instance = null;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType(typeof(T)) as T;
                }

                return instance;
            }
        }
        public override void Initialize()
        {
            base.Initialize();
            _disposable = new CompositeDisposable();
        }

        public override void Destroy()
        {
            base.Destroy();
            _disposable.Dispose();
        }
    }
}
