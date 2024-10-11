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
        EditorWindow win = GetWindow(typeof(BatchReplaceMat), true, "批量替换同名材质");
        win.Show();
        win.Focus();
    }

    private void OnGUI()
    {
        GUILayout.BeginVertical();
        GUILayout.Box(" 1、材质名需与模型文件下的材质同名\n2、只替换场景中active的游戏物体\n");
        mat = (Material)EditorGUILayout.ObjectField("材质",mat,typeof(Material),true);
        if (GUILayout.Button("Replace")) {
            replaceList.Clear();
            //获取场景中所有游戏物体
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
