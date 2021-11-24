using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

static class cardMenu
{
    [MenuItem("Assets/create/Cards")]
    [MenuItem("Assets/Create/Cards/Add card")]
    static void addCard()
    {
        var asset = ScriptableObject.CreateInstance<addCard>();

        var path = AssetDatabase.GetAssetPath(Selection.activeObject);
        path += "new add card.asset";

        ProjectWindowUtil.CreateAsset(asset,path);
    }

    [MenuItem("Assets/Create/Cards/Multi card")]
     static void MultiCard()
     {
         var asset = ScriptableObject.CreateInstance<multiCard>();

         var path = AssetDatabase.GetAssetPath(Selection.activeObject);
         path += "new Multi card.asset";

         ProjectWindowUtil.CreateAsset(asset, path);
     }

    [MenuItem("Assets/Create/Cards/Pest card")]
    static void PestCard()
    {
        var asset = ScriptableObject.CreateInstance<PestCard>();

        var path = AssetDatabase.GetAssetPath(Selection.activeObject);
        path += "new Pest card.asset";

        ProjectWindowUtil.CreateAsset(asset, path);
    }

    [MenuItem("Assets/Create/Cards/Weather card")]
    static void WeatherCard()
    {
        var asset = ScriptableObject.CreateInstance<weatherCard>();

        var path = AssetDatabase.GetAssetPath(Selection.activeObject);
        path += "new weather card.asset";

        ProjectWindowUtil.CreateAsset(asset, path);
    }
}
