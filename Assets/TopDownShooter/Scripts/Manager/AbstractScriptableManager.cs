using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class AbstractScriptableManager<T> : AbstractBaseScriptableManager where T: AbstractScriptableManager<T>
    {
        public static T _instance;

        public override void Initialize()
        {
            base.Initialize();
            _instance = this as T;
        }

        public override void Destroy()
        {
            base.Destroy();

        }
    }
}
