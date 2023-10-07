using UnityEditor;

public static class ProjectExport
{
    #if UNITY_EDITOR
        [MenuItem("Studio XP/Exporter Projet")]
        public static void ExportProject()
        {
            const ExportPackageOptions flags = ExportPackageOptions.Default 
                                               | ExportPackageOptions.Recurse  
                                               | ExportPackageOptions.Interactive;

            var savePath = EditorUtility.SaveFilePanel("Sauvegarder Package Projet", "", "", "unitypackage");
            var projectContent = new string[]
            {
                "Assets",
                "ProjectSettings/AudioManager.asset",
                "ProjectSettings/EditorBuildSettings.asset",
                "ProjectSettings/EditorSettings.asset",
                "ProjectSettings/GraphicsSettings.asset",
                "ProjectSettings/InputManager.asset",
                "ProjectSettings/Physics2DSettings.asset",
                "ProjectSettings/ProjectSettings.asset",
                "ProjectSettings/QualitySettings.asset",
                "ProjectSettings/TagManager.asset",
                "ProjectSettings/TimeManager.asset"
            };

            if (!string.IsNullOrEmpty(savePath))
                AssetDatabase.ExportPackage(projectContent, savePath, flags);
        }
#endif
}
