using UnityEditor;
using UnityEngine;

namespace Split.Infrastructure
{
    public static class Exit
    {
        public static void ExitButtonClicked()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}