using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyAi : MonoBehaviour
{
    public abstract class BaseEnemyAI : MonoBehaviour
    {
        public enum EnemyState { Null, walk, attack, idle, die }

        public abstract void ChangeEnemyState(EnemyState state);
    }
}
