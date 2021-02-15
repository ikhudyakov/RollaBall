//----- using ----------------------------------------------
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;
//-----
namespace MadTools{
    //----- Запуск создания станлартной структуры на сцене 
    public  class MTStdSceneFolders{
        
        #if UNITY_EDITOR                
            [MenuItem ("GameObject/3D Object/MadTools/Common/Create Standart Folders")]
            static void CreateStdFolders(){
                
                //----- Править список для изменения структуры         
                string[] folders=new string[] {"0.Common","1.Environment",
                    "2.Scene","3.Camera","4.Characters","5.UI","9.Other","10.__Trash"};
                            
                foreach(string f in folders){
                    GameObject go=GameObject.Find(f);
                    if (go==null){
                        Debug.LogFormat("\t Create STD Folders ===> <color= magenta> Create {0} </color>",f);
                        go=new GameObject();
                        go.name=f;
                        if(f.Contains("__"))
                            go.AddComponent<HideOnRun>();
                    }                    
                }    
            }
        #endif
    }//-----
    
    public class HideOnRun:MonoBehaviour{
        private void Start() {
            gameObject.SetActive(false);
        }
    }
    
}//-----