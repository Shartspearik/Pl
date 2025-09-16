namespace YG.EditorScr.BuildModify
{
    using System.IO;
    using UnityEditor.Build;
    using UnityEditor.Build.Reporting;

    public class ProcessBuild : IPreprocessBuildWithReport, IPostprocessBuildWithReport
    {
        public int callbackOrder => -1000;
        public void OnPreprocessBuild(BuildReport report)
        {
            if (YG2.infoYG.Basic.platform != null && YG2.infoYG.Basic.autoApplySettings)
                InfoYG.Inst().Basic.platform.ApplyProjectSettings();
#if PLATFORM_WEBGL
            string buildPath = report.summary.outputPath;

            if (buildPath != null && buildPath != string.Empty)
            {
                string indexPath = buildPath + "/index.html";
                if (File.Exists(indexPath))
                    File.Delete(indexPath);

                string stylePath = buildPath + "/style.css";
                if (File.Exists(stylePath))
                    File.Delete(stylePath);
            }
#endif
        }

        public void OnPostprocessBuild(BuildReport report)
        {
            string pathToBuiltProject = report.summary.outputPath;

            ModifyBuild.ModifyIndex(pathToBuiltProject);
            ArchivingBuild.Archiving(pathToBuiltProject);
            BuildLog.WritingLog(pathToBuiltProject);
        }
    }
}