using System.Runtime.CompilerServices;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T));
            }

            return _instance;
        }
    }

    [SerializeField] Color _tagColor = Color.white;

    string _tag;
    public string Tag
    {
        get
        {
            if (string.IsNullOrEmpty(_tag))
            {
#if UNITY_EDITOR
                _tag = string.Format("<color=#{0:X2}{1:X2}{2:X2}>[{3}]</color>",
                                     (byte)(_tagColor.r * 255f),
                                     (byte)(_tagColor.g * 255f),
                                     (byte)(_tagColor.b * 255f),
                                     typeof(T).ToString());
#else
				_tag = "["+typeof(T).ToString()+"] ";
#endif
            }
            return _tag;
        }
    }

    protected virtual void Awake()
    {
        if (_instance != null)
        {
            DestroyImmediate(this);
            return;
        }

        _instance = this as T;

        if (gameObject.transform.parent == null)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this) _instance = null;
    }
}
