//FastGizmos Tool by SVerde
//contact@sverdegd.com
//https://github.com/sverdegd

using Addons.Utils.FastGizmosModule.Scripts;
using UnityEditor;

namespace Addons.Utils.FastGizmosModule.Editor
{
    [CustomEditor(typeof(FastGizmosHandleText))]
    public class FastGizmosHandleTextEditor : UnityEditor.Editor
    {
        string text;
        bool enable;

        public override void OnInspectorGUI()
        {
            FastGizmosHandleText myTarget = (FastGizmosHandleText)target;

            EditorGUI.BeginChangeCheck();
            enable = EditorGUILayout.Toggle("Enable", myTarget.enable);
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(myTarget);
                myTarget.enable = enable;
            }

            if (enable)
            {
                EditorGUI.BeginChangeCheck();
                text = EditorGUILayout.TextField("Text", myTarget.text);
                if (EditorGUI.EndChangeCheck())
                {
                    EditorUtility.SetDirty(myTarget);
                    myTarget.text = text;
                }
            }
            else
            {
                EditorGUILayout.HelpBox("The Text is disabled", MessageType.Info, true);
            }

        }

        void OnSceneGUI()
        {
            
            FastGizmosHandleText myTarget = (FastGizmosHandleText)target;
            if (myTarget == null)
                return;

            if (!myTarget.enable)
                return;
           
            Handles.Label(myTarget.transform.position, myTarget.text);
            
        }
    }
}