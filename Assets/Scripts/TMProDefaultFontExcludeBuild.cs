#if UNITY_EDITOR
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

public class TMProDefaultFontExcludeBuild : IPreprocessBuildWithReport, IPostprocessBuildWithReport
{
    public int callbackOrder => 0;

    private FieldInfo defaultFontAssetFieldInfo = typeof(TMPro.TMP_Settings).GetField("m_defaultFontAsset", BindingFlags.Instance | BindingFlags.NonPublic);
    private object defaultFontAsset = null;

    public void OnPreprocessBuild(BuildReport report)
    {
        var settings = TMP_Settings.instance;
        if (settings == null)
            return;
        defaultFontAsset = defaultFontAssetFieldInfo.GetValue(settings);
        if (defaultFontAsset == null)
            return;
        defaultFontAssetFieldInfo.SetValue(settings, null);
        EditorUtility.SetDirty(settings);
    }

    public void OnPostprocessBuild(BuildReport report)
    {
        var settings = TMP_Settings.instance;
        if (settings == null || defaultFontAsset == null)
            return;
        defaultFontAssetFieldInfo.SetValue(settings, defaultFontAsset);
        defaultFontAsset = null;
        EditorUtility.SetDirty(settings);
        AssetDatabase.SaveAssets();
    }
}
#endif
