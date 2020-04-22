using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorUIManager : MonoBehaviour
{
    [RequireComponent(typeof(RectTransform))]
    public class SettingsUIManager : MonoBehaviour
    {
        RectTransform rectTransform;

        
        static SettingsUIManager instance;
        public static SettingsUIManager Instance
        {
            get
            {
                if (instance == null)
                    instance = FindObjectOfType<SettingsUIManager>();
                if (instance == null)
                    Debug.LogError("HomeUIManager not found");
                return instance;
            }
        }
        
        void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            
        }

        public void Show(float delay = 0f)
        {
            
        }

        public void Hide(float delay = 0f)
        {
            
        }
    }
}
