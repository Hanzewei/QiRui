using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BatchReplaceMat : EditorWindow
{
    Material mat;
    List<GameObject> replaceList = new List<GameObject>();

    [MenuItem("MyTool/ReplaceSameMat")]
    public static void ReplaceSameMat() {
        EditorWindow win = GetWindow(typeof(BatchReplaceMat), true, "�����滻ͬ������");
        win.Show();
        win.Focus();
    }

    private void OnGUI()
    {
        GUILayout.BeginVertical();
        GUILayout.Box(" 1������������ģ���ļ��µĲ���ͬ��\n2��ֻ�滻������active����Ϸ����\n");
        mat = (Material)EditorGUILayout.ObjectField("����",mat,typeof(Material),true);
        if (GUILayout.Button("Replace")) {
            replaceList.Clear();
            //��ȡ������������Ϸ����
            GameObject[] objs = (GameObject[])GameObject.FindObjectsOfType(typeof(GameObject));
            foreach (GameObject o in objs) {
                if (o.GetComponent<MeshRenderer>()!=null) {
                    if (o.GetComponent<MeshRenderer>().sharedMaterial.name.Equals(mat.name)) {
                        Debug.Log(o.GetComponent<MeshRenderer>().sharedMaterial.name);
                        replaceList.Add(o);
                    }
                }
            }
            for (int i=0;i<replaceList.Count;i++) {
                replaceList[i].GetComponent<MeshRenderer>().material = mat;
            }
        }
        GUILayout.EndVertical();
    }
}
